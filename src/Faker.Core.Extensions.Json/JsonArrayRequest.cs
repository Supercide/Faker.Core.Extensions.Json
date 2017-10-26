using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Faker.Core.Extensions.Json {
    public class JsonArrayRequest : JsonRequest
    {
        private readonly JArray _jArray;

        public JsonArrayRequest(string raw, JArray jArray, IReadOnlyDictionary<string, string> metadata): base(metadata)
        {
            RawContent = raw;

            _jArray = jArray;
        }

        public override string GetPropertyValueBy(string path)
        {
            return GetPropertyValueBy(int.Parse(path));
        }

        public override string GetPropertyValueBy(int index)
        {
            string value = null;

            if(index < _jArray.Count)
            {
                value = _jArray[index].Value<string>();
            }
            
            return value;
        }

        public override IEnumerable<string> GetProperties()
        {
            return Enumerable.Range(0, _jArray.Count).Select(index => $"{index}");
        }
    }
}