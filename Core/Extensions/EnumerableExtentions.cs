using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class EnumerableExtentions
    {
        public static IEnumerable<Tresult> SelectWithPreviousElement<Tsource, Tresult>(this IEnumerable<Tsource> source, Func<Tsource, Tsource, Tresult> projection)
        {
            using (var iterator = source.GetEnumerator())
            {
                Tsource previous = default;
                while (iterator.MoveNext())
                {
                    yield return projection(previous, iterator.Current);
                    previous = iterator.Current;
                }

            }
        }
    }
}
