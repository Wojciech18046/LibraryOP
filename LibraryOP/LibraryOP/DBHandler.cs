using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    public static class DBHandler
    {
        private const string BookDBName = "Books.json";
        private const string MovieDBName = "Movies.json";
        private const string MagazineDBName = "Magazines.json";
        private const string ScientificPaperDBName = "ScientificPapers.json";
        private const string UserDBName = "Users.json";

        public List<T> ReadDb<T>()
            where T : LibraryItem
        {
            var list = new List<T>();

            

        }
    }
}
