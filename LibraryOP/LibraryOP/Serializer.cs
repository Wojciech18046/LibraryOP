using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LibraryOP
{
    internal class Serializer<T> : ISerializer<T>
    {
        public T Deserialize(string content)
        {
            return JsonSerializer.Deserialize<T>(content);
        }
        public string Serialize(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
