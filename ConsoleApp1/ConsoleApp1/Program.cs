using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{

    class Program
    {
       
        static void Main(string[] args)
        {
            bool inProgram = true;
            while (inProgram)
            {
                Console.WriteLine("Enter 1 if you want to execute 1st Block\nEnter 2 if you want to execute 2nd Block\nEnter 3 if you want to execute 3rd Block\nEnter 4 if you want to execute 4th Block\nEnter 0 if you want to exit");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Block1 block = new Block1();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Block2 block2 = new Block2();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Block3 block3 = new Block3();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Block4 block4 = new Block4();
                        Console.Clear();
                        break;
                    case 0:

                        inProgram = false;
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unexpected input\n");
                        break;

                }
            }


            
            
        }
    }
}
