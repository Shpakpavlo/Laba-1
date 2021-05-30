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
            int[,] array = new int[lin + 1, col];
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
            Console.WriteLine();

            int[] math = MathSum(array);
            for (int i = 0; i < math.Length; i++)
            {
                Console.Write(math[i] + "\t");
            }
            Console.WriteLine();

            array = Res(array, math);
            WriteConsol(array);
            Console.ReadKey();
        }
        static void auto(int[,] array)
        {
            Random rand = new Random();

            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    array[i, j] = rand.Next(-1, 10);

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

        static int[] MathSum(int[,] array)
        {
            int[] math = new int[array.GetUpperBound(1) + 1];
            int summ = 0;
            for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
            {
                for (int i = 0; i < array.GetUpperBound(0); i++)
                {
                    summ += array[i, j];

                }
                math[j] = summ;
                summ = 0;
            }
            return math;
        }

        static int[,] Res(int[,] array, int[] sum)
        {
            for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
            {
                int a = int.MaxValue;
                int b = j;
                for (int i = j; i < sum.Length; i++)
                {
                    if (a > sum[i])
                    {
                        a = sum[i];
                        b = i;
                    }
                }
                sum[b] = sum[j];
                for (int i = 0; i < array.GetUpperBound(0); i++)
                {
                    int tmp = array[i, j];
                    array[i, j] = array[i, b];
                    array[i, b] = tmp;
                }
            }
            return array;
        }

    }
}
