using System;
using System.Collections;
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

    public class Program
    {
        public static void Main(String[] args)
        {
            IRepo accRepo = new AccountRepo();
            IRepo ticketRepo = new TicketRepo();

            // login/register acc
            User currUser = MainMenu.startMenu();
            ArrayList currUserInfo = new ArrayList();

            // Update user info from DB
            (int, int) setCurrUserInfo = AccountRepo.updateUserInfo(currUser.username);
            // Attach to current User
            currUser.updateUserInfo(setCurrUserInfo);
            Console.WriteLine($"{currUser.username} logged in successfully.");



            // *  if Employee
            // EmployeeMenu()
            // 1: Submit New Request
            // 2: View Submitted Requests
            // 3: View Account Info
            // 4: Log Out

            // * if Manager
            // ManagerMenu()
            // 1: View Pending Requests
            // 2: View All Requests
            // 3: View Account Info
            // 4: Log Out


        }
    }
}