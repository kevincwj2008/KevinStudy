using Newtonsoft.Json;
using System;
using XFCompany.CIPNet.GlobalSetting;

namespace XFCompany.CIPnetWeb.LogicModel
{
    public class ResourceStatusConvert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(EnumResourceStatus))
                return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue(Helper.GetUIText((EnumResourceStatus)value));
        }
    }
}
