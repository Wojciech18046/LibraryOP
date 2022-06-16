using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryOP
{
    public static class DBHandler
    {
        private const string _bookDBName = "Books.json";
        private const string _movieDBName = "Movies.json";
        private const string _magazineDBName = "Magazines.json";
        private const string _scientificPaperDBName = "ScientificPapers.json";
        private const string _userDBName = "Users.json";

        public static List<T> ReadDb<T>()
            where T : ILibraryObject
        {
            var list = new List<T>();

            if (typeof(T) == typeof(Book))
            {
                ReadType(list, _bookDBName);
            }
            else if (typeof(T) == typeof(Movie))
            {
                ReadType(list, _movieDBName);
            }
            else if (typeof(T) == typeof(Magazine))
            {
                ReadType(list, _magazineDBName);
            }
            else if (typeof(T) == typeof(ScientificPaper))
            {
                ReadType(list, _scientificPaperDBName);
            }
            else if (typeof(T) == typeof(User))
            {
                ReadType(list, _userDBName);
            }
            else
            {
                throw new Exception("Nierozpoznany typ danych");
            }

            return list;
        }

        public static void WriteDb<T>(List<T> list)
        {
            if (typeof(T) == typeof(Book))
            {
                WriteType(list, _bookDBName);
            }
            else if (typeof(T) == typeof(Movie))
            {
                WriteType(list, _movieDBName);
            }
            else if (typeof(T) == typeof(Magazine))
            {
                WriteType(list, _magazineDBName);
            }
            else if (typeof(T) == typeof(ScientificPaper))
            {
                WriteType(list, _scientificPaperDBName);
            }
            else if (typeof(T) == typeof(User))
            {
                WriteType(list, _userDBName);
            }
            else
            {
                throw new Exception("Nierozpoznany typ danych");
            }
        }

        private static void ReadType<T>(List<T> list, string path)
        {
            var serializer = new Serializer<T>();

            using (var streamReader = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
            {
                foreach (var item in streamReader.ReadToEnd().Split(';'))
                {
                    list.Add(serializer.Deserialize(item));
                }
            }
        }

        private static void WriteType<T>(List<T> list, string path)
        {
            var serializer = new Serializer<T>();

            using (var streamWriter = new StreamWriter(new FileStream(_bookDBName, FileMode.OpenOrCreate)))
            {
                foreach (var item in list)
                {
                    streamWriter.Write(serializer.Serialize(item));
                    streamWriter.Write(';');
                    streamWriter.Write(Environment.NewLine);
                }
            }
        }
    }
}
