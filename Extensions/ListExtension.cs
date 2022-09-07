using System.Collections.Generic;
using System.Linq;

namespace SNMedicTreatment.Extensions
{
    public static class ListExtension
    {
        public static List<List<T>> Split<T>(this List<T> source, int length)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / length)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
