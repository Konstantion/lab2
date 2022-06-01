using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Block2
    {
        private int[][] jagArrayOptimized;
        private int[][] jagArrayStandart;

        private Dictionary<int, int[]> dict;
        public static void printJagArray(int[][] array)
        {

            for (int n = 0; n < array.Length; n++)
            {

                Console.Write("Row({0}): ", n);

                if (array[n] != null)
                {
                    for (int k = 0; k < array[n].Length; k++)
                    {
                        Console.Write("{0} ", array[n][k]);
                    }
                    Console.WriteLine();
                    Console.WriteLine(array[n].GetHashCode().ToString("X"));
                }
                else { Console.WriteLine(); }
            }
            Console.WriteLine();

        }
        
        
        private int getSum(int n)
        {
            int sum = 0;

            while (n != 0)
            {
                sum = sum + n % 10;
                n = n / 10;
            }

            return sum;
        }
        public Block2()
        {
            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            
            StandartMethod(n);
            OptimizedMethod(n);


            Console.WriteLine("Enter 1 if you want to see jagArrayOptimized\nEnter 2 if you want to see jagArrayStandar\nEnter 3 if you want to see both of them\nEnter 4 if you don't want to see arrays");
            int op = Convert.ToInt32(Console.ReadLine());
            if (op == 1) { Console.WriteLine("____________jagArrayOptimized____________"); printJagArray(jagArrayOptimized); }
            else if (op == 2) { Console.WriteLine("____________jagArrayStandart____________"); printJagArray(jagArrayStandart); }
            else if (op == 3) { Console.WriteLine("____________jagArrayOptimized____________"); printJagArray(jagArrayOptimized); 
                                 Console.WriteLine("____________jagArrayStandart____________"); printJagArray(jagArrayStandart); }
            
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
        }

        private void OptimizedMethod(int n)
        {
            Console.WriteLine("\nExecuting optimized method\n");
            long bytesStart = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine("Bytes(Start) : "+bytesStart);
            dict = new Dictionary<int, int[]>();
            /*bytes = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine("Bytes(After declaration dict): " + bytes);*/
            jagArrayOptimized = new int[n][];
            for (int i = 1; i < n; i++)
            {
                int num = getSum(i);
                if (dict.ContainsKey(num))
                {
                    jagArrayOptimized[i] = dict[num];
                }
                else
                {
                    
                    jagArrayOptimized[i] = new int[n / num];
                    for (int j = 1; j <= n / num; j++)
                    {
                        jagArrayOptimized[i][j-1] = num * j;
                        
                    }
                    dict.Add(num, jagArrayOptimized[i]);
                }
            }
            long bytesEnd = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine("Bytes(End): "+bytesEnd);
            Console.WriteLine($"Betes used {bytesEnd-bytesStart}" + "\n");
        }

        private void StandartMethod(int n)
        {
            Console.WriteLine("\nExecuting standart  method\n");
            long bytesStart = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine("Bytes(Start): " + bytesStart);
            jagArrayStandart = new int[n][];
            for (int i = 1; i < n; i++)
            {
                int num = getSum(i);                
                
                jagArrayStandart[i] = new int[n / num];
                for (int j = 1; j <= n / num; j++)
                {
                    jagArrayStandart[i][j-1] = num * j;                    
                }              
                
            }
            long bytesEnd = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine("Bytes(End): " + bytesEnd);
            Console.WriteLine($"Betes used {bytesEnd - bytesStart}");
        }
    }
}
