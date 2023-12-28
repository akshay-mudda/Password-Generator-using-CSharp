using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator_using_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Generator!");

            int length = 0;

            do
            {
                string input;

                do
                {
                    Console.Write("Enter the length of the password (6-30): ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("No input. Please enter a valid password length.");
                        continue;
                    }

                    if (!int.TryParse(input, out length))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    if (length < 6 || length > 30)
                    {
                        Console.WriteLine("Password length must be between 6 and 30. Please enter a valid number!");
                    }

                } while (length < 6 || length > 30);

                string password = GeneratePassword(length);
                Console.WriteLine($"Generated Password: {password}");

                Console.Write("Do you want another password? (y/n): ");
                string anotherPasswordInput = Console.ReadLine().Trim().ToLower();

                while (anotherPasswordInput != "y" && anotherPasswordInput != "n")
                {
                    Console.WriteLine("Invalid input. Please enter 'y' for another password or 'n' to stop.");
                    Console.Write("Do you want another password? (y/n): ");
                    anotherPasswordInput = Console.ReadLine().Trim().ToLower();
                }

                if (anotherPasswordInput == "n")
                {
                    Console.WriteLine("Thank you!");
                    Console.WriteLine("Created by Akshay_Mudda");
                    break;
                }

            } while (true);
        }

        static string GeneratePassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%&*_-";
            StringBuilder password = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                password.Append(chars[index]);
            }

            return password.ToString();
        }
    }
}
