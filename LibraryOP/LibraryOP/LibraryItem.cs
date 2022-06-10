using System;

namespace LibraryOP
{
    public abstract class LibraryItem
    {
        public int Id { get; }
        public int BarCode { get; }
        public string Name { get; }
        public bool IsRented { get; set; }
        public int? RentedById { get; set; }
        public LibraryItem(int barCode, string name)
        {
            //TODO: add logic to generate ID
            //this.Id = GenerateId(); 
            this.BarCode = barCode;
            this.Name = name;
            this.IsRented = false;
            this.RentedById = null;
        }

        void Delete()
        {
            //TODO: add method body
            throw new NotImplementedException();
        }
    }
}
