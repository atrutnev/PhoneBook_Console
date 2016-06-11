using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook_Console
{
    public class PhoneBook : IEnumerable<Abonent>
    {
        public List<Abonent> abonents;

        public PhoneBook()
        {
            this.abonents = GetAbonents();
        }

        private static List<Abonent> GetAbonents()
        {
            List<Abonent> list = new List<Abonent>();
            return list;
        }

        
        public void AddAbonent()
        {
            Console.WriteLine("Введите имя: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Введите номер: ");
            int phoneNumber = int.Parse(Console.ReadLine());
            if (abonents.Count > 0)
            {
                int i = abonents.Count + 1;
                abonents.Add(new Abonent(i, Name, phoneNumber));
            }
            else abonents.Add(new Abonent(1, Name, phoneNumber));
        }

        public void DeleteAbonent()
        {
            Console.WriteLine("Введите порядковый номер абонента: ");
            int index = int.Parse(Console.ReadLine());
            abonents.RemoveAt(index - 1);
            foreach (var s in abonents)
            {
                if (s.index != abonents.IndexOf(s) + 1)
                {
                    s.index = abonents.IndexOf(s) + 1;
                }

            }
        }

        public void ModifyAbonent()
        {
            Console.WriteLine("Введите порядковый номер абонента:");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое имя абонента: ");
            abonents[index - 1].Name = Console.ReadLine();
            Console.WriteLine("Введите новый номер абонента: ");
            abonents[index - 1].phoneNumber = int.Parse(Console.ReadLine());
        }

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

            if (stringSearch != null)
            {
                foreach (var c in stringSearch)
                {
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


        public void ListAbonents()
        {
            foreach (var d in abonents)
            {
                Console.WriteLine(d);
            }
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
