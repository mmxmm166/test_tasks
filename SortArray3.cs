using System;

namespace SortArray3
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] My_Array = {1, 3, 4, 5, 6, 2, 7 };
          // int[] My_Array = {1, 6, 3, 8, 9, 4, 5, 6, 2, 7};
          // int[] My_Array = {3, 2, 5, 8};
          // int[] My_Array = {1, 2, 3 , 5, 4,8,6,7};
            bool fl_sort = false;

            PrintArray(My_Array);
            while (!fl_sort)
            {
                int k = 0;
                fl_sort = true;
                for (int i = 0; i < My_Array.Length - 1; i++)
                {
                    if (i < My_Array.Length - 2)
                    {
                        //берем для сортировки три элемента начиная с i
                        k = i;
                    }
                    else
                    {
                        //берем для сортировки три элемента начиная с i-1
                        k = i - 1;
                    }

                    if ((My_Array[i + 1] < My_Array[i]) && (i < My_Array.Length - 2))
                    {
                        SortElements(My_Array, k);
                        PrintArray(My_Array);
                        fl_sort = false;
                    }

                    if ((i == My_Array.Length - 2) && (My_Array[i + 1] < My_Array[i]))
                    {
                        SortElements(My_Array, k);
                        PrintArray(My_Array);
                        if (fl_sort && !(My_Array[k] <= My_Array[k + 1] && My_Array[k + 1] <= My_Array[k + 2]))
                        {
                            Console.WriteLine("массив не сортируется");
                        }
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
