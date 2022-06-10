using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOP
{
    public class Library
    {
        //TODO: add class user
        //public List<User> Users { get; }
        //public User UserId;
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
                    Console.WriteLine("Movie:");
                    Console.WriteLine($"Director: {item.Director} | Genre: {item.Genre} | Duration: {item.Duration}min");
                }
                else if(item is Magazine)
                {
                    Console.WriteLine("Magazine:");
                    Console.WriteLine($"Subject: {item.Subject}");
                }
                else if(item is Book)
                {
                    Console.WriteLine("Book:");
                    Console.WriteLine($"Genre: {item.Genre}");
                }
                else if(item is ScientificPaper)
                {
                    Console.WriteLine("ScientificPaper:");
                    Console.WriteLine(value: $"ScienceField: {item.ScienceField} | Journal: {item.Journal}");
                }
            Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Available: {!item.IsRented} | Rented By (ID): {item.RentedById} | BarCode: {item.BarCode}");
            Console.WriteLine("--------------------------------------------------------------------");
            }
        }
        public void AddUser(User user)
        {
            this.Items.Add(item);
            //TODO: Add save to DB #2
        }
        public void RemoveUser(int id)
        {
            var user = this.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                Items.Remove(user);
                //TODO: Remove from DB #2
            }
            else
            {
                //TODO: throw exception #3
            }
        }
        public void ListUsers()
        {

        }
    }
}
