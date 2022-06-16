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
        public void AddItem(LibraryItem item)
        {
            this.Items.Add(item);
            //TODO: Add save to DB #1
        }
        public void RemoveItem(int id)
        {
            var item = this.Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Items.Remove(item);
                //TODO: Remove from DB #1
            }
            else
            {
                throw new InvalidOperationException("Nieprawidlowy ID lub ta pozycja nie istnieje...");
            }
        }
        public void RentItem(int id, int userid)//added check for user existing
        {
            var item = this.Items.FirstOrDefault(x => x.Id == id);
            var user = this.Users.FirstOrDefault(y => y.Id == userid);
            if (item != null && user != null)
            {
                item.RentedById = userid;
                item.IsRented = true;
            }
            else
            {
                throw new InvalidOperationException("Nieprawidlowy ID przedmiotu/uzytkownikow lub ta pozycja nie istnieje...");
            }
        }
        public void ReturnItem(int id)
        {
            var item=Items.FirstOrDefault(x => x.Id == id);
            if (item != null && item.IsRented != false)//lite security that its not misstake
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
            foreach(var item in Items)
            {
            
                if(item is Movie)
                {
                    var movie = (Movie)item;
                    Console.WriteLine("Movie:");
                    Console.WriteLine($"Director: {movie.Director} | Genre: {movie.Genre} | Duration: {movie.Duration}min");
                }
                else if(item is Magazine)
                {
                    var magazine = (Magazine)item;
                    Console.WriteLine("Magazine:");
                    Console.WriteLine($"Subject: {magazine.Subject}");
                }
                else if(item is Book)
                {
                    var book = (Book)item;
                    Console.WriteLine("Book:");
                    Console.WriteLine($"Genre: {book.Genre}");
                }
                else if(item is ScientificPaper)
                {
                    var scientificPaper = (ScientificPaper)item;
                    Console.WriteLine("ScientificPaper:");
                    Console.WriteLine($"ScienceField: {scientificPaper.ScienceField} | Journal: {scientificPaper.Journal}");
                }
            Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Available: {!item.IsRented} | Rented By (ID): {item.RentedById} | BarCode: {item.BarCode}");
            Console.WriteLine("--------------------------------------------------------------------");
            }
        }
        public void AddUser(User user)
        {
            this.Users.Add(user);
            //TODO: Add save to DB #2
        }
        public void RemoveUser(int id)
        {
            var user = this.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                Users.Remove(user);
                //TODO: Remove from DB #2
            }
            else
            {
                throw new InvalidOperationException("Nieprawidlowy ID lub ten uzytkownik nie istnieje...");
            }
        }
        public void ListUsers()
        {
            foreach(var user in Users)
            {
                Console.WriteLine($"ID: {user.Id} | Name: {user.Name} | Email: {user.Email}");
                Console.WriteLine($"Address: {user.Address}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}
