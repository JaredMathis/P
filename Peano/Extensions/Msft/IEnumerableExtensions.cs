using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano.Extensions.Msft
{
    public static class IEnumerableExtensions
    {
        public static T Second<T>(this IEnumerable<T> t)
        {
            return t.ElementAt(1);
        }
        public static IEnumerable<int> Indices<T>(this IEnumerable<T> t)
        {
            return Enumerable.Range(0, t.Count());
        }

        public static IEnumerable<T> ReplaceAt<T>(this IEnumerable<T> t, int index, T replacement)
        {
            foreach (var i in t.Indices())
            {
                if (i == index)
                {
                    yield return replacement;
                }
                else
                {
                    yield return t.ElementAt(i);
                }
            }
        }

        
    }
}
