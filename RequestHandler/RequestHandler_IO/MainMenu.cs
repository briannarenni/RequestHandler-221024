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

            Console.WriteLine();
            Console.WriteLine("Employee Request Portal - Main Menu");
            Console.WriteLine();
            Console.WriteLine("Please choose an option:");

            while (choiceLoop)
            {
                string userChoice;

                Console.WriteLine("1: Login (Existing User)");
                Console.WriteLine("2: Register (New User)");

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
                        Console.WriteLine($"{currUser.username} logged in successfully.");
                        return currUser;
                    }
                    else if (userChoice == "2")
                    {
                        var registerInfo = MainMenu.Register();
                        User currUser = new User(registerInfo.Item1, registerInfo.Item2);
                        Console.WriteLine($"{currUser.username} registered in successfully. Logging in...");
                        Thread.Sleep(1500);
                        return currUser;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a number.");
                }

            }
            Console.WriteLine("If you can see this you messed up.");
            return new User();
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

        // ! LOGIN
        public static (string, string , bool) Login()
        {
            Console.WriteLine("Login - Existing User");
            bool usernameLoop = true;
            bool passwordLoop = true;
            string username = "";
            string password = "";
            bool isManager = false;

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
                        password = MainMenu.getPassword();
                        var matchPassword = AccountRepo.checkPassword(username, password);
                        if (matchPassword)
                        {
                            passwordLoop = false;
                            isManager = AccountRepo.getPerms(username);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Username not found.");
                }
            }

            return (username, password, isManager);
        }

        // ! REGISTER
        public static (string, string) Register()
        {
            Console.WriteLine("Register - New Username");
            bool registerLoop = true;
            string username = "";
            string password = "";
            // bool perms = false;

            while (registerLoop)
            {
                username = MainMenu.getUsername();
                var existingUser = AccountRepo.checkUsername(username);
                if (!existingUser)
                {
                    password = MainMenu.getPassword();


                    // perms = AccountRepo.getPerms(username);

                    AccountRepo.addUser(username, password);
                    registerLoop = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Error, username already exists.");
                }
            }
            return (username, password);
        }
    }


}
