using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = new int[10];
            //Random rand = new Random();
            //int start, end, sum = 0;
            // int min = -2147483648, max = 2147483647;
            // double avg;

             
            string[] array = File.ReadAllText(@"C:\Users\ПК Мастер\Desktop\123.txt").Split(new char[] { ' ', ',' });
            int[] array1 = new int[array.Length];
            try
            {
                for (int i= 0; i < array.Length; i++)
                {
                    array1[i] = Convert.ToInt32(array[i]);
                    //Console.WriteLine(array1[i]);
                }
            }

            catch
            {
                Console.WriteLine("Incorrect values format in the txt file. Must contain only digits.");
                goto final;
            }
            //finally
            //{
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array1[i]);
                }
            //}
                       
            final: Console.ReadLine();
            
        }
    
    }
}
