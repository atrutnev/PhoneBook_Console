using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhoneBook_Console
{
    public class PhoneBook : IEnumerable<Abonent>
    {
        //Инициализация List
        public List<Abonent> abonents;
        
        //Инициализация класса
        public PhoneBook()
        {
            this.abonents = GetAbonents();
        }

        //Начальное заполнение списка. Если в директории с программой присутствует файл "AbonentsList.xml",
        //заполнить список значениями из него. В противном случае - вернуть пустой список.
        private static List<Abonent> GetAbonents()
        {
            List<Abonent> list = new List<Abonent>();
            var filename = "AbonentsList.xml";
            if (File.Exists(filename))
            {
                var xml = string.Empty;
                xml = File.ReadAllText(filename);
                var serializer = new XmlSerializer(typeof(List<Abonent>));
                var reader = new StringReader(xml);
                list = serializer.Deserialize(reader) as List<Abonent>;
                return list;
            }      
            return list;
        }

        //Метод добавления записи
        public void AddAbonent()
        {
            Console.WriteLine("Введите имя: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Введите номер: ");
            int phoneNumber = int.Parse(Console.ReadLine());
            //Простановка порядкового номера записи
            if (abonents.Count > 0)
            {
                int i = abonents.Count + 1;
                abonents.Add(new Abonent(i, Name, phoneNumber));
            }
            else abonents.Add(new Abonent(1, Name, phoneNumber));
        }


        //Метод удаления записи
        public void DeleteAbonent()
        {
            Console.WriteLine("Введите порядковый номер абонента: ");
            int index = int.Parse(Console.ReadLine());
            abonents.RemoveAt(index - 1);
            //Правильная расстановка порядковых номеров записей после удаления одной из них на основе индекса List<>
            foreach (var s in abonents)
            {
                if (s.index != abonents.IndexOf(s) + 1)
                {
                    s.index = abonents.IndexOf(s) + 1;
                }

            }
        }

        //Метод изменения записи
        public void ModifyAbonent()
        {
            Console.WriteLine("Введите порядковый номер абонента:");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое имя абонента: ");
            abonents[index - 1].Name = Console.ReadLine();
            Console.WriteLine("Введите новый номер абонента: ");
            abonents[index - 1].phoneNumber = int.Parse(Console.ReadLine());
        }

        //Метод поиска записи
        public void SearchAbonent()
        {
            Console.WriteLine("Введите первые буквы имени или номер: ");
            var stringSearch = Console.ReadLine().ToLower();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((new string('=', 79)));
            Console.WriteLine("\t\tПростой консольный справочник на C#");
            Console.WriteLine((new string('=', 79)));
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Результаты поиска:");

            //Если строка поиска непустая
            if (stringSearch != null)
            {
                foreach (var c in stringSearch)
                {
                    //Если введены буквы, то поиск производится по имени абонента. 
                    if (char.IsLetter(c))
                    {
                        List<Abonent> abonentsSearch = abonents.FindAll(t => t.Name.ToLower().StartsWith(stringSearch));
                        foreach (var s in abonentsSearch)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("Для возврата к основному меню нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }
                    //Если введены цифры, то поиск производится по номеру абонента.
                    else if (char.IsDigit(c))
                    {
                        List<Abonent> abonentsSearch = abonents.FindAll(t => t.phoneNumber.Equals(int.Parse(stringSearch)));
                        foreach (var s in abonentsSearch)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("Для возврата к основному меню нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось распознать поисковый запрос!");
                        break;
                    }
                }
            }
        }

        //Вывод списка на экран
        public void ListAbonents()
        {
            foreach (var d in abonents)
            {
                Console.WriteLine(d);
            }
        }

        //Метод сохранения списка в файл "Abonents.xml" в директорию с программой.
        public void SaveAbonentsToXml()
        {
            var serializer = new XmlSerializer(typeof(List<Abonent>));
            var writer = new StringWriter();
            serializer.Serialize(writer, abonents);
            var xml = writer.ToString();
            File.WriteAllText("AbonentsList.xml", xml);
        }

        public IEnumerator<Abonent> GetEnumerator()
        {
            return abonents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
