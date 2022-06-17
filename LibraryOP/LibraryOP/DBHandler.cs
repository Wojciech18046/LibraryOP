using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryOP
{
    public static class DBHandler
    {
        private const string _bookDBName = "../../../Books.json";
        private const string _movieDBName = "../../../Movies.json";
        private const string _magazineDBName = "../../../Magazines.json";
        private const string _scientificPaperDBName = "../../../ScientificPapers.json";
        private const string _userDBName = "../../../Users.json";

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

        public static void WriteDb<T>(IEnumerable<ILibraryObject> libraryObjectCollection)
        {
            if (typeof(T) == typeof(Book))
            {
                var list = new List<Book>();

                foreach (var libraryObject in libraryObjectCollection)
                {
                    list.Add((Book)(LibraryItem)libraryObject);
                }

                WriteType<Book>(list, _bookDBName);
            }
            else if (typeof(T) == typeof(Movie))
            {
                var list = new List<Movie>();

                foreach (var libraryObject in libraryObjectCollection)
                {
                    list.Add((Movie)(LibraryItem)libraryObject);
                }

                WriteType<Movie>(list, _movieDBName);
                //WriteType<Movie>(RewriteCollectionAsList<Movie>(libraryObjectCollection), _movieDBName);
            }
            else if (typeof(T) == typeof(Magazine))
            {
                var list = new List<Magazine>();

                foreach (var libraryObject in libraryObjectCollection)
                {
                    list.Add((Magazine)(LibraryItem)libraryObject);
                }

                WriteType<Magazine>(list, _magazineDBName);
                //WriteType<Magazine>(RewriteCollectionAsList<Magazine>(libraryObjectCollection), _magazineDBName);
            }
            else if (typeof(T) == typeof(ScientificPaper))
            {
                var list = new List<ScientificPaper>();

                foreach (var libraryObject in libraryObjectCollection)
                {
                    list.Add((ScientificPaper)(LibraryItem)libraryObject);
                }

                WriteType<ScientificPaper>(list, _scientificPaperDBName);
                //WriteType<ScientificPaper>(RewriteCollectionAsList<ScientificPaper>(libraryObjectCollection), _scientificPaperDBName);
            }
            else if (typeof(T) == typeof(User))
            {
                var list = new List<User>();

                foreach (var libraryObject in libraryObjectCollection)
                {
                    list.Add((User)(User)libraryObject);
                }

                WriteType<User>(list, _userDBName);
                //WriteType<User>(RewriteCollectionAsList<User>(libraryObjectCollection), _userDBName);
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
                    if (!String.IsNullOrWhiteSpace(item))
                    {
                        list.Add(serializer.Deserialize(item));
                    }
                }
            }
        }

        private static void WriteType<T>(List<T> list, string path)
        {
            var serializer = new Serializer<T>();

            using (var streamWriter = new StreamWriter(path))
            {
                foreach (var item in list)
                {
                    streamWriter.Write(serializer.Serialize(item));
                    streamWriter.Write(';');
                    streamWriter.Write(Environment.NewLine);
                }
                streamWriter.Flush();
            }
        }
    }
}
