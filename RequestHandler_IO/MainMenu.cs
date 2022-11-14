using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandler_IO
{
    public class MainMenu
    {
        public static int getMenuChoice() // 1: Login, 2: Register
        {
            int userChoice = 0;
            bool loop = true;

            while (loop)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Employee Request Portal - Main Menu");
                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("1: Login (Existing User)");
                    Console.WriteLine("2: Register (New User)");

                    userChoice = Convert.ToInt32(Console.ReadLine());
                    if (userChoice == 1 || userChoice == 2)
                    {
                        loop = false;
                    }
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
            }
            return userChoice;
        }

        public static string getUsername()
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            return username;
        }

        public static string getPassword()
        {
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            return password;
        }



    }
}
