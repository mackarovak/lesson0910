using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework
{
    public class Govor
    {
        // readonly is kind of const, but for objects, since they are creatd during runtime
        // https://stackoverflow.com/questions/5142349/declare-a-const-array/5142378

        public static readonly char[] VOWELS_WITHOUT_A = new char[] { 'О', 'У', 'Ы', 'Э', 'И', 'Е', 'Ю', 'Я' };

        public static void Main()
        {
            string test = "класс круто супер прелесть";
            Console.WriteLine("Initial string: " + test);
            Console.WriteLine("Translated string: " + Translate(test));
        }

        public static string Translate(string str)
        {
            string[] tokens = str.Split(' ');
            if (tokens.Length != 4)
            {
                Console.WriteLine("oopsie, I expected 4 words");
                return "";
            }

            for (int i = 0; i < 4; ++i)
            {
                tokens[i] = tokens[i].ToUpper().Replace('А', '@');
                foreach (char vowel in VOWELS_WITHOUT_A)
                {
                    tokens[i] = tokens[i].Replace(vowel, '*');
                }
            }

            string result = String.Join(" ", tokens);

            return result;
        }
    }
    class Program
    {
        static bool DecodePass(string[] variants, ref string password2)
        {
            for (int i = 0; i < variants.Length; i++)
            {
                string strochka = "";
                for (int j = 0; j < variants[i].Length; j++)
                {
                    strochka = strochka + Convert.ToString(variants[i][j], 2);
                }
                if (strochka == password2)
                {
                    password2 = variants[i];
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            string[] password = { "password", "pass123", "pass" };
            StreamReader reader = new StreamReader("pass.txt");
            string passBinary = reader.ReadToEnd();
            passBinary = passBinary.Replace(" ", "");
            if (DecodePass(password, ref passBinary))
            {
                Console.WriteLine(passBinary);
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
