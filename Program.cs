using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization; //подключаем коллекции

namespace Urok7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //дженерики и коллекции
            List<string> list = new List<string>(); //список, дин массив хранящий в себе строки
            list.Add("A");
            Stack<string> stack = new Stack<string>(); // кто первый вошел, будет самым последним в использовании
            Queue<string> queue = new Queue<string>(); //очередь - первый стоит в очереди, и первый используется

            //словари
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>(); //поиск определенного значения по ключу
            ArrayList arrayList = new ArrayList(); //динамический массив хранящий в себе что угодно, любого типа данных
            
            //хэш сет
            HashSet<string> keys = new HashSet<string>(); //хранит в себе уникальные значения

            //методы
            list.Add("asd"); //добавили в конец списка элемент
            list.Remove("a"); //удаляет первое вхождение указанного элемента
            list.Contains("s"); //ищеи есть ли такой элемент, до первого вхождения
            list.Clear(); //очищает полностью список
            int c = list.Count; //возвращает количество элементов в списке



            //работа со словарями
            keyValuePairs.Clear(); //удаление из словаря
            int c2 = keyValuePairs.Count; //
            keyValuePairs.Add(1, "Alice"); //добавление в словарь по ключу и значению
            keyValuePairs.Remove(1); //удаляем по ключу
            keyValuePairs.ContainsKey(1); //ищет есть ли такой ключ, озвращает булевое значение

            //работаем с хэш сетом
            keys.Add("asd"); //добавили в конец списка элемент
            keys.Remove("a"); //удаляет первое вхождение указанного элемента
            keys.Contains("s"); //ищеи есть ли такой элемент, до первого вхождения
            keys.Clear(); //очищает полностью список
            int c3 = keys.Count; //возвращает количество элементов в списке

            //Task1 создать англо-русскоязычный словать
            Dictionary<string, string> RusToEng = new Dictionary<string, string>()
            {
                { "Россия", "Russia"  },
                { "США", "USA" },
                { "Франция" ,"France" }
            };
            Dictionary<string, string> EngToRus = new Dictionary<string, string>()
            {

                {"Russia" , "Россия" },
                {"USA" , "США" },
                {"France", "Франция" }
            };
            Console.WriteLine("Выберите направление перевода: ");
            Console.WriteLine("1. Английский -> Русский ");
            Console.WriteLine("2. Русский -> Английский ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Введите слово на английском: ");
                string word = Console.ReadLine();

                if(EngToRus.ContainsKey(word))
                {
                    Console.WriteLine($"ПЕревод на русский: {EngToRus[word]}");
                }
                else
                {
                    Console.WriteLine("Перевод не выполнен");
                }
            }

            else if (choice == 1)
            {
                Console.WriteLine("Введите слово на русском: ");
                string word = Console.ReadLine();

                if (RusToEng.ContainsKey(word))
                {
                    Console.WriteLine($"ПЕревод на английский: {RusToEng[word]}");
                }
                else
                {
                    Console.WriteLine("Перевод не выполнен");
                }
            }
            else
            {
                Console.WriteLine("НЕт такой команды");
            }

            //Обобщения
            Person<int, string> tom = new Person<int, string>(546, "Tom", "dfkhbskd");
            Person<string, string> tomi = new Person<string, string>("abd123", "Tomi", "kfjbfd");

            int tomId = tom.Id;
            string tomiId = tomi.Id;

            Console.WriteLine(tomId);
            Console.WriteLine(tomiId);

            //Task2
            Point3D point = new Point3D(3, 4, 2);
            Console.WriteLine(point.ToString());

        }

        //Task3 персонаж в игре
        public class Character<T> where T : Iweapons
        {
            public string Name { get; set; }
            public string Race { get; set; }
            public T Weapon { get; set; }
            public int Strength {  get; set; }

            public Character(string name, string race, int strength, T weapon) 
            {
                Name = name;
                Race = race;
                Strength = strength;
                Weapon = weapon;
            }

            public void GetCharacterInfo()
            {
                Console.WriteLine($"Персонаж: {Name}, Раса: {Race}");
                Weapon.WeaponAbilities();
            }
        }

        public struct Sword : Iweapons //меч
        {
            public string Quality;
            public string WeaponType => "Меч";
            public int WeaponPower { get; }

            public Sword(int power, string guality)
            {
                WeaponPower = power;
                Quality = guality;
            }

            public void WeaponAbilities()
            {
                Console.WriteLine($"меч ({Quality}): сила {WeaponPower}, особые возможности - рубить");
            }


        }
        public struct Bow : Iweapons //лук
        {
            public int Range;
            public int Accuracy;
            public string WeaponType => "Лук";
            public int WeaponPower { get; }

            public Bow(int power, int range, int accuracy)
            {
                WeaponPower = power;
                Range = range;
                Accuracy = accuracy;
            }

            public void WeaponAbilities()
            {
                Console.WriteLine($"лук: сила ({WeaponPower}): дальность {Range}: точность {Accuracy}");
            }

        }

        public interface Iweapons
        {
            public string WeaponType { get; set; }
            public int WeaponPower { get; }
            public void WeaponAbilities();
        }




        //Task2 создаем трехмерное пространство
        public class Point2D<T> //указываем что он обобщенный
        {
            public T X {  get; set; }
            public T Y { get; set; }

            public Point2D(T x, T y)
            {
                X = x;
                Y = y;
            }

        }

        public class Point3D : Point2D <int>
        {
            public int Z {  get; set; }
            public Point3D(int x, int y, int z) : base(x,y)
            {
               Z = z;
            }
            public override string ToString() //перегрузка  Z
            {
                return $"x = {X}, y = {Y}, z = {Z}";
            }
        }




        //Обобщения
        public class Person<T1, K>
        {
            //реализация методов и полей класса, которые рбаотают с обобщенными типами Т1, Т2 ...
            public T1 Id { get; set; }
            public string Name { get; set; }
            public K Password { get; set; }
            public Person(T1 id, K password, string name)
            {
                Id = id;
                Name = name;
                Password = password;
            }

        }

        class MyBob<T>
        {
            T a, b;
            public MyBob()
            {
                a = default(T);
                b = default(T);
            }
        }
        //where - служит для ограничений, подойдет для класса или структуры и тд
        //имя_метода<T>(параметры) where T: тип_ограничения

    }
}
