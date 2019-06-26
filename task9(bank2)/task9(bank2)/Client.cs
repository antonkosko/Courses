using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9_bank2_
{
    class Client: Person
    {
        private string clientlogin;
        private int clientindex;
        public string ClientLogin
        {
            get
            {
                return clientlogin;
            }
            set
            {
                clientlogin = value;
            }
        }

        public int ClientIndex
        {
            get
            {
                return clientindex;
            }
            set
            {
                clientindex = value;
            }
        }

        public Client(int clientindex,string clientlogin, string personname, string personsurname) : base(personname, personsurname)
        {
            this.ClientLogin = clientlogin;
            this.ClientIndex = clientindex;
        }
    }
}
