using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11_exceptions2_
{
    class Userinfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 18)
                {
                    throw new AgeException("Forbidden for people younger than 18 years.");
                }
                if (value > 100)
                {
                    throw new AgeException("Forbidden for people older than 100 years.");
                }
                else
                {
                    age = value;
                }                
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nAge: {2}", Name, Surname, Age);
        }
    }
}
