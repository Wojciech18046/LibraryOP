using System;

namespace LibraryOP
{
    public abstract class LibraryItem : ILibraryObject
    {
        public int Id { get; set; }
        public int BarCode { get; set; }
        public string Name { get; set; }
        public bool IsRented { get; set; }
        public int? RentedById { get; set; }

        public LibraryItem() { }
        public LibraryItem(int id, int barCode, string name)
        {
            this.Id = id;
            this.BarCode = barCode;
            this.Name = name;
            this.IsRented = false;
            this.RentedById = null;
        }
    }
}
