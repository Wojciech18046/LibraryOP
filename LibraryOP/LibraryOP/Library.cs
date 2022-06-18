using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOP
{
    public class Library : ILibrary
    {
        public List<User> Users { get; set; }
        public List<LibraryItem> Items { get; set; }

        public Library()
        {
            Users = new List<User>();
            Items = new List<LibraryItem>();

            Users.AddRange(DBHandler.ReadDb<User>());
            Items.AddRange(DBHandler.ReadDb<Book>());
            Items.AddRange(DBHandler.ReadDb<Movie>());
            Items.AddRange(DBHandler.ReadDb<Magazine>());
            Items.AddRange(DBHandler.ReadDb<ScientificPaper>());
        }

        public void AddItem(LibraryItem item)
        {
            this.Items.Add(item);
        }

        public void RemoveItem(int id)
        {
            var item = this.Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Items.Remove(item);
            }
            else
            {
                throw new InvalidOperationException("Nieprawidlowy ID lub ta pozycja nie istnieje...");
            }
        }

        public void RentItem(int barCode, int userid)//added check for user existing
        {
            var user = this.Users.SingleOrDefault(y => y.Id == userid);

            if (user == null)
            {
                throw new InvalidOperationException("Użytkownik nie istnieje w bazie danych.");
            }

            var itemsToRent = Items.Where(i => i.BarCode == barCode && i.IsRented == false && i.RentedById == null);

            if (itemsToRent.Any())
            {
                var rentItem = itemsToRent.First();
                rentItem.RentedById = userid;
                rentItem.IsRented = true;
            }
            else
            {
                throw new InvalidOperationException("Brak wolnych egzemplarzy lub książka nie istnieje w bazie danych.");
            }
        }

        public void ReturnItem(int id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item != null && item.IsRented == true)//lite security that its not misstake
            {
                item.RentedById = null;
                item.IsRented = false;
            }
            else
            {
                throw new InvalidOperationException("Nieprawidlowy ID lub ta pozycja nie istnieje...");
            }
        }

        public void ListItems()
        {
            foreach (var item in Items.OrderBy(x => x.GetType()))
            {
                if (item is Movie)
                {
                    var movie = (Movie)item;
                    Console.WriteLine("Film:");
                    Console.WriteLine($"Rezyser: {movie.Director} | Gatunek: {movie.Genre} | Czas trwania: {movie.Duration}min");
                }
                else if (item is Magazine)
                {
                    var magazine = (Magazine)item;
                    Console.WriteLine("Magazyn:");
                    Console.WriteLine($"Temat: {magazine.Subject}");
                    Console.WriteLine($"Autor: {magazine.Author}");
                    Console.WriteLine($"Liczba stron: {magazine.PageCount}");
                }
                else if (item is Book)
                {
                    var book = (Book)item;
                    Console.WriteLine("Ksiazka:");
                    Console.WriteLine($"Autor: {book.Author}");
                    Console.WriteLine($"Gatunek: {book.Genre}");
                    Console.WriteLine($"Liczba stron: {book.PageCount}");
                }
                else if (item is ScientificPaper)
                {
                    var scientificPaper = (ScientificPaper)item;
                    Console.WriteLine("Praca naukowa:");
                    Console.WriteLine($"Autor: {scientificPaper.Author}");
                    Console.WriteLine($"Dziedzina: {scientificPaper.ScienceField} | Publikacja: {scientificPaper.Journal}");
                    Console.WriteLine($"Liczba stron: {scientificPaper.PageCount}");
                }
                Console.WriteLine($"ID: {item.Id} | Nazwa: {item.Name} | Dostepnosc: {!item.IsRented} | Wypozyczone przez (ID): {item.RentedById} | Kod Kreskowy: {item.BarCode}");
                Console.WriteLine("--------------------------------------------------------------------");
            }
        }

        public void AddUser(User user)
        {
            this.Users.Add(user);
        }

        public void RemoveUser(int id)
        {
            var user = this.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                Users.Remove(user);
            }
            else
            {
                throw new InvalidOperationException("Nieprawidlowy ID lub ten uzytkownik nie istnieje...");
            }
        }

        public void ListUsers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine($"ID: {user.Id} | Imie: {user.Name} | Email: {user.Email}");
                Console.WriteLine($"Adres: {user.Address}");
                Console.WriteLine("------------------------------");
            }
        }

        public void SaveDb()
        {
            DBHandler.WriteDb<Book>(Items.Where(x => x.GetType() == typeof(Book)));
            DBHandler.WriteDb<Movie>(Items.Where(x => x.GetType() == typeof(Movie)));
            DBHandler.WriteDb<Magazine>(Items.Where(x => x.GetType() == typeof(Magazine)));
            DBHandler.WriteDb<ScientificPaper>(Items.Where(x => x.GetType() == typeof(ScientificPaper)));
            DBHandler.WriteDb<User>(Users.Where(x => x.GetType() == typeof(User)));
        }
    }
}