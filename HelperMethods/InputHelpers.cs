using System;
using System.Collections.Generic;
using System.Text;

namespace DES_L1_Calculator.HelperMethods
{
    internal class InputHelpers
    {
        public static int ValidatingUserChoice() //metoda validează alegerea utilizatorului
        {
            int userChoice;
            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice != 1 && userChoice != 2 && userChoice != 0)
            {
                Console.WriteLine("Alegeți fie 1, 2 sau 0.");
            }
            return userChoice;
        }
        public static string ValidatingUserInput() // validează mesajul introdus de utilizator
        {
            string? userInput = Console.ReadLine();

            while (userInput == null || userInput.Length !=  8)
            {
                Console.WriteLine("Mesajul trebuie să conțină 8 caractere:");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        public static string RandomStringGenerator(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] randomString = new char[length];

            for (int i = 0; i < length; i++)
            {
                // Alege un caracter la întâmplare din validChars
                randomString[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(randomString);
        }
    }
}
