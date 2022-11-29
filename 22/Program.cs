using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            int n  = Convert.ToInt32(Console.ReadLine());
            
            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1,n);

            Action<Task<int[]>> action = new Action<Task<int[]>>(SumandMaxArray);
            Task task2 = task1.ContinueWith(action);

            task1.Start();
            Console.ReadKey();
        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
                Console.WriteLine(array[i]);
            }
            return array;
        }
        static void SumandMaxArray(Task<int[]> task)
        {
            int[] array = task.Result;
            int s = 0;
            int j = array[0];
            for (int i = 0; i < array.Count() - 1; i++)
            {
               s+=array[i];
               if (array[i] > j)
                {
                    j= array[i];    
                }
            }
            Console.WriteLine($"Максимальное число - {j}, сумма всех чисел массива - {s}");
        }
       
    }
}
