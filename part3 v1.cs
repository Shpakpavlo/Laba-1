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
            int[] sums = MinSum(array);
            int[] minsinxs;
            minsinxs = MinSumIndx(sums);

            array = Res(array, minsinxs);
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


        static int[] MinSumIndx(int[] sums)
        {
            int min = int.MaxValue;
            for (int i = 0; i < sums.Length; i++)
            {
                if (sums[i] < min)
                {
                    min = sums[i];
                }
            }

            int[] minsindexes = new int[sums.Length];
            int a = 0;
            for (int i = 0; i < sums.Length; i++)
            {
                if (sums[i] == min)
                {
                    minsindexes[a] = i;
                    a++;
                }
            }

            Array.Resize(ref minsindexes, a);
            return minsindexes;
        }

        static int[] MinSum(int[,] array)
        {
            int[] sums = new int[array.GetUpperBound(0)];
            int q = 0;
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    sums[q] += array[i, j];
                }
                q++;
            }

            return sums;
        }

        static int[,] Res(int[,] array, int[] sums)
        {
            int[] res = new int[array.GetUpperBound(1) + 1];
            for (int a = 0; a < sums.Length; a++)
            {
                for (int i = 0; i < array.GetUpperBound(0); i++)
                {
                    if (i == sums[a])
                    {
                        for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                        {
                            res[j] = array[i, j];
                        }
                        Array.Sort(res);
                        Array.Reverse(res);
                        for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                        {
                            array[i, j] = res[j];
                        }
                    }
                }
            }
            return array;
        }

        
    }
}
