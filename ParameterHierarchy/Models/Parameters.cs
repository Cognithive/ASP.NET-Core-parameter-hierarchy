namespace ParameterHierarchy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Parameters
    {
        protected IDictionary<string, object> Data { get; } = new Dictionary<string, object>();

        public override string ToString()
        {
            var denormalised = Data.SelectMany(Flatten);
            var converted = denormalised.Select(ConvertPair);
            var joined = string.Join('&', converted);
            var prefixed = string.Concat("?", joined);

            return prefixed;
        }

        private static IEnumerable<KeyValuePair<string, object>> Flatten(KeyValuePair<string, object> pair)
        {
            if (pair.Value is IEnumerable enumerableValue)
            {
                foreach (var item in enumerableValue)
                {
                    yield return new KeyValuePair<string, object>(pair.Key, item);
                }
            }
            else
            {
                yield return pair;
            }
        }

        private static string ConvertPair(KeyValuePair<string, object> kv)
        {
            return string.Join('=', new[] { kv.Key, ConvertValue(kv.Value) });
        }

        private static string ConvertValue(object value)
        {
            return value.ToString();
        }
    }
}
