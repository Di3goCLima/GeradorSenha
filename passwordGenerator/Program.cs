using System;

namespace passwordGenerator
{
    class Program
    {
        private static bool upper, lower, number, special;
        private static int passwordLength;
        static void Main(string[] args)
        {
            MainMenu.WriteLogo();
            Console.Write("Insira a quantidade de caracteres desejadas para a senha: ");
            passwordLength = Convert.ToInt32(Console.ReadLine());

            upper = lower = number = special = true;

            Console.WriteLine("A senha gerada é: " + PasswordGenerate.GeneratePassword(upper, lower, number, special, passwordLength));
        }
    }

    public static class PasswordGenerate
    {
        private static string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string Numbers = "1234567890";
        private static string SpecialChars = "!@#$%¨&*()";

        public static string GeneratePassword(
            bool useUpper,
            bool useLower,
            bool useNumbers,
            bool useSpecial,
            int PasswordSize)
        {
            Random rand = new Random();
            string charSet = string.Empty;
            char[] password = new char[PasswordSize];

            if (useUpper) charSet += Upper;
            if (useLower) charSet += Upper.ToLower();
            if ( useNumbers) charSet += Numbers;
            if (useSpecial) charSet += SpecialChars;

            for (int i = 0; i < PasswordSize; i++)
            {
                password[i] = charSet[rand.Next(charSet.Length - 1)];
            }

            return string.Join(null, password);
        }
    }
}
