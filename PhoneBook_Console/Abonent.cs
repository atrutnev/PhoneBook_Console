using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Console
{
    public class Abonent
    {
        public string Name { get; set; }

        public int phoneNumber { get; set; }

        public int index { get; set; }

        public override string ToString()
        {
            return String.Format("{0}. {1} - {2}", index, Name, phoneNumber);
        }
        public Abonent(int index, string Name, int phoneNumber)
        {
            this.index = index;
            this.Name = Name;
            this.phoneNumber = phoneNumber;
        }
        //public bool Findname(PhoneBookItem sp)
        //{
        //    return sp.lastName.Contains(lastName);
        //}
        //public bool Findnumber(PhoneBookItem sp)
        //{
        //    return sp.Number == Number;
        //}

    }
}
