using System;
using System.Linq;

namespace LibraryOP
{
    public static class Menu
    {
        public static void RunMenu(ILibrary library)
        {
            Console.WriteLine("Witamy w programie LibraryOP.");
            Graphic();
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
            string choice = String.Empty;
            while (choice != "0")
            {
                MenuOptions();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        MenuAddItem(library);
                        break;
                    case "2":
                        MenuRemoveItem(library);
                        break;
                    case "3":
                        MenuRentItem(library);
                        break;
                    case "4":
                        MenuReturnItem(library);
                        break;
                    case "5":
                        MenuListItems(library);
                        break;
                    case "6":
                        MenuAddUser(library);
                        break;
                    case "7":
                        MenuRemoveUser(library);
                        break;
                    case "8":
                        MenuListUsers(library);
                        break;
                    case "9":
                        MenuSaveDB(library);
                        break;
                    case "0":
                        Console.WriteLine("Dziękujemy za skorzystanie z naszego programu.");
                        MenuSaveDB(library);
                        break;
                    default:
                        Console.WriteLine("Proszę wybrać którąś z opcji podanych w menu.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować.");
                Console.ReadKey();
            }
        }

        private static void MenuOptions()
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
            Console.WriteLine("9. Zapisz zmiany do bazy.");
            Console.WriteLine("0. Wyjdź z programu.");
        }

        private static void Graphic()
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
                              "   .---|--|   .-.     | P |  .---. |~|    .--.      \n" +
                              ".--|===|  |---|_|--.__| A |--|:::| |~|-==-|==|---.  \n" +
                              "|%%|NT2|  |===| |~~|%%| N |--|   |_|~|CATS|  |___|-.\n" +
                              "|  |   |  |===| |==|  | D |  |:::|=| |    |GB|---|=|\n" +
                              "|  |   |  |   |_|__|  | A |__|   | | |    |  |___| |\n" +
                              "|~~|===|--|===|~|~~|%%|~5~|--|:::|=|~|----|==|---|=|\n" +
                              "----------------------------------------------------");
        }

        private static void MenuAddItem(ILibrary library)
        {
            Console.WriteLine("1. Dodaj książkę.");
            Console.WriteLine("2. Dodaj magazyn.");
            Console.WriteLine("3. Dodaj film.");
            Console.WriteLine("4. Dodaj magazyn naukowy.");
            string addChoice = Console.ReadLine();
            switch (addChoice)
            {
                case "1":
                    MenuAddBook(library);
                    break;
                case "2":
                    MenuAddMagazine(library);
                    break;
                case "3":
                    MenuAddMovie(library);
                    break;
                case "4":
                    MenuAddScientificPaper(library);
                    break;

                default:
                    Console.WriteLine("Nie wybrałeś opcji z listy.");
                    break;
            }
        }

        private static void MenuRemoveItem(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić numer ID przedmiotu, który chcesz usunąć.");
            int id = ReadInt();
            library.RemoveItem(id);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuRentItem(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić kood kreskowy przedmiotu, następnie numer ID użytkownika.");
            int id = ReadInt();
            int userid = ReadInt();
            library.RentItem(id, userid);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuReturnItem(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić numer ID przedmiotu, który chcesz oddać.");
            int id = ReadInt();
            library.ReturnItem(id);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuListItems(ILibrary library)
        {
            Console.WriteLine("Lista wszystkich przedmiotów.");
            library.ListItems();
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        static void MenuAddUser(ILibrary library)
        {
            Console.WriteLine("Wprowadź nazwę użytkownika.");
            string name = ReadString();
            Console.WriteLine("Wprowadź adres email.");
            string email = ReadString();
            Console.WriteLine("Wprowadź adres użytkownika.");
            string adres = ReadString();
            int id = IdGenerator.GenerateId(library.Users.Select(i => i.Id).ToList());
            User user = new User(id, name, email, adres);
            library.AddUser(user);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuRemoveUser(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić numer ID użytkownika, którego chcesz usunąć.");
            int id = ReadInt();
            library.RemoveUser(id);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuListUsers(ILibrary library)
        {
            Console.WriteLine("Lista wszystkich użytkowników.");
            library.ListUsers();
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuAddBook(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić kod kreskowy.");
            int barCode = ReadInt();
            Console.WriteLine("Proszę wprowadzić nazwę.");
            string name = ReadString();
            Console.WriteLine("Proszę wprowadzić gatunek.");
            string genre = ReadString();
            Console.WriteLine("Proszę wprowadzić ilość stron.");            
            int count = ReadInt();
            Console.WriteLine("Proszę wprowadzić autora.");
            string autor = ReadString();
            int id = IdGenerator.GenerateId(library.Items.Select(i => i.Id).ToList());
            Book book = new Book(id, barCode, name, genre, count, autor);
            library.AddItem(book);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuAddMagazine(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić kod kreskowy.");
            int barCode = ReadInt();            
            Console.WriteLine("Proszę wprowadzić nazwę.");
            string name = ReadString();
            Console.WriteLine("Proszę wprowadzić temat.");
            string subject = ReadString();
            Console.WriteLine("Proszę wprowadzić ilość stron.");
            int count = ReadInt();            
            Console.WriteLine("Proszę wprowadzić autora.");
            string autor = ReadString();
            int id = IdGenerator.GenerateId(library.Items.Select(i => i.Id).ToList());
            Magazine magazine = new Magazine(id, barCode, name, subject, count, autor);
            library.AddItem(magazine);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuAddMovie(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić kod kreskowy.");
            int barCode = ReadInt();
            Console.WriteLine("Proszę wprowadzić nazwę.");
            string name = ReadString();
            Console.WriteLine("Proszę wprowadzić gatunek.");
            string genre = ReadString();
            Console.WriteLine("Proszę wprowadzić czas trwania.");
            int duration = ReadInt();
            Console.WriteLine("Proszę wprowadzić reżysera.");
            string director = ReadString();
            int id = IdGenerator.GenerateId(library.Items.Select(i => i.Id).ToList());
            Movie movie = new Movie(id,barCode, name, genre, duration, director);
            library.AddItem(movie);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuAddScientificPaper(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić kod kreskowy.");
            int barCode = ReadInt();
            Console.WriteLine("Proszę wprowadzić nazwę.");
            string name = ReadString();
            Console.WriteLine("Proszę wprowadzić dziedzinę naukową.");
            string scienceField = ReadString();
            Console.WriteLine("Proszę wprowadzić publikacje.");
            string journal = ReadString();
            Console.WriteLine("Proszę wprowadzić ilość stron.");
            int count = ReadInt();
            Console.WriteLine("Proszę wprowadzić autora.");
            string autor = ReadString();
            int id = IdGenerator.GenerateId(library.Items.Select(i => i.Id).ToList());
            ScientificPaper scientificPaper = new ScientificPaper(id, barCode, name, scienceField, journal, count, autor);
            library.AddItem(scientificPaper);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuSaveDB(ILibrary library)
        {
            library.SaveDb();
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static string ReadString()
        {
            string readText = "";
            while (readText == "")
            {
                readText = Console.ReadLine();
                if (readText == "")
                {
                    Console.WriteLine("Wprowadzona wartość jest nieprawidłowa. \n" + "Spróbuj ponownie.");
                }
            }
            return readText;
        }

        private static int ReadInt()
        {
            int readInt = 0;
            while (readInt == 0)
            {
                int.TryParse(Console.ReadLine(), out readInt);
                if (readInt == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest numerem. \n" + "Spróbuj ponownie.");
                }
            }
            return readInt;
        }
    }
}
