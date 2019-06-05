
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." }; // trying to fix double value input (difference between '.' and ',')
            double y, h, a, b, x;
            int count=1;

            while (true)
            {
                Console.WriteLine("Enter the initial value of the argument: ");
                string str = Console.ReadLine();
                bool result = double.TryParse(str, out a);
                if (result == true && a!=0 && Double.IsInfinity(a)== false)
                {
                    break;
                }
                else
                    Console.WriteLine("Incorrect value or format. Please enter one more time. \n");
            }

            while (true)
            {
                Console.WriteLine("Enter the final value of the argument: ");
                string str = Console.ReadLine();
                bool result = double.TryParse(str, out b);
                if (result == true && b != 0 && b>a && Double.IsInfinity(b) == false)
                {
                    break;
                }
                else
                    Console.WriteLine("Incorrect value or format. Please enter one more time. \n");
            }

            while (true)
            {
                Console.WriteLine("Enter the increment step of the argument: ");
                string str = Console.ReadLine();
                bool result = double.TryParse(str, out h);
                if (result == true && h != 0 && Double.IsInfinity(h) == false)
                {
                    break;
                }
                else
                    Console.WriteLine("Incorrect value or format. Please enter one more time. \n");
            }
            
            Console.WriteLine("======== Results ========\n");
            DateTime start = DateTime.Now;

            for (x = a; x <= b; x += h)
            {
                y = (Math.Sign(Math.Pow(Math.E, 2.0 / 3) - x) * (Math.Pow(Math.Abs(Math.Pow(Math.E, 2.0 / 3) - x), 1.0 / 5))) / (Math.Pow((Math.Pow(x, 2) + Math.Pow(x, 3) + Math.Log(Math.Abs(x - 3.4))), 1.0 / 2)); // exercise 3
                Console.WriteLine(count +")" + "Result y = " + y + "\n");
                count++;
            }

            TimeSpan duration = DateTime.Now - start;
            Console.WriteLine("Function execution time: " + duration);
            Console.ReadKey();

        }
    }
}

