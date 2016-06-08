﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var pb = new PhoneBook();


            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("\t\tПростой консольный справочник на C#");
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Количество абонентов в справочнике - {0}", pb.Count());
                pb.ListAbonents();
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((new string('=', 79)));
                Console.WriteLine("Команды меню: ");
                Console.WriteLine("1.Создать запись\n2.Удалить запись\n3.Поиск\n4.Выход");
                Console.WriteLine((new string('=', 79)));
                Console.Write("Введите команду: ");
                Console.ForegroundColor = ConsoleColor.White;

                string com = Console.ReadLine();

                switch (com)
                {
                    case "1":
                        pb.AddAbonent();
                        break;
                    case "2":
                        pb.DeleteAbonent();
                        break;
                    case "3":
                        pb.SearchAbonent();
                         break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Недопустимая команда.\n");
                        break;
                }
            }
        }

        
    }
}