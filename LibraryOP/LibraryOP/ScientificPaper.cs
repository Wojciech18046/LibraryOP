using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    public class ScientificPaper : LibraryItem, IPublication
    {
        public string ScienceField { get; }
        public string Journal { get; }
        public int PageCount { get; }
        public string Author { get; }
        public ScientificPaper(int id, int barCode, string name, string scienceField, string journal, int count, string autor) : base(id, barCode, name)
        {
            ScienceField = scienceField;
            Journal = journal;
            this.PageCount = count;
            this.Author = autor;
        }
    }
}
