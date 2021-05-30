using System;

namespace lr1
{
    class MainClass
    {
public static void Main(string[] args)
        {
            Console.Write("Рядки ");
            int lin = int.Parse(Console.ReadLine());
            Console.Write("Стовпчики ");
            int col = int.Parse(Console.ReadLine());
            int[,] array = new int[lin, col];
            Console.WriteLine("1 автоматично     2 вручну");
            int q = int.Parse(Console.ReadLine());
            if (q == 1)
            {
                auto(array);
            }
            else if (q == 2)
            {
                manual(array);
            }
            Changering(array);
            Console.ReadKey();
        }
        static void auto(int[,] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    array[i, j] = rand.Next(-100, 100);

                }
            }
            WriteConsol(array);
        }

        static void manual(int[,] array)
        {
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
            WriteConsol(array);
        }

        static void WriteConsol(int[,] array)
        {
            Console.WriteLine();
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }            
        }

        static void Changering(int[,] array)
        {
            int max = 0;
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    max = SearchFirsMax(array, i);
                }
                swap(ref array[i, max], ref array[i, 0]);
            }
            WriteConsol(array);
        }
        static void swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        static int SearchFirsMax(int[,] array, int i)
        {
            int x = 0;
            int max = int.MinValue;
            for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];
                    x = j;
                }
            }
            return (x);
        }

        
    }
}


