using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Faker.Core.Extensions.Json {
    public abstract class JsonRequest : IRequest
    {
        protected JsonRequest(IReadOnlyDictionary<string, string> metadata)
        {
            Metadata = metadata;
        }

        public static JsonRequest Create(string json, IReadOnlyDictionary<string, string> metadata)
        {
            try
            {
                var container = JToken.Parse(json);
                
                switch (container.Type)
                {
                    case JTokenType.Array:
                        return new JsonArrayRequest(json, JArray.Parse(json), metadata);
                    case JTokenType.Object:
                        return new JsonObjectRequest(json, JObject.Parse(json), metadata);
                    default:
                        throw new ArgumentException("invalid json type", nameof(json));
                }
            } catch (Exception e)
            {
                throw new ArgumentException("invalid json type", nameof(json));
            }
            
        }

        public abstract string GetPropertyValueBy(string path);
        public abstract string GetPropertyValueBy(int index);
        public abstract IEnumerable<string> GetProperties();
        public string RawContent { get; protected set; }
        public IReadOnlyDictionary<string, string> Metadata { get; set; }
    }
}