using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject
{
    public class EFNavigationPropertyConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            bool isValid = false;

            if (objectType.FullName == "System.Data.EntityKey")
                isValid = true;

            if (objectType.IsGenericType &&
                objectType.GetGenericTypeDefinition().FullName
                .Contains("System.Data.Objects.DataClasses.EntityCollection"))
            {
                isValid = true;
            }

            return isValid;
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }
    }
}