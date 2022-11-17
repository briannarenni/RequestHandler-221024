using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RequestHandler_Logic
{
    public class Validation
    {
        public static bool isChoiceNull(string userInput)
        {
            bool emptyStr = string.IsNullOrEmpty(userInput);

            return (!emptyStr);
        }

        public static bool isChoiceValid(string userInput)
        {

            List<string> choices = new List<string>()
            {
                "1", "2", "3", "4", "5"
            };

            return (choices.Contains(userInput.Trim()));

        }

        public static bool logOut()
        {
            bool loop = true;
            while (loop = true)
            {
                Console.WriteLine("Log Out? (1: Y, 2: N)");
                string logOutChoice = Console.ReadLine();
                bool nullCheck = Validation.isChoiceNull(logOutChoice);
                bool inputCheck = Validation.isChoiceValid(logOutChoice);

                if (nullCheck && inputCheck)
                {
                    if (logOutChoice == "1")
                    {
                        loop = false;

                        Console.WriteLine("Logging out...");
                        return false;
                    }
                    else if (logOutChoice == "2")
                    {
                        loop = false;
                        Console.WriteLine("Back to Main");
                        Thread.Sleep(1500);
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Error: Enter 1 or 2: ");

                }
            }
            return true;
        }

    }
}