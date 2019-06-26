using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9_bank2_
{
    class Bank
    {
        private string bname;
        public string BName
        {
            get
            {
                return bname;
            }
            set
            {
                bname = value;
            }
        }

        public Bank(string bname)
        {
            this.BName = bname;
        }

        public virtual void Print()
        {
            Console.WriteLine("Bank name: " + bname);
        }
    }
}
