using System;

namespace LibraryOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Menu.RunMenu(library);
        }


    }
}
