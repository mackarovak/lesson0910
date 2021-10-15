using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace lesson0910
{
    public class Hospital
    {
        public static bool isWillHeal(Grandma grandmother, Hospital hospital)
        {

            for (int i = 0; i < grandmother.GetDiseases(grandmother).Count; i++)
            {
                for (int j = 0; j < hospital._diseasesHeal.Count; j++)
                {
                    if (grandmother.GetDiseases(grandmother)[i] == hospital._diseasesHeal[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Hospital(int capasity, List<string> diseasesHeal)
        {
            _capasity = capasity;
            _diseasesHeal = diseasesHeal;
        }

        private int _capasity;
        private List<string> _diseasesHeal = new List<string>();
    }
    public class Grandma
    {
        public List<string> GetDiseases(Grandma grandmother)
        {
            return grandmother._diseases;
        }
        public Grandma(List<string> diseases, string name, byte age)
        {
            _age = age;
            _name = name;
            _diseases = diseases;
        }
        private List<string> _diseases = new List<string>();
        private string _name;
        private byte _age;
    }
    public class Student
    {
        public static void delete(string surname, Dictionary<int, Student> students)
        {
            bool nasheloclass = false;
            for (int i = 1; i <= students.Count; i++)
            {
                if (students[i]._surname.Equals(surname))
                {
                    var temp = students[i];
                    students[i] = students[students.Count];
                    students[students.Count] = temp;
                    students.Remove(students.Count);
                    nasheloclass = true;
                }
            }
            if (nasheloclass)
            {
                Console.WriteLine("делитнули");

            }
            else
            {
                Console.WriteLine("не нашелся");
            }
        }
        public Student(string name, string surname, int age, string exam, short balls)
        {
            _name = name;
            _surname = surname;
            _age = age;
            _exam = exam;
            _balls = balls;
        }
        public void info()
        {
            Console.WriteLine($"{_name} {_surname} {_age} {_exam} {_balls}");
        }

        public static void Sort(Dictionary<int, Student> students)
        {
            for (int i = 0; i <= students.Count; i++)
            {
                for (int j = 1; j < students.Count - i; j++)
                {
                    if (students[j]._balls < students[j + 1]._balls)
                    {
                        var temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        private string _name;
        private string _surname;
        private int _age;
        private string _exam;
        private short _balls;
    }
    class Program
    {
        static void CountFives(int[] BBB_numbers, int[] SS_numbers) 
        {
            Console.WriteLine("Задание1");
            int bbb_count = 0;
            int ss_count = 0;
            for (int i = 0; i < BBB_numbers.Length; i++)
            {
                if (BBB_numbers[i] == 5)
                {
                    bbb_count += 1;
                }
            }
            for (int i = 0; i < SS_numbers.Length; i++)
            {
                if (SS_numbers[i] == 5)
                {
                    ss_count += 1;
                }
            }
            if (ss_count == bbb_count)
            {
                Console.WriteLine("Drinks All Round! Free Beers on Bjorg!");
            }
            else
            {
                Console.WriteLine("Ой, Бьорг - пончик! Ни для кого пива");
            }
        }

        static void ShuffleImages()
        {
            Console.WriteLine("Задание2");
            Random random = new Random();
            string PATH = @".\картинкидляксюши";
            string[] all_files = Directory.GetFiles(PATH);
            List<Image> images = new List<Image>(64);
            int[] indices = new int[64];
            for (int i = 0; i < all_files.Length; i++)
            {
                Image image = Image.FromFile(Path.Combine(PATH, all_files[i]));
                images[2 * i] = image;
                images[2 * i + 1] = image;
                indices[2 * i] = 2*i;
                indices[2 * i + 1] = 2*i+1;
            }
            Console.WriteLine("Initial indices: ", indices);
  
            // Fisher-Yates shuffling algorithm
            
            for (int i = indices.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = indices[j];
                indices[j] = indices[i];
                indices[i] = temp;
            }

            List <Image> shuffled_images = new  List <Image>(64);

            for (int i = 0; i < shuffled_images.Count; i++)
            {
                shuffled_images[i] = images[indices[i]];
            }

            Console.WriteLine("Shuffled indices: ", indices);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 3");           
            var text = new StreamReader("Students.txt");
            var students = new Dictionary<int,Student>();
            int countstudents = 0;
            while (text.ReadLine()!=null)
            {
                countstudents++;
            }
            text = new StreamReader("Students.txt");
            for (int i = 1; i <= countstudents; i++)
            {
                string[] prikolnenkotemp = text.ReadLine().Split();
                string name = prikolnenkotemp[0];                                          
                string surname = prikolnenkotemp[1];                           
                int year = int.Parse(prikolnenkotemp[2]);               
                string exam = prikolnenkotemp[3];               
                short balls = short.Parse(prikolnenkotemp[4]);
                students.Add(i, new Student(name, surname, year, exam, balls));             
            }
            bool flag = true;
            
            while (flag)
            {
                Console.WriteLine("введите <вывести>,<добавить>, <удалить>, <сортировать>, <выйти>");
                string input = Console.ReadLine();
                if (input.ToLower().Equals("вывести"))
                {
                    for (int i = 1; i <= students.Count; i++)
                    {
                        students[i].info();
                    }
                }
                else if (input.ToLower().Equals("выйти"))
                {
                    flag = false;
                }
                else if (input.ToLower().Equals("сортировать"))
                {
                    Student.Sort(students);
                }
                else if (input.ToLower().Equals("удалить"))
                {
                    Console.WriteLine("введите фамилию");
                    input = Console.ReadLine();
                    Student.delete(input, students);
                }
                else if (input.ToLower().Equals("добавить"))
                {
                    Console.WriteLine("o,студентик!");
                    string name = Console.ReadLine();
                    Console.WriteLine("введитe фамилию");
                    string surname = Console.ReadLine();
                    Console.WriteLine("введите год рождения");
                    int year = 0;
                    while(!int.TryParse(Console.ReadLine(),out year)||year<0)
                    {
                        Console.WriteLine("try again,please");
                    }
                    Console.WriteLine("введите экзамен");
                    string exam = Console.ReadLine();
                    Console.WriteLine("введите баллы за экзамен");
                    short result=0;
                    while (!short.TryParse(Console.ReadLine(),out result)||result<0)
                    {
                        Console.WriteLine("try again,please");
                    }
                    students.Add(students.Count + 1, new Student(name, surname, year, exam, result));
                }
                Console.WriteLine("для продолжения");
                Console.ReadLine();
                Console.Clear();             
            }

            Console.Clear();
        }

        static void GetSits()
        {
            Console.WriteLine("Задание4");
            bool[,] connections = new bool[,] { { false, true, false }, { true, false, false }, { false, false, false } };
            List<Dictionary<string, string>> queue = new List<Dictionary<string, string>>();
            var first = new Dictionary<string, string>
            {
                { "name", "0" },
                { "position", "1" },
                { "impudence", "1" },
                { "stupidity", "1" }
            };
            var second = new Dictionary<string, string>
            {
                { "name", "1" },
                { "position", "1" },
                { "impudence", "1" },
                { "stupidity", "0" }
            };
            var third = new Dictionary<string, string>
            {
                { "name", "2" },
                { "position", "1" },
                { "impudence", "0" },
                { "stupidity", "1" }
            };
            var array_of_people = new Dictionary<string, string>[] { first, second, third };
            for (int i = 0; i < array_of_people.Length; i++)
            {
                Boolean stupidity = Boolean.Parse(array_of_people[i]["stupidity"]);
                int impudence = Int32.Parse(array_of_people[i]["impudence"]);
                if (stupidity)
                {
                    if (impudence != 0)
                    {
                        queue.Insert(Math.Max(queue.Count - impudence, 0), array_of_people[i]);
                    }
                    else
                    {
                        queue.Insert(Math.Max(queue.Count - 1, 0), array_of_people[i]);
                    }
                }
                else
                {
                    queue.Insert(queue.Count, array_of_people[i]);
                }
            }
            var first_table = new Dictionary<string, int>
            {
                { "number", 0 },
                { "color", 0 },
            };
            var second_table = new Dictionary<string, int>
            {
                { "number", 1 },
                { "color", 1 },
            };
            var third_table = new Dictionary<string, int>
            {
                { "number", 2 },
                { "color", 2 },
            };

            var persons_on_tables = new Dictionary<int, List<string>>
            {
                { 0,  new List<string>()},
                { 1,  new List<string>()},
                { 2,  new List<string>()},
            };

            var array_of_tables = new Dictionary<string, int>[] { first_table, second_table, third_table };
            
            while (queue.Count > 0)
            {
                var new_person = queue.ElementAt(0);
                queue.RemoveAt(0);

                if (Boolean.Parse(new_person["stupidity"]))
                {
                    for (int i = 0; i < array_of_tables.Length; i++)
                    {
                        if (persons_on_tables[i].Count == 0)
                        {
                            persons_on_tables[i].Add(new_person["name"]);
                            break;
                        }
                        else
                        {
                            bool is_any_acquaintances = false;
                            for (int j = 0; j < persons_on_tables[i].Count; j++)
                            {
                                if (connections[Int32.Parse(new_person["name"]), Int32.Parse(persons_on_tables[i][j])])
                                {
                                    is_any_acquaintances = true;
                                }
                            }
                            if (!is_any_acquaintances)
                            {
                                if (Int32.Parse(new_person["impudence"]) > 0)
                                {
                                    if (persons_on_tables[i].Count < 4)
                                    {
                                        persons_on_tables[i].Add(new_person["name"]);
                                        break;
                                    }
                                }
                                else
                                {
                                    if (persons_on_tables[i].Count < 3)
                                    {
                                        persons_on_tables[i].Add(new_person["name"]);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                else if (Int32.Parse(new_person["impudence"]) > 0)
                {
                    for (int i = 0; i < array_of_tables.Length; i++)
                    {
                        bool is_any_acquaintances = false;
                        for (int j = 0; j < persons_on_tables[i].Count; j++)
                        {
                            if (connections[Int32.Parse(new_person["name"]), Int32.Parse(persons_on_tables[i][j])])
                            {
                                is_any_acquaintances = true;
                            }
                        }
                        if (is_any_acquaintances && persons_on_tables[i].Count < 4)
                        {
                            persons_on_tables[i].Add(new_person["name"]);
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < array_of_tables.Length; i++)
                    {
                        bool is_any_acquaintances = false;
                        for (int j = 0; j < persons_on_tables[i].Count; j++)
                        {
                            if (connections[Int32.Parse(new_person["name"]), Int32.Parse(persons_on_tables[i][j])])
                            {
                                is_any_acquaintances = true;
                            }
                        }
                        if (is_any_acquaintances && persons_on_tables[i].Count < 3)
                        {
                            persons_on_tables[i].Add(new_person["name"]);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Task 5");
            Console.WriteLine("Сколько бабушек?");
            int countGrand;
            while (!int.TryParse(Console.ReadLine(), out countGrand) || countGrand < 0)
            {
                Console.WriteLine("Неверный ввод");
            }

            var grandmothers = new List<Grandma>();
            for (int i = 0; i < countGrand; i++)
            {
                Console.WriteLine("Какое имя у бабушки?");
                string name = Console.ReadLine();
                byte age;
                Console.WriteLine("Введите возраст бабушки");
                while (!byte.TryParse(Console.ReadLine(), out age) || age < 0)
                {
                    Console.WriteLine("Неверно введен возраст");
                }
                Console.WriteLine("Сколько болезней у бабушки?");
                int countDis;
                while (!int.TryParse(Console.ReadLine(), out countDis) || countDis < 0)
                {
                    Console.WriteLine("Неверный ввод!");
                }
                var diseases = new List<string>(countDis);
                for (int j = 0; j < countDis; j++)
                {
                    Console.WriteLine("Введите название болезни");
                    diseases.Add(Console.ReadLine().ToLower());
                }
                grandmothers.Add(new Grandma(diseases, name, age));

            }
            int capasityInHospital1 = 4;
            var diseasesHealInHospital1 = new List<string> { "катаракта", "чума" };
            Hospital hospital1 = new Hospital(capasityInHospital1, diseasesHealInHospital1);

            int capasityInHospital2 = 6;
            var diseasesHealInHospital2 = new List<string> { "рак", "простуда", "морская болезнь", "излом кишки" };
            Hospital hospital2 = new Hospital(capasityInHospital2, diseasesHealInHospital2);
            List<Hospital> hospitals = new List<Hospital>();
            var queueGrand = new Queue<Grandma>();
            for (int i = 0; i < grandmothers.Count; i++)
            {
                for (int j = 0; j < hospitals.Count; j++)
                {
                    if (Hospital.isWillHeal(grandmothers[i], hospitals[j]))
                    {
                        queueGrand.Enqueue(grandmothers[i]);
                    }
                }
            }


        }
    }
}
