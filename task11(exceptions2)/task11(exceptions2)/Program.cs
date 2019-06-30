using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11_exceptions2_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Userinfo John = new Userinfo { Name = "Johnqweqweqwe", Surname = "Doe", Age = 22 };
                string name = John.Name;
                if (name.Length > 10)
                {
                    throw new Exception("Name is to long.");
                }
                John.ShowInfo();
            }
            catch (AgeException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
