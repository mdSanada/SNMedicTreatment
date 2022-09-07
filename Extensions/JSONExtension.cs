using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace SNMedicTreatment.Extensions
{
    public static class JSONExtension
    {
        public static string ToJson<T>(this T self, JsonSerializerSettings? converter = null)
        {
            return JsonConvert.SerializeObject(self, converter ?? Converter.Settings);
        }

        public static T FromJson<T>(this T self,string json, JsonSerializerSettings? converter = null)
        {
            return JsonConvert.DeserializeObject<T>(json, converter ?? Converter.Settings);
        }
    }


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
