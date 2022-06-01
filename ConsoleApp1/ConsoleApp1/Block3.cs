using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Block3
    {
        public int[][] jagArray;

        public Block3()
        {
                Console.WriteLine("Executing Block3");
                Console.WriteLine();

            int type = InOut.getTypeOfArrayFill();
            if (type == 1) { CreateArrayRandomBlock3(); }
            else if (type == 2) { CreateArrayOneLineBlock3(); }
            else { CreateArrayLinesBlock3(); }

            InOut.printArray(jagArray);

            int pos = RowWithMaxElement(jagArray);
            
            Array.Resize(ref jagArray, jagArray.Length+1);

            //Console.WriteLine(jagArray[jagArray.Length-1]==null);

            for(int i = jagArray.Length-2; i > pos; i--)
            {
                jagArray[i + 1] = jagArray[i]; 
            }
            jagArray[pos+1] = null;

            Console.WriteLine("\nAfter changes:\n");
            InOut.printArray(jagArray);

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
        }
        public int RowWithMaxElement(int[][] array)
        {
            int n = array.Length; ;
            //int m = array[0].Length;
            int row = 0;
            int max = array[0][0];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                        row = i;
                    }
                }
            }
            return row;
        }
        
        public void CreateArrayLinesBlock3()
        {
            Console.WriteLine("Enter sizes of the array separated by space:");
            int[] size = Array.ConvertAll(Console.ReadLine().Trim().Split(), Convert.ToInt32);
            int n = size[0];
            int m = size[1];
            jagArray = new int[n][];
            for(int i = 0; i < n; i++)
            {
                jagArray[i] = new int[m];
            }
            InOut.fillWithLines(jagArray, TypeOfArray.ArrayJag);
            


        }
        public void CreateArrayRandomBlock3()
        {
            Console.WriteLine("Enter sizes of the array separated by space:");
            int[] size = Array.ConvertAll(Console.ReadLine().Trim().Split(), Convert.ToInt32);
            int n = size[0];
            int m = size[1];
            jagArray = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jagArray[i] = new int[m];
            }
            InOut.fillWithRandom(jagArray, TypeOfArray.ArrayJag);



        }
        public void CreateArrayOneLineBlock3()
        {
            Console.WriteLine("Enter sizes of the array separated by space:");
            int[] size = Array.ConvertAll(Console.ReadLine().Trim().Split(), Convert.ToInt32);
            int n = size[0];
            int m = size[1];
            jagArray = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jagArray[i] = new int[m];
            }
            InOut.fillWithOneLine(jagArray, TypeOfArray.ArrayJag);



        }
    }
}
