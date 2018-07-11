using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Library;

namespace Library.Tests
{
    [TestFixture]
    public class SpecificationTests
    {
        // Define some private classes used by these tests.

        private interface IBoolSpecification
        {
            bool Value { get; }
        }

        private class TrueSpecification : IBoolSpecification
        {
            public bool Value
            {
                get
                {
                    return true;
                }
            }
        }

        private class FalseSpecification : IBoolSpecification
        {
            public bool Value
            {
                get
                {
                    return false;
                }
            }
        }

        private class TrueBoolSpecification : ISpecification<IBoolSpecification>
        {
            public bool IsSatisfiedBy(IBoolSpecification Candidate)
            {
                return Candidate.Value == true;
            }
        }


        #region  AndSpecification Tests

        [Test]
        public void AndSpecification_ThrowsException_ForFirstNullParameter()
        {
            Assert.Throws<ArgumentNullException>(delegate { new AndSpecification<IBoolSpecification>(null, new TrueBoolSpecification()); }, "Null first parameter did not throw exception.");
        }

        [Test]
        public void AndSpecification_ThrowsException_ForSecondNullParameter()
        {
            Assert.Throws<ArgumentNullException>(delegate { new AndSpecification<IBoolSpecification>(new TrueBoolSpecification(), null); }, "Null second parameter did not throw exception.");
        }

        [Test]
        public void AndSpecification_ReturnsFalse_ForFalseSpec()
        {
            FalseSpecification falseSpec = new FalseSpecification();
            TrueBoolSpecification trueBoolSpec = new TrueBoolSpecification();

            AndSpecification<IBoolSpecification> andSpec = new AndSpecification<IBoolSpecification>(trueBoolSpec, trueBoolSpec);

            Assert.IsFalse(andSpec.IsSatisfiedBy(falseSpec), "AndSpecification returned true for false bool value.");
        }

        [Test]
        public void AndSpecification_ReturnsTrue_ForTrueSpec()
        {
            TrueSpecification trueSpec = new TrueSpecification();
            TrueBoolSpecification trueBoolSpec = new TrueBoolSpecification();

            AndSpecification<IBoolSpecification> andSpec = new AndSpecification<IBoolSpecification>(trueBoolSpec, trueBoolSpec);

            Assert.IsTrue(andSpec.IsSatisfiedBy(trueSpec), "AndSpecification returned false for true bool value.");

        }

        #endregion  AndSpecification Tests
    }
}
