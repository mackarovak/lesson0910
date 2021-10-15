using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homeworkmeth
{
    enum Months
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }
    class Program
    {
        private static int[] GetVowelsAndСonsonantsCount(char[] text)
        {
            Console.WriteLine("Задание1a");
            const string vowels = "аеёиоуыэюя";
            int[] vowelsconsonantscounters = new int[2] { 0, 0 };

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (vowels.Contains(char.ToLower(text[i])))
                        vowelsconsonantscounters[0]++;
                    else
                        vowelsconsonantscounters[1]++;
                }
            }

            return vowelsconsonantscounters;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            string str = File.ReadAllText("Text.txt");
            char[] text = new char[str.Length];
            char[] inputFileText = File.ReadAllText(args[0], Encoding.UTF8).ToCharArray();
            int[] inputTextVowelsAndСonsonantsCounters = GetVowelsAndСonsonantsCount(inputFileText);
            Console.WriteLine("Количество гласных букв в тексте: {0}", inputTextVowelsAndСonsonantsCounters[0]);
            Console.WriteLine("Количество согласных букв в тексте: {0}", inputTextVowelsAndСonsonantsCounters[1]);

            Console.WriteLine("Задание1б");
            string vowels = "аеёиоуыэюя";
            string consonants = "бвгджзйклмнпрстфхцчшщ";
            str = File.ReadAllText("Text.txt");
            var list = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                text[i] = str[i];
            }
            Console.WriteLine(str);
            int countvowels = 0;
            int countconsonants = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(list[i]))
                {
                    countvowels++;
                }
                else if (consonants.Contains(list[i]))
                {
                    countconsonants++;
                }
            }
            Console.WriteLine("гласные буковки= " + countvowels);
            Console.WriteLine("согласные буковки = " + countconsonants);
        }

        static void Matrix(string[] args)
        {
            Console.WriteLine("Задание2a");
            int lines1 = Convert.ToInt32(Console.ReadLine());
            int columns1 = Convert.ToInt32(Console.ReadLine());
            int lines2 = Convert.ToInt32(Console.ReadLine());
            int columns2 = Convert.ToInt32(Console.ReadLine());
            int[,] matrix1 = new int[lines1, columns1];
            int[,] matrix2 = new int[lines2, columns2];
            Random random = new Random();
            for (int i = 0; i < lines1; i++)
            {
                for (int j = 0; j < columns1; j++)
                {
                    matrix1[lines1, columns1] = random.Next(1, 10);
                }
            }
            for (int i = 0; i < lines1; i++)
            {
                for (int j = 0; j < columns1; j++)
                {
                    Console.Write(matrix1[lines1, columns1] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < lines2; i++)
            {
                for (int j = 0; j < columns2; j++)
                {
                    matrix2[lines2, columns2] = random.Next(1, 10);
                }
            }
            for (int i = 0; i < lines2; i++)
            {
                for (int j = 0; j < columns2; j++)
                {
                    Console.Write(matrix2[lines2, columns2] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Задание2б");
            var linkedList = new LinkedList<int[]>();
            for (int i = 0; i < lines1; i++)
            {
                for (int j = 0; j < columns1; j++)
                {
                    matrix1[lines1, columns1] = random.Next(1, 10);
                }
            }
            for (int i = 0; i < lines1; i++)
            {
                for (int j = 0; j < columns1; j++)
                {
                    Console.Write(matrix1[lines1, columns1] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < lines2; i++)
            {
                for (int j = 0; j < columns2; j++)
                {
                    matrix2[lines2, columns2] = random.Next(1, 10);
                }
            }
            for (int i = 0; i < lines2; i++)
            {
                for (int j = 0; j < columns2; j++)
                {
                    Console.Write(matrix2[lines2, columns2] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] Matrixmultiplication(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] matrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        matrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return matrix;
        }
        static void Print(int[,] matrix1)
        {
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix1[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void temperature()
        {
            Console.WriteLine("Задание3a");
            int[,] tempinyear = new int[12, 30];
            Random random = new Random();
            string[] emptytemp = new string[0];
            var srznach = new double[12];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    tempinyear[i, j] = random.Next(-40, 40);
                    Console.Write("{0,11}", tempinyear[i, j]);
                }
                Console.WriteLine();
                for (int k = 0; i < tempinyear.GetLength(0); k++)
                {
                    int sum = 0;
                    for (int j = 0; j < tempinyear.GetLength(1); j++)
                    {
                        sum += tempinyear[i, j];
                    }
                    srznach[i] = sum / tempinyear.GetLength(1);
                }
            }
            double summ = 0;
            byte temp = 1;
            foreach (var prikolnenko in srznach)
            {
                Console.WriteLine($"Средние температуры за месяц {(Months)temp} составила : {prikolnenko}");
                summ += prikolnenko;
                temp++;
            }
            Console.WriteLine($"Средняя температура за весь год = {summ / 12}");
            Console.WriteLine("Задание3б");
            Dictionary<string, string> openWith =new Dictionary<string, string>(12);
            double[] temper = new double[30];
            var temperature = new Dictionary<string, string>
            {
                { "month", "temper" },
            };
            string[] emptytem = new string[0];
            var srznac = new double[12];
            for (int i = 0; i < 30; i++)
            {
                double sum = 0;
                temper[i] = random.Next(-40, 40);
                sum += temper[i];
                srznach[i] = sum / 12;
            }
            summ = 0;
            temp = 1;
            foreach (var prikolnenko in srznach)
            {
                Console.WriteLine($"Средние температуры за месяц {(Months)temp} составила : {prikolnenko}");
                summ += prikolnenko;
                temp++;
            }
            Console.WriteLine($"Средняя температура за весь год = {summ / 12}");
        }
    }
}