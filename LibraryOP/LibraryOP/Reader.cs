using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LibraryOP
{
    public class Reader<T>
    {
        public string File { get; }
        public Serializer<T> _serializer;

        public Reader() { }

        public Reader(string fileName)
        {
            File = fileName;
            _serializer = new Serializer<T>();
        }
        public T Read()
        {
            using (StreamReader sr = new StreamReader(File))
            {
                return _serializer.Deserialize(sr.ReadToEnd());
            }
        }
    }
}
