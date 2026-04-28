using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Utils
{
    internal class Compare
    {
        /// <summary>
        /// Compares two objects of the same type by serializing them to JSON.
        /// Works for nested objects, lists, and primitives.
        /// </summary>
        public static bool AreEqual<T>(T obj1, T obj2)
        {
            // Handle nulls
            if (obj1 == null && obj2 == null) return true;
            if (obj1 == null || obj2 == null) return false;

            var json1 = JsonConvert.SerializeObject(obj1);
            var json2 = JsonConvert.SerializeObject(obj2);

            return json1 == json2;
        }
    }
}
