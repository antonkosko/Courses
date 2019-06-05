using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            Random rand = new Random();
            int start, end, sum=0;
            int min = -2147483648, max = 2147483647;
            double avg;
            //var sum = 0;
            
            while (true)
            {
                Console.WriteLine("Enter start value for random: ");
                string str = Console.ReadLine();
                bool result = Int32.TryParse(str, out start);
                if (result == true && start > min && start < max)
                {
                    break;
                }
                else
                    Console.WriteLine("Incorrect value or format. Please enter one more time. \n");
            }

            while (true)
            {
                Console.WriteLine("Enter end value for random: ");
                string str = Console.ReadLine();
                bool result = Int32.TryParse(str, out end);
                if (result == true && end > min && end < max)
                {
                    break;
                }
                else
                    Console.WriteLine("Incorrect value or format. Please enter one more time. \n");
            }
            
            //foreach (var element in array);  // try to use at home
            //sum += element;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(start, end);
                sum += array[i];
                Console.WriteLine("Array value " + i + ": " + array[i]);
            }
            
            Console.WriteLine("\nArray sum = " + sum);

            double sum1 = Convert.ToDouble(sum);
            double n = Convert.ToDouble(array.Length);
            avg = Math.Round(sum1 / n, 3);
            Console.WriteLine("\nAverage value is  " + avg);

            Console.ReadKey();
        }
    }
}
