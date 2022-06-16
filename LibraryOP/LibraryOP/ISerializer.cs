using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    internal interface ISerializer<T>
    {
        string Serialize(T obj);
        T Deserialize(string content);
    }
}
