using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Block4
    {
        int[][] matrixA;
        int[] V;
        int[,] matrixB;
        public Block4()
        {
            Console.WriteLine("Executing Block4\n");

            matrixA = CreateEmptyMatrix();
            fillWithRandom(matrixA,TypeOfArray.ArrayJag);

            InOut.printArray(matrixA);

            V = MatrixToArray(matrixA);
            InOut.printArray(V);

            matrixB = ArrayToMatrixTest(V);
            InOut.printArray(matrixB);

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }
        

        private int[,] ArrayToMatrixTest(int[] array)
        {
            Array.Reverse(array);
           
            int[] firstIndex = array.Where((x, i) => i % 3 == 0).ToArray();
            int[] values = array.Where((x, i) => i % 3 == 2).ToArray();
            int[] secondIndex = array.Where((x, i) => i % 3 == 1).ToArray();
            int n = firstIndex.Max() + 1;
            int m = secondIndex.Max() + 1;
            int[,] result = new int[n, m];
            for (int i = 0; i < values.Length; i++)
            {
                result[firstIndex[i], secondIndex[i]] = values[i];
            }


            return result;
        }
        private int[] MatrixToArray(int[][] matrix)
        {
            int[] array = new int[InOut.amountOfJagArray(matrix)*3];
            int indent = 0;
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    array[0 + 3 * j+indent] = i;
                    array[1 + 3 * j+indent] = j;
                    array[2 + 3 * j+indent] = matrix[i][j];
                }
                indent += 3 * matrix[i].Length;
            }
            return array;
        }
        private int[][] CreateEmptyMatrix()
        {
            Console.WriteLine("Enter the amount of rows:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] matrix = new int[n][];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter the number of elements in {i+1} (st,nd,rd,th) row:");
                int m = Convert.ToInt32(Console.ReadLine());
                matrix[i] = new int[m];
            }
            Console.Clear();
            Console.WriteLine("Executing Block4\n");
            return matrix;
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
                            tempJag[i][j] = r.Next(0, 10);
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
    }
}
