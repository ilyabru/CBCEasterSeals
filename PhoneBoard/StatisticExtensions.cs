using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBoard
{
    public static class StatisticExtensions
    {
        // sum all TimeSpan values in an array
        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
        {
            return source.Select(selector).Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);
        }
    }
}
