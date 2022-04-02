using System.Collections.Generic;
using System.Linq;

namespace Autransoft.MockService.Lib.Extensions
{
    internal static class EnumerableExtencion
    {
        internal static bool ContainsAllComponents(this IEnumerable<string> source, IEnumerable<string> target)
        {
            var list = source.ToList();

            if (source.Count() != target.Count())
                return false;

            foreach (var item in target)
            {
                if (!list.Contains(item))
                    return false;
            }

            return true;
        }
    }
}