using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore_HW3.Extensions
{
    public static  class GetByNContainerExtension
    {
        // Listeyi n girdisi kadar kümelemek için oluşturulmuş extension metot
        public static List<List<T>> partition<T>(this List<T> values, int chunkSize)
        {
            return values.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
