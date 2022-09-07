
namespace SNMedicTreatment.Extensions
{
    public static class StringExtension
    {
        public static string IsNullOrEmpty(this string source, string replace)
        {
            return string.IsNullOrEmpty(source) ? replace : source;
        }
    }
}
