using System;

namespace LibraryOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            
            Console.WriteLine("Witamy w programie LibraryOP.");
            Graphic();
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
            string choice = "0";
            while (choice != "9")
            {
                Library library = new Library();
                MenuOptions();
                choice = Console.ReadLine();
                if (choice == "1")
                {                    
                    Console.WriteLine("1. Dodaj książkę.");
                    Console.WriteLine("2. Dodaj magazyn.");
                    Console.WriteLine("3. Dodaj film.");
                    Console.WriteLine("4. Dodaj magazy6n naukowy.");
                    string addChoice = Console.ReadLine();
                    if (addChoice == "1")
                    {
                        Console.WriteLine("Proszę wprowadzić....... (Do przebudowy)");
                        int barCode = int.Parse(Console.ReadLine()); //TODO: Omowienie generatoru kodu kreskoiwego. 
                        Console.WriteLine("Proszę wprowadzić nazwę.");
                        string name = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić gatunek.");
                        string genre = Console.ReadLine();                        
                        Console.WriteLine("Proszę wprowadzić autora.");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić ilość stron.");
                        if (int.TryParse(Console.ReadLine(), out int count))
                        {
                            Book book = new Book(barCode, name, genre, count, autor);
                            library.AddItem(book);
                        }
                        else
                        {
                            Console.WriteLine("Wprowadzona wartość nie jest numerem stron.");
                        }
                    }
                    else if(addChoice == "2")
                    {
                        Console.WriteLine("Proszę wprowadzić....... (Do przebudowy)");
                        int barCode = int.Parse(Console.ReadLine()); //TODO: Omowienie generatoru kodu kreskoiwego. 
                        Console.WriteLine("Proszę wprowadzić nazwę.");
                        string name = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić temat.");
                        string subject = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić autora.");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić ilość stron.");
                        if (int.TryParse(Console.ReadLine(), out int count))
                        {
                            Magazine magazine = new Magazine(barCode, name, subject, count, autor);
                            library.AddItem(magazine);
                        }
                        else
                        {
                            Console.WriteLine("Wprowadzona wartość nie jest numerem stron.");
                        }
                    }
                    else if(addChoice == "3")
                    {
                        Console.WriteLine("Proszę wprowadzić....... (Do przebudowy)");
                        int barCode = int.Parse(Console.ReadLine()); //TODO: Omowienie generatoru kodu kreskoiwego. 
                        Console.WriteLine("Proszę wprowadzić nazwę.");
                        string name = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić gatunek.");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić reżysera.");
                        string director = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić czas trwania.");
                        if (int.TryParse(Console.ReadLine(), out int duration))
                        {
                            Movie movie = new Movie(barCode, name, genre, duration, director);
                            library.AddItem(movie);
                        }
                        else
                        {
                            Console.WriteLine("Wprowadzona wartość nie jest czasem trwania filmu.");
                        }
                    }
                    else if(addChoice == "4")
                    {
                        Console.WriteLine("Proszę wprowadzić....... (Do przebudowy)");
                        int barCode = int.Parse(Console.ReadLine()); //TODO: Omowienie generatoru kodu kreskoiwego. 
                        Console.WriteLine("Proszę wprowadzić nazwę.");
                        string name = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić dziedzinę naukową.");
                        string scienceField = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić publikacje.");
                        string journal = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić autora.");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Proszę wprowadzić ilość stron.");
                        if (int.TryParse(Console.ReadLine(), out int count))
                        {
                            ScientificPaper scientificPaper = new ScientificPaper(barCode, name, scienceField, journal, count, autor);
                            library.AddItem(scientificPaper);
                        }
                        else
                        {
                            Console.WriteLine("Wprowadzona wartość nie jest numerem stron.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nie wybrałeś opcji z listy.");
                    }
                }
                else if (choice == "2")
                {
                    if(int.TryParse(Console.ReadLine(), out int id))
                    {
                        library.RemoveItem(id);
                    }
                    else
                    {
                        Console.WriteLine("Wprowadzona wartoiść nie jest numerem ID.");
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Proszę wprowadzić numer ID przedmiotu, następnie numer ID użytkownika.");
                    if (int.TryParse(Console.ReadLine(), out int id) && int.TryParse(Console.ReadLine(), out int userid))
                    {
                        library.RentItem(id, userid);
                    }
                    else
                    {
                        Console.WriteLine("Wprowadzona wartoiść nie jest numerem ID.");
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Proszę wprowadzić numer ID przedmiotu, który chcesz oddać.");
                    if(int.TryParse(Console.ReadLine(), out int id))
                    {
                        library.ReturnItem(id);
                    }
                    else
                    {
                        Console.WriteLine("Wprowadzona wartoiść nie jest numerem ID.");
                    }
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Lista wszystkich przedmiotów.");
                    library.ListItems();
                }
                else if (choice == "6")
                {
                    Console.WriteLine("Wprowadź nazwę użytkownika.");
                    string name = Console.ReadLine();
                    Console.WriteLine("Wprowadź adres email.");
                    string email = Console.ReadLine();
                    Console.WriteLine("Wprowadź adres użytkownika.");
                    string adres = Console.ReadLine();
                    User user = new User(name, email, adres);
                    library.AddUser(user);
                }
                else if (choice == "7")
                {
                    Console.WriteLine("Proszę wprowadzić numer ID użytkownika, którego chcesz usunąć.");
                    if(int.TryParse(Console.ReadLine(), out int id))
                    {
                        library.RemoveUser(id);
                    }
                    else
                    {
                        Console.WriteLine("Wprowadzona wartoiść nie jest numerem ID.");
                    }                    
                }
                else if (choice == "8")
                {
                    Console.WriteLine("Lista wszystkich użytkowników.");
                    library.ListUsers();
                }
                else if (choice == "9")
                {
                    Console.WriteLine("Dziękujemy za skorzystanie z naszego programu.");
                }
                else
                {
                    Console.WriteLine("Proszę wybrać którąś z opcji podanych w menu.");
                }
                Console.WriteLine();
                Console.WriteLine("Naciśnij Enter, aby kontynuować..........");
                Console.ReadLine();

            }

        }
        static void MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1. Dodaj przedmiot.");
            Console.WriteLine("2. Usuń przedmiot.");
            Console.WriteLine("3. Wypożycz przedmiot.");
            Console.WriteLine("4. Oddaj przedmiot.");
            Console.WriteLine("5. Wyświetl listę przedmiotów.");
            Console.WriteLine("6. Dodaj użytkownika.");
            Console.WriteLine("7. Usuń użytkownika.");
            Console.WriteLine("8. Wyświetl listę użytkowników.");
            Console.WriteLine("9. Wyjdź z programu.");

        }
        
        static void Graphic()
        {
            Console.WriteLine("         .-.                                        \n" +
                              "        | T |                             .---.     \n" +
                              "        | Y |                     .-.     |~~~|     \n" +
                              " .-.    | M |.-.                  |_|     |~~~|--.  \n" +
                              "| W |___| O | B |             .---!~|  .--|   |--|  \n" +
                              "| O |===| T | A |             |===| |--|%%|   |  |  \n" +
                              "| J |   | E | R |             |   | |__|  |   |  |  \n" +
                              "| T |   | U | T |             |===| |==|  |   |  |  \n" +
                              "| E |   | S | E |___________  |   |_|__|  |~~~|__|  \n" +
                              "| K |===| Z | K | ||     || | |===|~|--|%%|~~~|--|  \n" +
                              "----------------------------------------------------\n" +
                              "       .--.           .---.        .-.              \n" +
                              "   .---|--|   .-.     | A |  .---. |~|    .--.      \n" +
                              ".--|===|  |---|_|--.__| S |--|:::| |~|-==-|==|---.  \n" +
                              "|%%|NT2|  |===| |~~|%%| C |--|   |_|~|CATS|  |___|-.\n" +
                              "|  |   |  |===| |==|  | I |  |:::|=| |    |GB|---|=|\n" +
                              "|  |   |  |   |_|__|  | I |__|   | | |    |  |___| |\n" +
                              "|~~|===|--|===|~|~~|%%|~~~|--|:::|=|~|----|==|---|=|\n" +
                              "----------------------------------------------------");
        }

    }
}
