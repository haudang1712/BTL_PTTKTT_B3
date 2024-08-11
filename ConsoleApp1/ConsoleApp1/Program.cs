﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int Knapsack(int[] weights, int[] values, int capacity)
        {
            int n = weights.Length;

            int[,] dp = new int[n + 1, capacity + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        dp[i, w] = 0;
                    }
                    else if (weights[i - 1] <= w)
                    {
                        dp[i, w] = Math.Max(values[i - 1] + dp[i - 1, w - weights[i - 1]], dp[i - 1, w]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[n, capacity];
        }

        static void Main()
        {
            Console.InputEncoding = UnicodeEncoding.Unicode;
            Console.OutputEncoding = UnicodeEncoding.Unicode;
            int[] weights = { 1, 3, 4, 5 };
            int[] values = { 1, 4, 5, 7 };
            int capacity = 7;

            int maxValue = Knapsack(weights, values, capacity);

            Console.WriteLine("Giá trị lớn nhất có thể đạt được là: " + maxValue);
            Console.ReadKey();
        }
    }

}
