using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    public class Magazine : LibraryItem, IPublication
    {

        public string Subject { get; set; }
        public int PageCount { get; set; }
        public string Author { get; set; }

        public Magazine() { }
        public Magazine(int id, int barCode, string name, string subject, int count, string autor) : base(id, barCode, name)
        {
            Subject = subject;
            this.PageCount = count;
            this.Author = autor;
        }
    }
}
