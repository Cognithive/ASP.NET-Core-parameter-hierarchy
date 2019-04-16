namespace ParameterHierarchy
{
    using System.Collections.Generic;

    public class Parameters1 : Parameters
    {
        public ICollection<int> Property1
        {
            get
            {
                if (!Data.TryGetValue(nameof(Property1), out var value))
                {
                    value = new List<int>();
                    Data[nameof(Property1)] = value;
                }

                return (ICollection<int>)value;
            }

            set
            {
                if (!(value is List<int> listValue))
                {
                    listValue = new List<int>(value);
                }

                Data[nameof(Property1)] = listValue;
            }
        }
    }
}
