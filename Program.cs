using System;
using MySqlConnector;
using System.Data;
using System.ComponentModel.Design;
using test211_console;

public class Program
{
    public static void Main()
    {
        DatabaseManagement databaseManagement = new DatabaseManagement();
        Console.WriteLine("Hello friend.");

        Console.WriteLine("Please select an option from the menu:\n\n" +
            "1. Create new User.\n\n" +
            "2. Update user information\n\n" +
            "3. Delete User\n\n" +
            "4. Display list of users.");
        string userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                Console.WriteLine("please input the new user's information.\n\nname:");
                string name = Console.ReadLine();
                Console.WriteLine("email: ");
                string email = Console.ReadLine();
                databaseManagement.CreateUser(name, email);
                break;
            case "2":
                Console.WriteLine("Please enter the user Id of the user who's information you'd like to update, along with their updated inforamtion.");
                Console.WriteLine();
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                name = Console.ReadLine();
                Console.WriteLine();
                email = Console.ReadLine();
                databaseManagement.UpdateUser(name, email, id);

                break;
            case "3":
                Console.WriteLine("Please enter the id of the User you'd like to remove from the system.\n\nuser ID: ");
                id = Convert.ToInt32(Console.ReadLine());
                databaseManagement.DeleteUser(id);
                break;
            case "4":
                DataTable users = databaseManagement.GetUsers();
                foreach (DataRow row in users.Rows)
                {
                    id = (int)row["id"];
                    name = (string)row["name"];
                    email = (string)row["email"];
                    Console.WriteLine($"ID: {id}, Name: {name}, Email: {email}");
                }

                break;
        }
    }

}