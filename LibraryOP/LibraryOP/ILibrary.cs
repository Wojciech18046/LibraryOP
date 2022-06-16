using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryOP
{
    public interface ILibrary
    {
        public void AddItem(LibraryItem item);
        public void RemoveItem(int id);
        public void RentItem(int id, int userid);
        public void ReturnItem(int id);
        public void ListItems();
        public void AddUser(User user);
        public void RemoveUser(int id);
        public void ListUsers();
    }
}
