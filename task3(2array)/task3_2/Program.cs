using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[5, 5];
            int[] even = new int[25];
            int[] odd = new int[25];
            int k=0, n=0, l=0;
            int min = -2147483648, max = 2147483647;            
            Random rand = new Random();
            int start, end;

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
                        
            for (int i = 0; i < 5; i++)
            {
                int maxvalue = 0;
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = rand.Next(start, end);
                    Console.Write("{0,5} ", array[i, j]);

                    if (maxvalue < array[i, j])
                    {
                        maxvalue = array[i, j];
                    }

                    if (array[i, j] % 2 == 0)
                    {
                        l = array[i, j];
                        even[k] = l;
                        k++;
                    }
                    else
                    {
                        l = array[i, j];
                        odd[n] = l;
                        n++;
                    }
                }
                                
                Console.WriteLine(" |  Max value in " + (i+1) + " row = " + maxvalue);
                                
            }
            
            Console.WriteLine("\nEven value: ");
            //Array.Resize(ref even, k);
            for (k = 0; k < array.Length; k++)
            {
                Console.Write(even[k] + " ");
            }

            Console.WriteLine("\nOdd value: ");
            //Array.Resize(ref odd, n);
            for (n = 0; n < array.Length; n++)
            {
                Console.Write(odd[n] + " ");
            }

            Console.ReadKey();

        }
    }
}
