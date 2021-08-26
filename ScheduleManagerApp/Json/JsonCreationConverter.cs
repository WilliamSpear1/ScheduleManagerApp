using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagerApp.Json
{
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
        //Makes use of the abstract method in CalendarItemJsonConverter
        protected abstract T Create(Type objectType, JObject jObject);
        //---------------------------------------------------------------
        //Rest of file is used for create 
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            if (serializer == null) throw new ArgumentNullException("serializer");
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            T target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

