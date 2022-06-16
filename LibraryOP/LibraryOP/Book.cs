using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    public class Book : LibraryItem, IPublication
    {

        public string Genre { get; }
        public int PageCount { get; }
        public string Author { get; }
        public Book(int id, int barCode, string name, string genre, int count, string autor) : base(id, barCode, name)
        {
            Genre = genre;
            this.PageCount = count;
            this.Author = autor;
        }
    }
}
