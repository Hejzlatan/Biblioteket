using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Login

    {
        static UserSystem system = UserSystem.GetInstance();
        public static void LoginPage()
        {
            Console.Clear();

            Console.WriteLine("Välkommen!");


            Console.WriteLine("För att logga in ange personnummer och lösenord.");
            Console.WriteLine("");

            Console.Write("Personnummer: ");
            var personalNumber = Console.ReadLine();

            Console.Write("Ange ditt Lösenord: ");
            var password = Console.ReadLine();
            var user = system.Login(personalNumber, password);
            if (user != null)
            {
                Console.Write("Nu är du inloggad!:-)");
                Thread.Sleep(6000);
                Search.SearchPage();
            }
            else
            {
                Thread.Sleep(1000);
                Console.WriteLine("Det var fel försök igen");
                Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
                Login.LoginPage();
            }
        }

    }
}
