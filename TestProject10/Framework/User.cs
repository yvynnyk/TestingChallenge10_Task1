using System;
using System.IO;

namespace TestProject10.Framework
{
    public class User
    {
        public string Name { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public User(string[] user)
        {
            Name = user[0];
            Password = user[1];
            FirstName = user[2];
            LastName = user[3];
        }
        public static User [] GetUsersFromCSVFile()
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/NewUsers.csv"));
            User[] users = new User[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                users[i] = new User(lines[i].Split(","));
            }
            
            return users;
        }
    }
}
