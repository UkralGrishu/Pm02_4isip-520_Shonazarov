using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static (int[][], int) NorthwestCornerMethod(int[] supply, int[] demand, int[][] costs)
    {
        int[][] allocation = new int[supply.Length][]; for (int i = 0; i < supply.Length; i++)
        {
            allocation[i] = new int[demand.Length];
        }
        int[] supplyCopy = supply.ToArray(); int[] demandCopy = demand.ToArray();
        int totalCost = 0;
        int row = 0, col = 0; while (row < supply.Length && col < demand.Length)
        {
            int x = Math.Min(supplyCopy[row], demandCopy[col]);
            allocation[row][col] = x; supplyCopy[row] -= x;
            demandCopy[col] -= x; totalCost += x * costs[row][col];
            if (supplyCopy[row] == 0)
            {
                row++;
            }
            else
            {
                col++;
            }
        }
        return (allocation, totalCost);
    }
    static void Main()
    {
        int sum1 = 0;
        int sum2 = 0;

        int[] supply = { 40, 22, 38 };
        int[] demand = { 20, 15, 35, 30 }; int[][] costs = new int[][]
 {            new int[] { 5, 4, 6, 3 },
            new int[] { 7, 3, 3, 2 },            new int[] { 9, 5, 2, 6 }
 };
        foreach (int item in supply)
        {
            sum1 += item;
        }
        foreach (int item in demand)
        {
            sum1 += item;
        }
        if (sum1 != sum2)
        {
            Console.WriteLine("Задача не оптимальна");
            Console.ReadKey();
            return;
        }
        var (allocationNW, totalCostNW) = NorthwestCornerMethod(supply, demand, costs);
        Console.WriteLine("Наилучший план (северо-западный угол):"); Console.WriteLine("Allocation:");
        foreach (var row in allocationNW)
        {
            Console.WriteLine(string.Join(", ", row));
        }
        Console.WriteLine("Total Cost: " + totalCostNW);
        Console.ReadKey();
    }
}

