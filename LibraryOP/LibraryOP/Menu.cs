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
                Console.WriteLine("Naciśnij Enter, aby kontynuować.");
                Console.ReadLine();
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
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    library.RemoveItem(id);
                    Console.WriteLine("Operacja zakończyła się powodzeniem.");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            else
            {
                Console.WriteLine("Wprowadzona wartoiść nie jest numerem ID.");
            }
        }

        private static void MenuRentItem(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić numer ID przedmiotu, następnie numer ID użytkownika.");
            if (int.TryParse(Console.ReadLine(), out int id) && int.TryParse(Console.ReadLine(), out int userid))
            {
                try
                {
                    library.RentItem(id, userid);
                    Console.WriteLine("Operacja zakończyła się powodzeniem.");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            else
            {
                Console.WriteLine("Wprowadzona wartoiść nie jest numerem ID.");
            }
        }

        private static void MenuReturnItem(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić numer ID przedmiotu, który chcesz oddać.");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    library.ReturnItem(id);
                    Console.WriteLine("Operacja zakończyła się powodzeniem.");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            else
            {
                Console.WriteLine("Wprowadzona wartoiść nie jest numerem ID.");
            }
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
            string name = Console.ReadLine();
            Console.WriteLine("Wprowadź adres email.");
            string email = Console.ReadLine();
            Console.WriteLine("Wprowadź adres użytkownika.");
            string adres = Console.ReadLine();
            int id = IdGenerator.GenerateId(library.Users.Select(i => i.Id).ToList());
            User user = new User(id, name, email, adres);
            library.AddUser(user);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuRemoveUser(ILibrary library)
        {
            Console.WriteLine("Proszę wprowadzić numer ID użytkownika, którego chcesz usunąć.");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    library.RemoveUser(id);
                    Console.WriteLine("Operacja zakończyła się powodzeniem.");
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            else
            {
                Console.WriteLine("Wprowadzona wartoiść nie jest numerem ID.");
            }
        }

        private static void MenuListUsers(ILibrary library)
        {
            Console.WriteLine("Lista wszystkich użytkowników.");
            library.ListUsers();
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuAddBook(ILibrary library)
        {
            int barCode = 0;
            Console.WriteLine("Proszę wprowadzić kod kreskowy.");
            while (barCode == 0)
            {
                int.TryParse(Console.ReadLine(), out barCode);
                if (barCode == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest numerem kodu kreskowego. \n" + "Spróbuj ponownie.");
                }
            }
            Console.WriteLine("Proszę wprowadzić nazwę.");
            string name = Console.ReadLine();
            Console.WriteLine("Proszę wprowadzić gatunek.");
            string genre = Console.ReadLine();
            int count = 0;
            Console.WriteLine("Proszę wprowadzić ilość stron.");
            while (count == 0)
            {
                int.TryParse(Console.ReadLine(), out count);
                if (count == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest numerem stron. \n" + "Spróbuj ponownie.");
                }
            }
            Console.WriteLine("Proszę wprowadzić autora.");
            string autor = Console.ReadLine();
            int id = IdGenerator.GenerateId(library.Items.Select(i => i.Id).ToList());
            Book book = new Book(id, barCode, name, genre, count, autor);
            library.AddItem(book);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuAddMagazine(ILibrary library)
        {
            int barCode = 0;
            Console.WriteLine("Proszę wprowadzić kod kreskowy.");
            while (barCode == 0)
            {
                int.TryParse(Console.ReadLine(), out barCode);
                if (barCode == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest numerem kodu kreskowego. \n" + "Spróbuj ponownie.");
                }
            }
            Console.WriteLine("Proszę wprowadzić nazwę.");
            string name = Console.ReadLine();
            Console.WriteLine("Proszę wprowadzić temat.");
            string subject = Console.ReadLine();
            int count = 0;
            Console.WriteLine("Proszę wprowadzić ilość stron.");
            while (count == 0)
            {
                int.TryParse(Console.ReadLine(), out count);
                if (count == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest numerem stron. \n" + "Spróbuj ponownie.");
                }
            }
            Console.WriteLine("Proszę wprowadzić autora.");
            string autor = Console.ReadLine();
            int id = IdGenerator.GenerateId(library.Items.Select(i => i.Id).ToList());
            Magazine magazine = new Magazine(id, barCode, name, subject, count, autor);
            library.AddItem(magazine);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuAddMovie(ILibrary library)
        {
            int barCode = 0;
            Console.WriteLine("Proszę wprowadzić kod kreskowy.");
            while (barCode == 0)
            {
                int.TryParse(Console.ReadLine(), out barCode);
                if (barCode == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest numerem kodu kreskowego. \n" + "Spróbuj ponownie.");
                }
            }
            Console.WriteLine("Proszę wprowadzić nazwę.");
            string name = Console.ReadLine();
            Console.WriteLine("Proszę wprowadzić gatunek.");
            string genre = Console.ReadLine();
            int duration = 0;
            Console.WriteLine("Proszę wprowadzić czas trwania.");
            while (duration == 0)
            {
                int.TryParse(Console.ReadLine(), out duration);
                if (duration == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest czasem trwania filmu. \n" + "Spróbuj ponownie.");
                }
            }
            Console.WriteLine("Proszę wprowadzić reżysera.");
            string director = Console.ReadLine();
            int id = IdGenerator.GenerateId(library.Items.Select(i => i.Id).ToList());
            Movie movie = new Movie(id, barCode, name, genre, duration, director);
            library.AddItem(movie);
            Console.WriteLine("Operacja zakończyła się powodzeniem.");
        }

        private static void MenuAddScientificPaper(ILibrary library)
        {
            int barCode = 0;
            Console.WriteLine("Proszę wprowadzić kod kreskowy.");
            while (barCode == 0)
            {
                int.TryParse(Console.ReadLine(), out barCode);
                if (barCode == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest numerem kodu kreskowego. \n" + "Spróbuj ponownie.");
                }
            }
            Console.WriteLine("Proszę wprowadzić nazwę.");
            string name = Console.ReadLine();
            Console.WriteLine("Proszę wprowadzić dziedzinę naukową.");
            string scienceField = Console.ReadLine();
            Console.WriteLine("Proszę wprowadzić publikacje.");
            string journal = Console.ReadLine();
            int count = 0;
            Console.WriteLine("Proszę wprowadzić ilość stron.");
            while (count == 0)
            {
                int.TryParse(Console.ReadLine(), out count);
                if (count == 0)
                {
                    Console.WriteLine("Wprowadzona wartość nie jest numerem stron. \n" + "Spróbuj ponownie.");
                }
            }
            Console.WriteLine("Proszę wprowadzić autora.");
            string autor = Console.ReadLine();
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
    }
}
