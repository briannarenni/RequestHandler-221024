using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestHandler_Data;
using RequestHandler_Logic;


namespace RequestHandler_IO
{
    public class MainMenu
    {
        public static User startMenu() // 1: Login, 2: Register
        {
            bool choiceLoop = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Employee Request Portal - Main Menu");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please choose an option:");
            Console.ResetColor();

            while (choiceLoop)
            {
                string userChoice;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1: Login (Existing User)");
                Console.WriteLine("2: Register (New User)");
                Console.ResetColor();

                userChoice = Console.ReadLine();
                bool emptyStr = string.IsNullOrEmpty(userChoice);

                if ((!emptyStr) && userChoice == "1" || userChoice == "2")
                {
                    // Console.Clear();
                    choiceLoop = false;

                    if (userChoice == "1")
                    {
                        var loginInfo = MainMenu.Login();
                        User currUser = new User(loginInfo.Item1, loginInfo.Item2, loginInfo.Item3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine($"Logging in...");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        return currUser;
                    }
                    else if (userChoice == "2")
                    {
                        var registerInfo = MainMenu.Register();
                        User currUser = new User(registerInfo.Item1, registerInfo.Item2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine($"{currUser.username} registered in successfully. Logging in...");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        return currUser;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Please enter a valid choice.");
                    Console.ResetColor();
                }

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("If you can see this you messed up.");
            Console.ResetColor();
            return new User();
        }

        public static string getUsername()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter username: ");
            Console.ResetColor();
            string username = Console.ReadLine();
            return username;
        }

        public static string getPasswordRegister()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter password: ");
            Console.ResetColor();
            string password = Console.ReadLine();
            return password;
        }
        public static string getPasswordLogin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter password: ");
            var password = string.Empty;
            ConsoleKey key;
            Console.ResetColor();
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            // string password = Console.ReadLine();
            return password;
        }

        //  LOGIN
        public static (string, string, bool) Login()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Login - Existing User");
            bool usernameLoop = true;
            bool passwordLoop = true;
            string username = "";
            string password = "";
            bool isManager = false;
            Console.ResetColor();

            while (usernameLoop)
            {
                username = MainMenu.getUsername();
                var existingUser = AccountRepo.checkUsername(username);
                if (existingUser)
                {
                    usernameLoop = false;
                    // break;
                    while (passwordLoop)
                    {
                        password = MainMenu.getPasswordLogin();
                        var matchPassword = AccountRepo.checkPassword(username, password);
                        if (matchPassword)
                        {
                            passwordLoop = false;
                            isManager = AccountRepo.getPerms(username);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine("Error: Password incorrect.");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Username not found.");
                    Console.ResetColor();
                }
            }

            return (username, password, isManager);
        }

        // REGISTER
        public static (string, string) Register()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Register - New Username");
            bool registerLoop = true;
            string username = "";
            string password = "";
            Console.ResetColor();

            while (registerLoop)
            {
                username = MainMenu.getUsername();
                var existingUser = AccountRepo.checkUsername(username);
                if (!existingUser)
                {
                    password = MainMenu.getPasswordRegister();

                    AccountRepo.addUser(username, password);
                    registerLoop = false;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Username already exists.");
                    Console.ResetColor();
                }
            }
            return (username, password);
        }
    }


}
