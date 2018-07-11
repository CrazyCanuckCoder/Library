using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void ToProper_ReturnsValidString_ForLowercaseText()
        {
            const string expectedString = "All Lowercase Letters";

            Assert.IsTrue("all lowercase letters".ToProper(true).Equals(expectedString),
                "ToProper did not convert the letters of each word of a phrase to upper case.");
        }

        [Test]
        public void ToProper_ReturnsValidString_ForUppercaseText()
        {
            const string expectedString = "All Uppercase Letters";

            Assert.IsTrue("ALL UPPERCASE LETTERS".ToProper(true).Equals(expectedString),
                "ToProper did not convert the letters of each word of a phrase to upper case.");
        }

        [Test]
        public void IsBetween_ReturnsFalse_ForValueNotBetween2Numbers()
        {
            int origValue = 42;

            Assert.IsFalse(origValue.IsBetween(10, 20), "IsBetween returned true for a value out of scope.");
        }

        [Test]
        public void IsBetween_ReturnsTrue_ForValueBetween2Numbers()
        {
            int origValue = 18;

            Assert.IsTrue(origValue.IsBetween(10, 20), "IsBetween returned false for a value in scope.");
        }

        [Test]
        public void IsBetween_ReturnsFalse_ForTextOutOfScope()
        {
            string origText = "something";

            Assert.IsFalse(origText.IsBetween("also", "ran"), "IsBetween returned true for a string out of scope.");
        }

        [Test]
        public void IsBetween_ReturnsTrue_ForTextInScope()
        {
            string origText = "something";

            Assert.IsTrue(origText.IsBetween("also", "text"), "IsBetween returned false for a string in scope.");
        }

        [Test]
        public void IsEmpty_ReturnsTrue_ForNullString()
        {
            string nullText = null;

            Assert.IsTrue(nullText.IsEmpty(), "IsEmpty returned false for a null string.");
        }

        [Test]
        public void IsEmpty_ReturnsTrue_ForEmptyString()
        {
            string emptyString = "  ";

            Assert.IsTrue(emptyString.IsEmpty(), "IsEmpty returned false for an empty string.");
        }

        [Test]
        public void IsEmpty_ReturnsFalse_ForStringWithText()
        {
            string text = "some text";

            Assert.IsFalse(text.IsEmpty(), "IsEmpty returned true for a string with text in it.");
        }

        [Test]
        public void IsDateTime_ReturnsTrue_ForValidDate()
        {
            Assert.IsTrue("12/31/2014".IsDateTime(), "IsDateTime returned false for valid date string.");
        }

        [Test]
        public void IsDateTime_ReturnsFalse_ForInvalidDate()
        {
            Assert.IsFalse("02/29/2014".IsDateTime(), "IsDateTime returned true for invalid date string.");
        }

        [Test]
        public void IsNumeric_ReturnsTrue_ForValidNumberNoDecimals()
        {
            Assert.IsTrue("100".IsNumeric(), "IsNumeric returned false for valid numeric string.");
        }

        [Test]
        public void IsNumeric_ReturnsTrue_ForValidNumberWithDecimals()
        {
            Assert.IsTrue("100.99".IsNumeric(), "IsNumeric returned false for valid numeric string.");
        }

        [Test]
        public void IsNumeric_ReturnsTrue_ForValidNegativeNumber()
        {
            Assert.IsTrue("-100".IsNumeric(), "IsNumeric returned false for valid negative numeric string.");
        }

        [Test]
        public void IsNumeric_ReturnsTrue_ForValidNegativeNumberWithDecimals()
        {
            Assert.IsTrue("-100.993".IsNumeric(),
                "IsNumeric returned false for valid negative numeric string with decimals.");
        }

        [Test]
        public void IsNumeric_ReturnsFalse_ForInvalidNumericText()
        {
            Assert.IsFalse("100A".IsNumeric(), "IsNumeric returned true for invalid numeric string.");
        }


        [Test]
        public void GetFieldDelimitedList_ReturnsProperList_ForDataTableValues()
        {
            //  Create an in memory data table with one field and a few values.

            DataTable testTable = new DataTable("TestTable");
            testTable.Columns.Add("Names");

            DataRow newRow = testTable.NewRow();
            newRow["Names"] = "Stephen";
            testTable.Rows.Add(newRow);

            newRow = testTable.NewRow();
            newRow["Names"] = "Monica";
            testTable.Rows.Add(newRow);

            newRow = testTable.NewRow();
            newRow["Names"] = "Olivia";
            testTable.Rows.Add(newRow);

            newRow = testTable.NewRow();
            newRow["Names"] = "Liam";
            testTable.Rows.Add(newRow);

            //  Add the same values again to test that the method pulls unique values only.

            newRow = testTable.NewRow();
            newRow["Names"] = "Stephen";
            testTable.Rows.Add(newRow);

            newRow = testTable.NewRow();
            newRow["Names"] = "Monica";
            testTable.Rows.Add(newRow);

            newRow = testTable.NewRow();
            newRow["Names"] = "Olivia";
            testTable.Rows.Add(newRow);

            newRow = testTable.NewRow();
            newRow["Names"] = "Liam";
            testTable.Rows.Add(newRow);

            string expectedText = "'Stephen','Monica','Olivia','Liam'";

            Assert.That(testTable.GetFieldDelimitedList("Names"), Is.EqualTo(expectedText));
        }

        [Test]
        public void GetFieldDelimitedList_ThrowsArgumentNullException_ForNullTable()
        {
            DataTable testTable = null;

            Assert.That(() => testTable.GetFieldDelimitedList("FieldName"), Throws.TypeOf<ArgumentNullException>()
                .With.Message.EqualTo("Value cannot be null.\r\nParameter name: SourceTable"));
        }

        [Test]
        public void GetFieldDeilimitedList_ThrowsArgumentNullException_ForNullFieldName()
        {
            DataTable testTable = new DataTable();

            Assert.That(() => testTable.GetFieldDelimitedList(null), Throws.TypeOf<ArgumentNullException>()
                .With.Message.EqualTo("Value cannot be null.\r\nParameter name: FieldName"));
        }

        [Test]
        public void GetFieldDelimitedText_ThrowsArgumentException_ForEmptyFieldName()
        {
            DataTable testTable = new DataTable();

            Assert.That(() => testTable.GetFieldDelimitedList(""), Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("FieldName cannot be blank."));
        }

        [Test]
        public void GetFieldDelimitedList_ThrowsArgumentException_ForTableWithoutField()
        {
            DataTable testTable = new DataTable("TestTable");
            testTable.Columns.Add("ID");

            Assert.That(() => testTable.GetFieldDelimitedList("NoField"), Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Specified FieldName is not in the DataTable."));
        }


        private enum ExampleEnum
        {
            FirstEntry,
            SecondEntry,
            ThirdEntry,
            FourthEntry,
            Thereshouldbenospacesbetweenthesewords
        }

        private enum NoMembers
        {
        }

        [Test]
        public void GetReadableValues_ReturnsCorrectList_ForEnum()
        {
            ExampleEnum testEnum = new ExampleEnum();
            List<string> expectedStrings = new List<string>()
            {
                "First Entry",
                "Second Entry",
                "Third Entry",
                "Fourth Entry",
                "Thereshouldbenospacesbetweenthesewords"
            };

            Assert.That(() => testEnum.GetReadableValues(), Is.EqualTo(expectedStrings));
        }

        [Test]
        public void GetReadableValues_ReturnsEmptyList_ForEmptyEnum()
        {
            NoMembers emptyEnum = new NoMembers();
            List<string> expectedStrings = new List<string>();

            Assert.That(() => emptyEnum.GetReadableValues(), Is.EqualTo(expectedStrings));
        }

        [Test]
        public void ParseByCapitals_ReturnsExpectedString_ForCapitalizedString()
        {
            //  I choose some text that had a single letter at the end to check the method's parsing of this situation.

            string test = "ThereButForTheGraceOfGodGoI";
            string expectedText = "There But For The Grace Of God Go I"; // Attributed to John Bradford, 16th Century

            Assert.That(() => test.ParseByCapitals(), Is.EqualTo(expectedText));
        }

        [Test]
        public void ParseByCapitals_ReturnsBlankString_ForBlankParameterString()
        {
            string test = "";
            string expectedText = "";

            Assert.That(() => test.ParseByCapitals(), Is.EqualTo(expectedText));
        }

        [Test]
        public void ParseByCapitals_ReturnsIdenticalString_ForStringWithoutCapitals()
        {
            string test = "thishasnocapitalletters";
            string expectedText = "thishasnocapitalletters";

            Assert.That(() => test.ParseByCapitals(), Is.EqualTo(expectedText));
        }

        [Test]
        public void BetterSplit_ReturnsEmptyList_ForBlankString()
        {
            string test = "";

            Assert.That(() => test.BetterSplit(',').Count, Is.EqualTo(0));
        }

        [Test]
        public void BetterSplit_ReturnsExpectedList_ForStringWithASingleQuote()
        {
            string test = "one,two,three,\"four,five,six";
            List<string> expectedList = new List<string>()
            {
                "one",
                "two",
                "three",
                "four,five,six"
            };

            Assert.That(() => test.BetterSplit(','), Is.EqualTo(expectedList));
        }

        [Test]
        public void BetterSplit_ReturnsExpectedList_ForStringWithNoQuotes()
        {
            string test = "one,two,three,four,five,six";
            List<string> expectedList = new List<string>()
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six"
            };

            Assert.That(() => test.BetterSplit(','), Is.EqualTo(expectedList));
        }

        [Test]
        public void BetterSplit_ReturnsExpectedList_ForStringWithWrongDelimiter()
        {
            string test = "one,two,three,four,five,six";
            List<string> expectedList = new List<string>()
            {
                "one,two,three,four,five,six"
            };

            Assert.That(() => test.BetterSplit(';'), Is.EqualTo(expectedList));
        }

        [Test]
        public void BetterSplit_ReturnsExpectedList_ForStringWithTrailingDelimiter()
        {
            string test = "one,two,\"three,four\",five,six,";
            List<string> expectedList = new List<string>()
            {
                "one",
                "two",
                "three,four",
                "five",
                "six"
            };

            Assert.That(() => test.BetterSplit(','), Is.EqualTo(expectedList));
        }

        [Test]
        public void BetterSplit_ReturnsExpectedList_ForStringWithQuotes()
        {
            string test =
                "This is a sentence.,This is a different sentence.,\"This, while similar to the others, is a different sentence.\",This is the last sentence.";
            List<string> expectedList = new List<string>()
            {
                "This is a sentence.",
                "This is a different sentence.",
                "This, while similar to the others, is a different sentence.",
                "This is the last sentence."
            };

            Assert.That(() => test.BetterSplit(','), Is.EqualTo(expectedList));
        }

        [Test]
        public void ToCommaDelimitedString_ReturnsBlankString_ForEmptyList()
        {
            List<string> emptyList = new List<string>();

            Assert.That(() => emptyList.ToCommaDelimitedString(), Is.EqualTo(""));
        }

        [Test]
        public void ToCommaDelimitedString_ReturnsQuotedText_ForListWithCommas()
        {
            List<string> origList = new List<string>()
            {
                "One",
                "Two",
                "Three,Four",
                "Five",
                "Six"
            };
            string expectedString = "One,Two,\"Three,Four\",Five,Six";

            Assert.That(() => origList.ToCommaDelimitedString(), Is.EqualTo(expectedString));
        }

        [Test]
        public void ToCommaDelimitedString_ReturnsExpectedText_ForList()
        {
            List<string> origList = new List<string>()
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six"
            };
            string expectedString = "One,Two,Three,Four,Five,Six";

            Assert.That(() => origList.ToCommaDelimitedString(), Is.EqualTo(expectedString));
            
        }
    }
}
