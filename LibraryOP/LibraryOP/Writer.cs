using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LibraryOP
{
    public class Writer<T>
    {
        public string File { get; set; }
        public Serializer<T> _serializer;
        public Writer() { }
        public Writer(string fileName)
        {
            File = fileName;
            _serializer = new Serializer<T>();
        }
        public void Write(T item)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(File, FileMode.OpenOrCreate)))
            {
                sw.Write(_serializer.Serialize(item));
            }
        }



    }
}
