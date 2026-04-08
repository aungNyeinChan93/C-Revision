using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto_07_JSON
{
    public static class DevCode
    {
        // object to jsonStr
        public static string Encode(this object obj)
        {
           return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        // jsonStr to object
        public static T? Decode<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
