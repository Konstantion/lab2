using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Block1
    {
        int[] array;

        public Block1()
        {
            Console.WriteLine("Executing Block1");
            Console.WriteLine();
            Console.WriteLine("Enter the lenth of array:");

            int L =Convert.ToInt32(Console.ReadLine());
            array = new int[L];

            int type = InOut.getTypeOfArrayFill();
            if (type == 1) { InOut.fillWithRandom(array, TypeOfArray.Array1D); }
            else if (type == 2) { InOut.fillWithOneLine(array, TypeOfArray.Array1D); }
            else { InOut.fillWithLines(array, TypeOfArray.Array1D); }

                int[] cloneOfarray =(int[]) array.Clone();

           InOut.printArray(array);

           Console.WriteLine("Enter the key:");
           int n = Convert.ToInt32(Console.ReadLine());

           int pos = FindFirstIndex(array, n);            
           DeleteElementWithKey(ref array, pos);  
            
           InOut.printArray(array);

            if (pos != -1) { RefDiagram(cloneOfarray, array, pos); };
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
        }

        public void RefDiagram(int[] arrayOld,int[] arrayNew,int n)
        {
            
            Console.WriteLine("Дiаграма посилань");
            
            printArrayBlock1(arrayOld);
            for (int i = 0; i < arrayNew.Length; i++)
            {
                if (i < n) {
                    Console.Write("\t" + "    ↑");
                    
                }
                else if(i==n)
                {
                    Console.Write("\t"+ "         ↑");
                }
                else
                {
                    Console.Write("\t" + " ↑");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < arrayNew.Length; i++)
            {
                if (i < n)
                {
                    Console.Write("\t" + "    |");

                }
                else if (i == n)
                {
                    Console.Write("\t" + "        /");
                }
                else
                {
                    Console.Write("\t" + "/");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < arrayNew.Length; i++)
            {
                if (i < n)
                {
                    Console.Write("\t" + "    |");

                }
                else if (i == n)
                {
                    Console.Write("\t" + "       /");
                }
                else
                {
                    Console.Write("       " + "/");
                }
            }
            Console.WriteLine();
            printArrayBlock1(arrayNew);
        }
        public void DeleteElementWithKey(ref int[] array,int pos)
        {
            
            int l = array.Length;
            if (pos != -1)
            {
                for(int i = pos; i< l-1; i++)
                {
                    array[i] = array[i + 1];
                }
                Array.Resize(ref array, l - 1);
            }
            else { Console.WriteLine("Key  does not exist in the current array"); }
        }
        public int FindFirstIndex(int[] array,int n)
        {
           
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == n)
                {
                    return i;
                }
            }
            return -1;

        }

        public static void printArrayBlock1(int[] array)
        {
            
            int l = array.Length;
            Console.Write("\t┌");
            for (int i = 0; i < l; i++)
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
    }
}
