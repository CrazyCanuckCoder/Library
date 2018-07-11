using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>
    /// Code to determine if two specifications are satisfied by a condition.
    /// </summary>
    /// 
    /// <remarks>
    /// This class and the NotSpecification and OrSpecification classes are based
    /// on the Specification Design Pattern.  For details about the pattern see
    /// the Wikipedia article: https://en.wikipedia.org/wiki/Specification_pattern
    /// and this PDF file: http://www.martinfowler.com/apsupp/spec.pdf.
    /// 
    /// According to the wikipedia article: "...the specification pattern is a 
    /// particular software design pattern, whereby business rules can be 
    /// recombined by chaining the business rules together using boolean logic."
    /// </remarks>
    /// 
    /// <typeparam name="T">
    /// The class type of the specification classes.
    /// </typeparam>
    /// 
    public class AndSpecification<T> : ISpecification<T>
    {
        public AndSpecification(ISpecification<T> Spec1, ISpecification<T> Spec2)
        {
            if (Spec1 == null)
            {
                throw new ArgumentNullException("Spec1");
            }

            if (Spec2 == null)
            {
                throw new ArgumentNullException("Spec2");
            }

            this._spec1 = Spec1;
            this._spec2 = Spec2;
        }

        private readonly ISpecification<T> _spec1;
        private readonly ISpecification<T> _spec2;

        protected ISpecification<T> Spec1
        {
            get
            {
                return this._spec1;
            }
        }

        protected ISpecification<T> Spec2
        {
            get
            {
                return this._spec2;
            }
        }

        public bool IsSatisfiedBy(T Candidate)
        {
            return Spec1.IsSatisfiedBy(Candidate) && Spec2.IsSatisfiedBy(Candidate);
        }
    }
}
