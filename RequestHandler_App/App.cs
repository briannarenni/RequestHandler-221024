using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace RequestHandler_App
{
    public class App
    {
        string username;
        string password;

        // ! MainMenu
        // getMenuChoice() - returns int

        // * if Login (1)
        // username = MainMenu.getUsername();
        // existingUser = checkUsername(username)
        // ? if true
        // password = MainMenu.getPassword();
        // User account = new User(username, password)

        // ? if false
        // "Username not found. Please choose an option: "
        // "1: Register"
        // "2: Login with a different username"
        // Loop back to top

        // * if Register (2)
        // username = MainMenu.getUsername();
        // password = MainMenu.getPassword();
        // existingUser = checkUsername(username)
        // ? if false
        // continue
        // User account = new User(username, password)
        // ? if true
        // "Error, username already exists."
        // show Login




        // *  if Employee
        // EmployeeMenu()
        // 1: Submit New Request
        // 2: View Submitted Requests
        // 3: Log Out

        // * if Manager
        // ManagerMenu()
        // 1: View Pending Requests
        // 2: View Processed Requests (by user)
        // 3: Log Out

    }
}
