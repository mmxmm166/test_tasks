using System;

namespace SortArray3
{
    class Program
    {
        static void Main(string[] args)
        {
          int[] My_Array = {1, 3, 4, 5, 6, 2, 7 };
        //  int[] My_Array = {1,6,3,8,9, 4, 5, 6, 2, 7};
        //    int[] My_Array = {3, 2, 5, 8};

            bool fl = false;
            PrintArray(My_Array);
            while (!fl )
            {
                fl = true;
                for (int i = 0; i < My_Array.Length - 1; i++)
                {
                    if (My_Array[i + 1] < My_Array[i])
                    {
                        if (i < 2)
                        {
                            //берем для сортировки три элемента начиная с i
                            SortElements(My_Array, i);
                        }
                        else
                        {
                            //берем для сортировки три элемента начиная с i-1
                            SortElements(My_Array, i - 1);
                        }

                        PrintArray(My_Array);
                        fl = false;
                    }
                }
            }
            Console.ReadLine();
        }
 
        private static void PrintArray(int[] My_Array)
        {
            Console.WriteLine();
            foreach (var item in My_Array)
            {
                Console.Write(item + ", ");
            }
        }

        static void SortElements(int [] My_Array, int k )
        {
            int [] massiv = new int[3];
            int j = 0;
            while (!(My_Array[k] <= My_Array[k + 1] && My_Array[k] <= My_Array[k + 2])) 
            {
                for (int i = 0; i < 3; i++)
                {
                    massiv[i] = My_Array[i + k];
                }
                My_Array[k] = massiv[1];
                My_Array[k + 1] = massiv[2];
                My_Array[k + 2] = massiv[0];
                j++;
            } 
      
        }
    }
}
