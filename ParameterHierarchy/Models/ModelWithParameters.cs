namespace ParameterHierarchy
{
    using System;

    public abstract class ModelWithParameters<T> where T : Parameters
    {
        public ModelWithParameters(T p)
        {
            Parameters = p ?? throw new ArgumentNullException(nameof(p));
        }

        public T Parameters { get; private set; }
    }
}
