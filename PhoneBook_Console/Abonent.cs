using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Console
{
    public class Abonent
    {

        //Поля
        public string Name { get; set; }

        public int phoneNumber { get; set; }

        public int index { get; set; }

        //Переопределение ToString
        public override string ToString()
        {
            return String.Format("{0}. {1} - {2}", index, Name, phoneNumber);
        }

        //Конструктор без параметров, необходимый для сериализации
        public Abonent()
        {

        }

        //Стандартный конструктор
        public Abonent(int index, string Name, int phoneNumber)
        {
            this.index = index;
            this.Name = Name;
            this.phoneNumber = phoneNumber;
        }
    }
}
