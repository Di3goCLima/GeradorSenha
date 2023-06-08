using System;

namespace passwordGenerator
{
    class Program
    {
        private static bool upper, lower, number, special;
        private static int passwordLength;
        static void Main(string[] args)
        {
            //A logo sendo chamada por outro arquivo
            MainMenu.WriteLogo();
            Console.Write("Insira a quantidade de caracteres desejadas para a senha: ");
            //Variável que recebe o tamanho da senha
            passwordLength = Convert.ToInt32(Console.ReadLine());

            //Um informe ao console para que use todos os tipos de váriáveis de caractéres
            upper = lower = number = special = true;

            //Saída do código
            Console.WriteLine("A senha gerada é: " + PasswordGenerate.GeneratePassword(upper, lower, number, special, passwordLength));
        }
    }

    //Gerador de Senha
    public static class PasswordGenerate
    {
        //Os tipos de caractéres para o gerador usar
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
            //Variável randômica para escolher os caractéres da senha
            Random rand = new Random();
            string charSet = string.Empty;
            char[] password = new char[PasswordSize];

            if (useUpper) charSet += Upper;
            if (useLower) charSet += Upper.ToLower();
            if ( useNumbers) charSet += Numbers;
            if (useSpecial) charSet += SpecialChars;

            //PasswordSize recebe o valor int da entrada e a cada Charset(Caracter) ele duminui em 1 o tamanho até igualar ao valor vazio
            for (int i = 0; i < PasswordSize; i++)
            {
                password[i] = charSet[rand.Next(charSet.Length - 1)];
            }

            //Saída da clasee 
            return string.Join(null, password);
        }
    }
}
