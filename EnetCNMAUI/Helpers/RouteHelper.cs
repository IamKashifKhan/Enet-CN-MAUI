using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Helpers
{
    public static class RouteHelper
    {
        /// <summary>
        /// Builds a Shell route with properly escaped query parameters.
        /// </summary>
        /// <param name="pageName">The target page class name</param>
        /// <param name="parameters">Dictionary of key/value pairs to append</param>
        /// <returns>Escaped route string</returns>
        public static string BuildRoute(string pageName, IDictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return pageName;

            var query = string.Join("&",
                parameters.Select(kvp =>
                    $"{kvp.Key}={Uri.EscapeDataString(kvp.Value ?? string.Empty)}"));

            return $"{pageName}?{query}";
        }
    }
}
