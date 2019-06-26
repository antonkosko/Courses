using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9_bank2_
{
    abstract class Person
    {
        private string personname;
        private string personsurname;
        public string PersonName
        {
            get
            {
                return personname;
            }
            set
            {
                personname = value;
            }
        }

        public string PersonSurname
        {
            get
            {
                return personsurname;
            }
            set
            {
                personsurname = value;
            }
        }

        public Person (string personname, string personsurname)
        {
            this.PersonName = personname;
            this.PersonSurname = personsurname;
        }
    }
}
