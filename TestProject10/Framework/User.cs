using System;
using System.IO;

namespace TestProject10.Framework
{
    public class User
    {       
        public static string[] GetUsersFromCSVFile()
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/NewUsers.csv"));
            return lines;
        }
    }
}
