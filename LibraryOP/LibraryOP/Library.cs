using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOP
{
    public class Library
    { 
        public List<User> Users { get; set; }
        public List<LibraryItem> Items { get; set; }

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
                //TODO: throw exception #1
            }
        }
        public void RentItem(int id, int userid)
        {
            var item = this.Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.RentedById = userid;
                item.IsRented = true;
            }
            else
            {
                //TODO: throw exception #2
            }
        }
        public void ReturnItem(int id)
        {
            var item=Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.RentedById = null;
                item.IsRented = false;
            }
            else
            {
                //TODO: throw exception #3
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
                //TODO: throw exception #3
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

        public void SaveDb()
        {
            DBHandler.WriteDb((List<Book>)Items.Where(x => x.GetType() == typeof(Book)));
            DBHandler.WriteDb((List<Movie>)Items.Where(x => x.GetType() == typeof(Movie)));
            DBHandler.WriteDb((List<Magazine>)Items.Where(x => x.GetType() == typeof(Magazine)));
            DBHandler.WriteDb((List<ScientificPaper>)Items.Where(x => x.GetType() == typeof(ScientificPaper)));
            DBHandler.WriteDb((List<User>)Items.Where(x => x.GetType() == typeof(User)));
        }
    }
}
