using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConnectNow.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConnectNow.Helpers.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<ApiResult<T>> ToServiceResult<T>(this HttpResponseMessage response)
        {
            try
            {
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                // First, try to deserialize the envelope as-is.
                var settings = new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Include // we’ll handle nulls by merging below
                };

                var result = JsonConvert.DeserializeObject<ApiResult<T>>(json, settings)
                             ?? new ApiResult<T>(false, "Empty response.", CreateDefault<T>());

                // If there's no data, try to supply defaults.
                if (IsNullOrDefault(result.Data))
                {
                    // Try to extract the "data" token & merge onto a default instance
                    var defaultInstance = CreateDefault<T>();
                    var root = TryParse(json);

                    var dataToken = (root as JObject)?["data"];
                    if (dataToken != null && dataToken.Type != JTokenType.Null)
                    {
                        // Merge onto defaults, but DO NOT override with nulls
                        JsonConvert.PopulateObject(
                            dataToken.ToString(),
                            defaultInstance!,
                            new JsonSerializerSettings
                            {
                                MissingMemberHandling = MissingMemberHandling.Ignore,
                                NullValueHandling = NullValueHandling.Ignore // <- keep defaults if server sends null
                            });
                    }

                    result.Data = defaultInstance!;
                }
                else
                {
                    // Data exists; still merge onto a fresh default to lift property-level defaults
                    // and avoid nulls inside nested objects if server omitted them.
                    var defaults = CreateDefault<T>();
                    var dataClone = JToken.FromObject(result.Data!);

                    // Merge user data onto defaults (nulls/omissions in data won’t nuke defaults)
                    JsonConvert.PopulateObject(
                        dataClone.ToString(),
                        defaults!,
                        new JsonSerializerSettings
                        {
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore
                        });

                    result.Data = defaults!;
                }

                return result;
            }
            catch (Exception e)
            {
                return new ApiResult<T>(false, e.Message, CreateDefault<T>());
            }
        }

        // ---------------- helpers ----------------

        private static JToken? TryParse(string json)
        {
            try { return JToken.Parse(json); }
            catch { return null; }
        }

        private static bool IsNullOrDefault<T>(T value)
        {
            if (value == null) return true;
            var t = typeof(T);

            // Value types: compare to default(T)
            if (t.IsValueType) return value.Equals(default(T));

            // Strings: treat empty as default-ish? Keep it as non-default.
            if (value is string s) return false;

            // Collections: treat null only as default; empty is OK (not default).
            return false;
        }

        /// <summary>
        /// Creates a useful default instance for T:
        /// - string -> ""
        /// - arrays -> Array.Empty<TElement>()
        /// - IEnumerable<T> -> new List<T>()
        /// - classes with parameterless ctor -> new()
        /// - value types -> default
        /// </summary>
        private static T CreateDefault<T>()
        {
            var t = typeof(T);

            // string -> ""
            if (t == typeof(string))
                return (T)(object)string.Empty;

            // arrays -> Array.Empty<elem>()
            if (t.IsArray)
            {
                var elemType = t.GetElementType()!;
                var empty = Array.CreateInstance(elemType, 0);
                return (T)(object)empty;
            }

            // IEnumerable<T> -> new List<T>()
            if (typeof(IEnumerable).IsAssignableFrom(t) && t.IsGenericType)
            {
                var genDef = t.GetGenericTypeDefinition();
                var arg = t.GetGenericArguments().FirstOrDefault();

                // If T itself is IEnumerable<U>, produce List<U>
                if (genDef == typeof(IEnumerable<>))
                {
                    var listType = typeof(System.Collections.Generic.List<>).MakeGenericType(arg!);
                    return (T)Activator.CreateInstance(listType)!;
                }
            }

            // classes/records with parameterless ctor
            try
            {
                var instance = Activator.CreateInstance<T>();
                if (instance is not null) return instance;
            }
            catch { /* no-op */ }

            // value types or anything else fallback
            return default!;
        }
    }
}
