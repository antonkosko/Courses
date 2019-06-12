using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto car = new Auto();

            do {
                Console.WriteLine("Enter mark ");
                string mark = Console.ReadLine();
                car["mark"] = mark;

                Console.WriteLine(car["mark"]);

                /*Console.WriteLine("Enter model ");
                string model = Console.ReadLine();
                car["model"] = model;

                Console.WriteLine("Enter vin ");
                string vin = Console.ReadLine();
                car["vin"] = vin;

                Console.WriteLine("Enter year ");
                string year = Console.ReadLine();
                car["year"] = year;*/
            } while (!String.IsNullOrEmpty(car["mark"]));           

            Console.WriteLine("\n" + car["mark"] + "\n" + car["model"] + "\n" + car["vin"] + "\n" + car["year"]);

            Console.ReadKey();
        }
    }
    
    class Auto
    {
        string mark;
        string model;
        string vin;
        string year;
         
        /*public string AddVin
        {
            get
            {
                Console.WriteLine("\nVin: ");
                return vin;
            }
            set
            {
                if (value.Length > 15 || value.Length < 10)
                {
                    Console.WriteLine("\nIncorrect vin format was entered.");
                }
                else
                {
                    vin = value;
                }
            }
        }*/

        public string this[string select]
        {
            get
            {
                switch (select)
                {
                    case "mark": return "mark: " + mark;
                    case "model": return "model: " + model;
                    case "vin": return "vin: " + vin;
                    case "year": return "year: " + year;
                    default: return null;
                }
            }
            set
            {
                switch (select)
                {
                    case "mark":
                        if (value == "bmw" || value == "audi" || value == "mercedes")
                        {
                            mark = value;
                        }
                        else
                        {
                            Console.WriteLine("\nPossible values are - mercedes, bmw, audi. ");
                        }
                        break;
                    case "model":
                        model = value;
                        break;
                    case "vin":
                        if (value.Length > 15 || value.Length < 10)
                        {
                            Console.WriteLine("\nIncorrect vin format was entered.");
                        }
                        else
                        {
                            vin = value;
                        }
                        break;
                    case "year":
                        if (value.Length > 4 || value.Length < 4)
                        {
                            Console.WriteLine("\nIncorrect year format was entered.");
                        }
                        else
                        {
                            year = value;
                        }
                        break;
                }
            }
        }
    }
}
