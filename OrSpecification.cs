using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>
    /// Determines if one specification or another meets a specified criteria.
    /// </summary>
    /// 
    /// <remarks>
    /// See the remarks of the AndSpecification for information about the
    /// Specification Design Pattern.
    /// </remarks>
    /// 
    /// <typeparam name="T">
    /// The class type of the specification classes.
    /// </typeparam>
    /// 
    public class OrSpecification<T> : ISpecification<T>
    {
        public OrSpecification(ISpecification<T> Spec1, ISpecification<T> Spec2)
        {
            if (Spec1 == null)
                throw new ArgumentNullException("Spec1");

            if (Spec2 == null)
                throw new ArgumentNullException("Spec2");

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
            return this.Spec1.IsSatisfiedBy(Candidate) || this.Spec2.IsSatisfiedBy(Candidate);
        }
    }
}
