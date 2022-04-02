using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Autransoft.MockService.Lib.Extensions
{
    internal static class DictionaryExtension
    {
        internal static bool ContainsAllComponents(this IDictionary<string, string> source, IHeaderDictionary target)
        {
            if (source.Count == 0)
                return true;

            foreach (var key in source.Keys)
            {
                if (!target.Keys.Contains(key.Trim().ToUpper()))
                    return false;

                if (source[key] != target[key].ToString().Trim().ToUpper())
                    return false;
            }

            return true;
        }
    }
}