using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    public class Book : LibraryItem, IPublication
    {

        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string Author { get; set; }

        public Book() { }
        public Book(int id, int barCode, string name, string genre, int count, string autor) : base(id, barCode, name)
        {
            Genre = genre;
            this.PageCount = count;
            this.Author = autor;
        }
    }
}
