using System;

namespace LibraryOP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!!!");
            Console.WriteLine("Hello World!!!");
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Witamy w programie LibraryOP.");
            Graphic();
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
            string opcja = "0";
            while (opcja != "9")
            {
                MenuOptions();
                opcja = Console.ReadLine();
                if (opcja == "1")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                    
                }
                else if (opcja == "2")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                }
                else if (opcja == "3")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                }
                else if (opcja == "4")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                }
                else if (opcja == "5")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                }
                else if (opcja == "6")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                }
                else if (opcja == "7")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                }
                else if (opcja == "8")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                }
                else if (opcja == "9")
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
            Console.WriteLine("1. Dodaj książkę.");
            Console.WriteLine("2. Usuń książkę.");
            Console.WriteLine("3. Wypożycz książkę.");
            Console.WriteLine("4. Oddaj książkę.");
            Console.WriteLine("5. Wyświetl listę książek.");
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
