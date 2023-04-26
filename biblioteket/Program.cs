using Newtonsoft.Json;
using System;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Vill du skapa konto? Tryck 1");
                Console.WriteLine("Vill du logga in? Tryck 2");
                Console.WriteLine("Vill du ändra lösenord? Tryck 3");
                Console.WriteLine("Vill du avsluta programmet? Tryck 4\n");
                Console.WriteLine("Välj en siffra: ");
                string number = Console.ReadLine();

                if (number == "1")
                {
                    Console.WriteLine("Här skapar du konto!");
                    Registration.RegistrationPage();
                }
                else if (number == "2")
                {
                    Console.WriteLine("Här loggar du in");
                    Login.LoginPage();
                }
                else if (number == "3")
                {
                    Console.WriteLine("Här ändrar du ditt lösenord");
                    Console.WriteLine("Ange ditt personnummer:");
                    string personnummer = Console.ReadLine();
                    Console.WriteLine("Ange ditt nuvarande lösenord:");
                    string currentPassword = Console.ReadLine();
                    Console.WriteLine("Ange ditt nya lösenord:");
                    string newPassword = Console.ReadLine();
                    bool success = ChangePassword(personnummer, currentPassword, newPassword);
                    if (success)
                    {
                        Console.WriteLine("Lösenordet ändrades framgångsrikt!");
                    }
                    else
                    {
                        Console.WriteLine("Kunde inte ändra lösenordet. Kontrollera dina uppgifter och försök igen.");
                    }
                }
                else if (number == "4")
                {
                    Console.WriteLine("Programmet avslutas.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Ogiltigt nummer");
                }
                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
                Console.Clear(); // Rensa konsolfönstret inför nästa val
            }
        }

        private static bool ChangePassword(string personnummer, string currentPassword, string newPassword)
            
        {

            // Skapa en instans av UserSystem-klassen
             UserSystem userSystem = UserSystem.GetInstance();

            // Hämta användaren med personnummer
            User user = userSystem.Login(personnummer, currentPassword);

            // Kontrollera att användaren finns och att det angivna lösenordet matchar det befintliga lösenordet
            if (user != null && user.Password == currentPassword)
            {
                // Ändra lösenordet
                userSystem.ChangePassword(user, currentPassword, newPassword);

                // Skriv ut ett meddelande för att bekräfta att lösenordet har ändrats
                Console.WriteLine("Lösenordet har ändrats.");
                return true;
            }
            else
            {
                // Skriv ut ett felmeddelande om personnumret eller lösenordet är felaktiga
                Console.WriteLine("Personnumret eller lösenordet är felaktigt.");
                return false;
            }

        }
    }
}



