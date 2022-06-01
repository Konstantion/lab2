using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{

    public enum TypeOfArray : int
    {
        ArrayJag = 1,
        Array2D = 2,
        Array1D = 3
    }
    class InOut
    {
        public static int getTypeOfArrayFill()
        {
            
            Console.WriteLine("Enter 1 if you want to fill the array using random numbers\nEnter 2 if you want to fill array in one line\nEnter 3 if you want to fill array in separated lines");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n != 1 && n != 2 && n != 3) { Console.WriteLine("Wrong input \nUsing the default method(Random)");
                return 1; }
            Console.WriteLine();
            return n;
        }
        public static int amountOfJagArray(int[][] array)
        {
            int sum = 0;
            for (int n = 0; n < array.Length; n++)
            {
                for (int k = 0; k < array[n].Length; k++)
                {
                    sum++;
                }                                    
            }
            return sum;
        }

        public static void printArray(int[][] array)
        {
            Console.WriteLine("JaggedArray:");

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

                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        public static void printArray(int[,] array)
        {
            Console.WriteLine("Array2D:");
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            Console.Write("\t┌");
            for (int i = 0; i < m; i++)
            {
                Console.Write("────────");
            }
            Console.Write("┐");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("\t│" + array[i, j]);
                }
                Console.WriteLine("\t │");
            }
            
            Console.Write("\t└");
            for (int i = 0; i < m; i++)
            {
                Console.Write("────────");
            }
            Console.Write("┘");
            Console.WriteLine();
            
        }
        public static void printArray(int[] array)
        {
            Console.WriteLine("Array1D:");
            int l = array.Length;
            Console.Write("\t┌");
            for(int i = 0;i< l; i++)
            {
                Console.Write("────────");
            }
            Console.Write("┐");
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write("\t│" + i);
            }
            Console.WriteLine("\t │");
            Console.Write("\t└");
            for (int i = 0; i < l; i++)
            {
                Console.Write("────────");
            }
            Console.Write("┘");
            Console.WriteLine();
        }
        public static void fillWithRandom(Object array, TypeOfArray typeOfArrays)
        {
            Random r = new Random();

            switch ((int)typeOfArrays)
            {
                case 1:
                    int[][] tempJag = (int[][])array;
                    for (int i = 0; i < tempJag.Length; i++)
                    {
                        for (int j = 0; j < tempJag[i].Length; j++)
                        {
                            tempJag[i][j] = r.Next(-10, 10);
                        }
                    }
                    array = tempJag.Clone();
                    break;
                case 2:
                    int[,] temp2D = (int[,])array;
                    for (int i = 0; i < temp2D.GetLength(0); i++)
                    {
                        for (int j = 0; j < temp2D.GetLength(1); j++)
                        {
                            temp2D[i, j] = r.Next(-10, 10);
                        }
                    }
                    array = temp2D.Clone();
                    break;
                case 3:
                    int[] temp1D = (int[])array;
                    for (int i = 0; i < temp1D.Length; i++)
                    {
                        temp1D[i] = r.Next(-10, 10);
                    }
                    array = temp1D.Clone();
                    break;
            }
        }
        public static void fillWithLines(Object array, TypeOfArray typeOfArrays)
        {
            switch ((int)typeOfArrays)
            {
                case 1:
                    int[][] tempJag = (int[][])array;
                    for (int i = 0; i < tempJag.Length; i++)
                    {
                        Console.WriteLine($"Enter {tempJag[i].Length} elements of {i} row: ");
                        int[] fillingJag = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => Convert.ToInt32(x));
                        for (int j = 0; j < tempJag[i].Length; j++)
                        {
                            tempJag[i][j] = fillingJag[j];
                        }
                    }
                    array = tempJag.Clone();
                    break;
                case 2:
                    int[,] temp2D = (int[,])array;
                    for (int i = 0; i < temp2D.GetLength(0); i++)
                    {
                        Console.WriteLine($"Enter {temp2D.GetLength(1)} elements for {i} row: ");
                        int[] filling2D = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => Convert.ToInt32(x));
                        for (int j = 0; j < temp2D.GetLength(1); j++)
                        {
                            temp2D[i, j] = filling2D[j];
                        }
                    }
                    array = temp2D.Clone();
                    break;
                case 3:
                    int[] temp1D = (int[])array;
                    Console.WriteLine($"Enter {temp1D.Length} elements of array: ");
                    int[] filling1D = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => Convert.ToInt32(x));
                    for (int i = 0; i < temp1D.Length; i++)
                    {
                        temp1D[i] = filling1D[i];
                    }
                    array = temp1D.Clone();
                    break;
            }
        }
        public static void fillWithOneLine(Object array, TypeOfArray typeOfArrays)
        {
            switch ((int)typeOfArrays)
            {
                case 1:
                    int[][] tempJag = (int[][])array;
                    Console.WriteLine($"Enter {amountOfJagArray(tempJag)} elements");
                    int[] fillingJag = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => Convert.ToInt32(x));
                    int counter = 0;
                    for (int i = 0; i < tempJag.Length; i++)
                    {
                        for (int j = 0; j < tempJag[i].Length; j++)
                        {
                            tempJag[i][j] = fillingJag[counter];
                            counter++;
                        }
                    }
                    array = tempJag.Clone();
                    break;
                case 2:
                    int[,] temp2D = (int[,])array;
                    Console.WriteLine($"Enter {temp2D.GetLength(1)* temp2D.GetLength(0)} elements for row: ");
                    int[] filling2D = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => Convert.ToInt32(x));
                    for (int i = 0; i < temp2D.GetLength(0); i++)
                    {
                        for (int j = 0; j < temp2D.GetLength(1); j++)
                        {
                            temp2D[i, j] = filling2D[j+(i*temp2D.GetLength(1))];
                        }
                    }
                    array = temp2D.Clone();
                    break;
                case 3:
                    int[] temp1D = (int[])array;
                    Console.WriteLine($"Enter {temp1D.Length} elements of array: ");
                    int[] filling1D = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => Convert.ToInt32(x));
                    for (int i = 0; i < temp1D.Length; i++)
                    {
                        temp1D[i] = filling1D[i];
                    }
                    array = temp1D.Clone();
                    break;
            }
        }
    }
}
