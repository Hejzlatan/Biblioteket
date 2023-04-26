using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek 
{
    public class Registration 
    {
        static UserSystem system = UserSystem.GetInstance();
        public static void RegistrationPage() 
        {
            Console.WriteLine("För att registrera dig ange förnamn, efternamn, personnummer och lösenord.");
            Console.WriteLine("");

            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("Personnummer: ");
            var personalNumber = Console.ReadLine();

            Console.Write("Lösenord: ");
            var password = Console.ReadLine();

            system.CreateUser(personalNumber, password);

            Console.WriteLine("Du är nu registrerad och kan logga in. Vänligen vänta för att skickas till inloggningssidan.");

            Thread.Sleep(6000);

            Login.LoginPage();
        }

        

   
    }
}

