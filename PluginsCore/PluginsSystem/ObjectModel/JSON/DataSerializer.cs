using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;

namespace PluginsCore.JSON
{
    public static class DataSerializer
    {
        public static string SerializeJSON(object obj)
        {
            string result = string.Empty;
            if (obj == null)
                throw new Exception("obj is null");

            Type objType = obj.GetType();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(objType);

            using (MemoryStream st = new MemoryStream())
            {
                serializer.WriteObject(st, obj);
                st.Position = 0;
                byte[] buffer = new byte[(int)st.Length];

                int readBytes = st.Read(buffer, 0, (int)st.Length);
                result = Encoding.UTF8.GetString(buffer);
            }
            return result;
        }

        /// <summary>
        /// Создает объект из строки XML.
        /// </summary>
        /// <param name="text">Строка XML, в которой описаны свойства объекта.</param>
        /// <returns></returns>
        public static T GetInstanceJSON<T>(string text)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            T obj = jsSerializer.Deserialize<T>(text);
            return obj;
        }
    }
}
