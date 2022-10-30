using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Library
{
    public static class Extensions
    {
        private static readonly char[] _inStringDelimiter = new char[] {',', ' '};

        /// <summary>
        /// Converts the words in the specified text to begin with capital letters.
        /// </summary>
        /// 
        /// <param name="Text">
        /// The text to convert.
        /// </param>
        /// 
        /// <param name="CapitalizeAll">
        /// True to capitalize all words found in the string and false to only
        /// capitalize the first letter of the string.
        /// </param>
        /// 
        /// <returns>
        /// The text converted to words with capital letters.
        /// </returns>
        /// 
        public static string ToProper(this string Text, bool CapitalizeAll)
        {
            string properText;
            if (Text.Length > 1)
            {
                properText = Text.Substring(0, 1).ToUpper() + Text.Substring(1).Trim().ToLower();

                if (CapitalizeAll)
                {
                    int startChar = 1;
                    int spaceLoc = Text.IndexOf(" ", startChar, StringComparison.Ordinal);
                    while (spaceLoc > -1)
                    {
                        startChar = spaceLoc + 1;
                        properText = properText.Substring(0, startChar) + Text.Substring(startChar, 1).ToUpper();
                        if (startChar + 1 < Text.Length)
                        {
                            properText += Text.Substring(startChar + 1).ToLower();
                        }
                        spaceLoc = properText.IndexOf(" ", startChar, StringComparison.Ordinal);
                    }
                }
            }
            else
            {
                properText = Text.ToUpper();
            }

            return properText;
        }

        /// <summary>
        /// Returns a copy of the string with the first letter converted to lower case and the rest of the
        /// string's case untouched.
        /// </summary>
        /// 
        /// <param name="Text">
        /// The text to convert.
        /// </param>
        /// 
        /// <returns>
        /// A string with the first letter of the original string converted to lower case.
        /// </returns>
        /// 
        public static string FirstCharToLower(this string Text)
        {
            string lowerText;
            if (Text.Length > 1)
            {
                lowerText = Text.Substring(0, 1).ToLower() + Text.Substring(1).Trim();
            }
            else
            {
                lowerText = Text.ToLower();
            }

            return lowerText;
        }

        /// <summary>
        /// Returns true if the current value is between the Low and High values.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of value to compare.
        /// </typeparam>
        /// 
        /// <param name="Value">
        /// The current value.
        /// </param>
        /// 
        /// <param name="Low">
        /// The lowest value that the current value can be.
        /// </param>
        /// 
        /// <param name="High">
        /// The highest value that the current value can be.
        /// </param>
        /// 
        /// <returns>
        /// True if value is greater than or equal to the value in the Low parameter
        /// and less than or equal to the value in the High parameter.
        /// </returns>
        /// 
        public static bool IsBetween<T>(this T Value, T Low, T High) where T : IComparable<T>
        {
            return Value.CompareTo(Low) >= 0 && Value.CompareTo(High) <= 0;
        }

        /// <summary>
        /// Returns true if the contents of the string contains only numbers.
        /// </summary>
        /// 
        /// <param name="Text">
        /// The string to check.
        /// </param>
        /// 
        /// <returns>
        /// True if the string contains all numbers and false if not.
        /// </returns>
        /// 
        public static bool IsNumeric(this string Text)
        {
            return !string.IsNullOrEmpty(Text) && Regex.IsMatch(Text, @"^[+-]?[\d+\.?\d]+$");
        }

        /// <summary>
        /// Returns true if the contents of the string contain a date.
        /// </summary>
        /// 
        /// <param name="Text">
        /// The string to check.
        /// </param>
        /// 
        /// <returns>
        /// True if the string contains a date and false if not.
        /// </returns>
        /// 
        public static bool IsDate(this string Text)
        {
            return IsDateTime(Text);
        }

        /// <summary>
        /// Returns true if the contents of the string contain a date and a time.
        /// </summary>
        /// 
        /// <param name="Text">
        /// The string to check.
        /// </param>
        /// 
        /// <returns>
        /// True if the string contains a date and a time; otherwise false.
        /// </returns>
        /// 
        public static bool IsDateTime(this string Text)
        {
            return DateTime.TryParse(Text, out _);
        }

        /// <summary>
        /// Converts the text in a string to an integer value.  If the text is not an integer 
        /// or can't be parsed, 0 is returned.
        /// </summary>
        /// 
        /// <param name="Text">
        /// The string to convert.
        /// </param>
        /// 
        /// <returns>
        /// The converted integer value or 0 if the string is not an integer.
        /// </returns>
        /// 
        public static int ToInt(this string Text)
        {
            int intValue = 0;

            if (Text.IsNumeric())
            {
                int.TryParse(Text, out intValue);
            }

            return intValue;
        }

        /// <summary>
        /// Takes a list of the unique values for a specified field and creates
        /// a comma separated string of the values to use in a SQL Select
        /// statement.
        /// </summary>
        /// 
        /// <param name="SourceTable">
        /// The DataTable containing the field to use for the delimited list.
        /// </param>
        /// 
        /// <param name="FieldName">
        /// The name of the field containing the values for the list.
        /// </param>
        /// 
        /// <returns>
        /// A string containing the values from the specified field delimited by
        /// commas.  If no records were found in the DataTable, an empty string
        /// is returned.
        /// </returns>
        /// 
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// 
        public static string GetFieldDelimitedList(this DataTable SourceTable, string FieldName)
        {
            string delimitedValues;
            if (SourceTable != null)
            {
                if (FieldName != null)
                {
                    if (!string.IsNullOrEmpty(FieldName))
                    {
                        if (SourceTable.Columns.Contains(FieldName))
                        {
                            var valueSB = new StringBuilder();
                            DataTable uniqueValues = SourceTable.DefaultView.ToTable(true, FieldName);

                            foreach (DataRow currRow in uniqueValues.Rows)
                            {
                                valueSB.Append("'" + currRow[FieldName] + "',");
                            }

                            delimitedValues = valueSB.ToString();
                            if (delimitedValues != "" && delimitedValues.Contains(","))
                            {
                                delimitedValues = delimitedValues.TrimEnd(_inStringDelimiter);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Specified FieldName is not in the DataTable.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("FieldName cannot be blank.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("FieldName");
                }
            }
            else
            {
                throw new ArgumentNullException("SourceTable");
            }

            return delimitedValues;
        }

        /// <summary>
        /// Clones the public properties of a specified Control object.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Parameter must be derived from the Control class.
        /// </typeparam>
        /// 
        /// <param name="ControlToClone">
        /// The object you want to clone.
        /// </param>
        /// 
        /// <returns>
        /// A copy of the control in native format.
        /// </returns>
        /// 
        public static T Clone<T>(this T ControlToClone) where T : Control
        {
            PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                    {
                        propInfo.SetValue(instance, propInfo.GetValue(ControlToClone, null), null);
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Takes the strings of an enumeration, adds spaces between capital letters, and provides a list.
        /// </summary>
        /// 
        /// <param name="Enumeration">
        /// The enum that you want readable values for.
        /// </param>
        /// 
        /// <returns>
        /// A list of the enumeration's names separated by spaces where capital
        /// letters occur.
        /// </returns>
        /// 
        public static List<string> GetReadableValues(this Enum Enumeration)
        {
            List<string> readableValues = new List<string>();
            string[] enumValues = Enum.GetNames(Enumeration.GetType());

            foreach (string currValue in enumValues)
            {
                readableValues.Add(currValue.ParseByCapitals());
            }

            return readableValues;
        }

        /// <summary>
        /// Separates a string with camel casing into a string separated by
        /// spaces at the location of each capital letter.
        /// </summary>
        /// 
        /// <param name="Text">
        /// The text to parse.
        /// </param>
        /// 
        /// <returns>
        /// A string separated by spaces at the location of each capital letter.
        /// </returns>
        /// 
        public static string ParseByCapitals(this string Text)
        {
            string newText = "";

            if (!string.IsNullOrEmpty(Text))
            {
                Regex regex = new Regex(@"(?<=[^A-Z])(?=[A-Z]) | (?=[A-Z][^A-Z])",
                                      RegexOptions.IgnorePatternWhitespace);

                newText = regex.Replace(Text, " ").Trim();
            }

            return newText;
        }

        /// <summary>
        /// Creates a list of strings from a string delimited by a specified character.
        /// </summary>
        /// 
        /// <remarks>
        /// The difference in this version is it properly delineates text surrounded by quotes.
        /// If there are no quotes in the original text, the regular Split method is used.
        /// </remarks>
        /// 
        /// <param name="OrigText">
        /// The original string containing the delimited text.
        /// </param>
        /// 
        /// <param name="SplitChar">
        /// The character that is used to separate the individual elements of the original string.
        /// </param>
        /// 
        /// <returns>
        /// A List of strings comprised of the elements in the original.
        /// </returns>
        /// 
        public static List<string> BetterSplit(this string OrigText, char SplitChar)
        {
            List<string> splittedText = new List<string>();

            if (OrigText != "")
            {
                if (OrigText.Contains("\""))
                {
                    int startPos = 0;
                    int currPos = 0;

                    while (currPos < OrigText.Length)
                    {
                        if (OrigText[currPos] == '"')
                        {
                            //  The beginning of quoted text was found.  Find the closing quotes
                            //    while ignoring whether the text between the quotes contains the
                            //    delimiting character.

                            startPos = currPos;
                            currPos++;
                            while (currPos < OrigText.Length && OrigText[currPos] != '"')
                            {
                                currPos++;
                            }
                            splittedText.Add(OrigText.Substring(startPos + 1, currPos - startPos - 1));
                            startPos = currPos + 1;
                        }
                        else if (OrigText[currPos] == SplitChar)
                        {
                            //  No quote character found but an instance of the delimiting character
                            //    was found.  Extract the text starting from the last delimiting 
                            //    character to the current position.

                            if (currPos - startPos > 0)
                            {
                                splittedText.Add(OrigText.Substring(startPos, currPos - startPos));
                            }
                            startPos = currPos + 1;
                        }

                        currPos++;
                    }

                    //  Check for any leftover text.

                    if (currPos - startPos > 0)
                    {
                        splittedText.Add(OrigText.Substring(startPos));
                    }
                }
                else
                {
                    //  Since the text does not contain any quotes use the original Split version.

                    string[] foundStrings = OrigText.Split(new[] { SplitChar }, StringSplitOptions.RemoveEmptyEntries);
                    splittedText.AddRange(foundStrings);
                }
            }

            return splittedText;
        }

        /// <summary>
        /// Converts the list to a string containing the values separated by a comma.
        /// </summary>
        /// 
        /// <param name="CSVList">
        /// The list to convert.
        /// </param>
        /// 
        /// <returns>
        /// A string containing the values of the list separated by a comma.
        /// </returns>
        /// 
        public static string ToCommaDelimitedString(this List<string> CSVList)
        {
            StringBuilder newString = new StringBuilder();

            if (CSVList.Count > 0)
            {
                int index = 0;

                bool containsComma;
                if (CSVList.Count > 1)
                {
                    for (; index < CSVList.Count - 1; index++)
                    {
                        //  If the list item contains a comma, the text will need to be surrounded
                        //    by quotes so that it can import properly.

                        containsComma = CSVList[index].Contains(",");
                        newString.Append((containsComma ? "\"" : "") + CSVList[index] + (containsComma ? "\"" : "") + ",");
                    }
                }

                //  Include the last string without adding a comma.

                containsComma = CSVList[index].Contains(",");
                newString.Append((containsComma ? "\"" : "") + CSVList[index] + (containsComma ? "\"" : ""));
            }

            return newString.ToString();
        }

        /// <summary>
        /// Returns true if the specified text contains one of the characters in a list.
        /// </summary>
        /// 
        /// <param name="OrigText">
        /// The text to search.
        /// </param>
        /// 
        /// <param name="PossibleChars">
        /// The characters to find within the text.
        /// </param>
        /// 
        /// <returns>
        /// True if any character from PossibleChars was found and false if none were found in the text.
        /// </returns>
        /// 
        public static bool ContainsCharacter(this string OrigText, IEnumerable<char> PossibleChars)
        {
            bool charFound = false;

            if (PossibleChars != null)
            {
                foreach (char currChar in PossibleChars)
                {
                    if (OrigText.Contains(currChar))
                    {
                        charFound = true;
                        break;
                    }
                }
            }

            return charFound;
        }

        /// <summary>
        /// Locates a control of a specified type through the parent chain of a child control.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the control to find.
        /// </typeparam>
        /// 
        /// <param name="ChildItem">
        /// The base item to find the specified type.
        /// </param>
        /// 
        /// <returns>
        /// The specified type control or null if it couldn't be found.
        /// </returns>
        /// 
        public static T FindParentType<T>(this Control ChildItem) where T : class
        {
            T foundParent = default(T);
            Control parentControl = ChildItem;

            //  Move up the parent chain until the specified type is found.

            while (parentControl != null && !(parentControl is T))
            {
                parentControl = parentControl.Parent;
            }

            if (parentControl != null)
            {
                foundParent = parentControl as T;
            }

            return foundParent;
        }

        /// <summary>
        /// Converts the elements of a list into columns and rows of a DataTable.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the elements of the specified list.
        /// </typeparam>
        /// 
        /// <param name="DataList">
        /// The list containing elements to convert to a DataTable.
        /// </param>
        /// 
        /// <returns>
        /// The DataTable converted from the elements of the specified list.
        /// </returns>
        /// 
        public static DataTable ConvertToDataTable<T>(this IList<T> DataList)
        {
            return ConvertToDataTable(DataList, new List<string>());
        }

        /// <summary>
        /// Converts the elements of a list into columns and rows of a DataTable.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the elements of the specified list.
        /// </typeparam>
        /// 
        /// <param name="DataList">
        /// The list containing elements to convert to a DataTable.
        /// </param>
        /// 
        /// <param name="ExcludedProperties">
        /// A list of property names to exclude from the DataTable output.
        /// </param>
        /// 
        /// <returns>
        /// The DataTable converted from the elements of the specified list.
        /// </returns>
        /// 
        public static DataTable ConvertToDataTable<T>(this IList<T> DataList, List<string> ExcludedProperties)
        {
            DataTable table = new DataTable();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            //  Create a column for each property of the T type.

            foreach (PropertyDescriptor prop in properties)
            {
                if (!ExcludedProperties.Contains(prop.Name))
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }

            //  Add a row to the DataTable for each element in the List.

            foreach (T item in DataList)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (table.Columns.Contains(prop.Name))
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}