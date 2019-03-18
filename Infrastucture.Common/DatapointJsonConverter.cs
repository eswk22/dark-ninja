using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.Common
{
    public class DatapointJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize(reader, objectType);
            }
            return new decimal[] { decimal.Parse(reader.Value.ToString()) };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
