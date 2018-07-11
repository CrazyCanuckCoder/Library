using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>
    /// Determines if a specification does not meet a criteria.
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
    public class NotSpecification<T> : ISpecification<T>
    {
        public NotSpecification(ISpecification<T> Spec)
        {
            if (Spec == null)
            {
                throw new ArgumentNullException("Spec");
            }

            this._wrapped = Spec;
        }

        private readonly ISpecification<T> _wrapped;

        protected ISpecification<T> Wrapped
        {
            get
            {
                return this._wrapped;
            }
        }

        public bool IsSatisfiedBy(T Candidate)
        {
            return !Wrapped.IsSatisfiedBy(Candidate);
        }
    }
}
