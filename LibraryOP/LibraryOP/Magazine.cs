using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    public class Magazine : LibraryItem, IPublication
    {

        public string Subject { get; }
        public int PageCount { get; }
        public string Author { get; }
        public Magazine(int id, int barCode, string name, string subject, int count, string autor) : base(id, barCode, name)
        {
            Subject = subject;
            this.PageCount = count;
            this.Author = autor;
        }
    }
}
