using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestHandler_Data;
using RequestHandler_IO;
using RequestHandler_Logic;

namespace RequestHandler_App
{

    class Program
    {
        public static void Main(String[] args)
        {
            IRepo accRepo = new AccountRepo();
            IRepo ticketRepo = new TicketRepo();
            string username;
            string password;

            // ! MainMenu
            int mainChoice = MainMenu.getMenuChoice();
            Console.WriteLine(mainChoice);

            if (mainChoice == 1) // LOGIN
            {
                bool usernameLoop = true;
                bool passwordLoop = true;
                while (usernameLoop)
                {
                    username = MainMenu.getUsername();
                    var existingUser = AccountRepo.checkUsername(username);
                    if (existingUser)
                    {
                        usernameLoop = false;
                        // break;
                        //! TEST NEXT

                        while (passwordLoop)
                        {
                            password = MainMenu.getPassword();
                            var matchPassword = AccountRepo.checkPassword(username, password);
                            if (matchPassword)
                            {
                                passwordLoop = false;
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
            }

            else if (mainChoice == 2) // REGISTER
            {
                bool registerLoop = true;
                while (registerLoop)
                {
                    username = MainMenu.getUsername();
                    var existingUser = AccountRepo.checkUsername(username);
                    if (!existingUser)
                    {
                        password = MainMenu.getPassword();
                        User account = new User(username, password);
                        AccountRepo.addUser(username, password);
                        registerLoop = false;
                        // break;
                    }
                    else
                    {
                        Console.WriteLine("Error, username already exists.");
                    }
                }
            }

            // TODO: Get user info from DB, save to account
            // account.getUser();


        }
    }
}