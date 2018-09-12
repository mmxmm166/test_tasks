using System;
using System.IO;

namespace CompareDirectory
{
    class Program
    {
        //считать из файла список файлов в массив
        //получить список файлов в каталоге, поместить его в другой массив и записать в файл
        //сравнить массивы
        //сравниваем сначала массив новых файлов со старыми, затем сравниваем массив старых файлов с новыми
        public static void Main()
        {
            String my_path = Directory.GetCurrentDirectory() + "\\MyTest.txt";
            String TargetPath = @"d:\targetdir\";

            String [] NameFilesOld = FilesOldToArray(my_path);
            String [] NameFilesNew = FilesCurrentToArray(my_path, TargetPath);
            String [] NameFilesAdd = CompareArrays(NameFilesNew, NameFilesOld);
            String [] NameFilesDelete = CompareArrays(NameFilesOld, NameFilesNew);

            Console.WriteLine("список файлов, которые были в каталоге " + TargetPath);
            printArray(NameFilesOld);
            Console.WriteLine("список файлов, которые на данный момент в каталоге " + TargetPath);
            printArray(NameFilesNew);
            Console.WriteLine("файлы, которые добавили в каталог " + TargetPath);
            printArray(NameFilesAdd);
            Console.WriteLine("файлы, которые удалили из каталога " + TargetPath);
            printArray(NameFilesDelete);

            Console.ReadLine();
         }

        public static void printArray(String [] MyArray)
        {
            foreach (string s in MyArray)
            {
                if (s != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    
        static String[] CompareArrays(String [] NameFilesNew, String [] NameFilesOld)
        {
            String [] RezultCompare = new String [NameFilesNew.Length];
            int j = 0;

            for (int i = 0; i < NameFilesNew.Length; i++)
            {
                int k = 0;
                foreach (string f in NameFilesOld)
                {
                    if (f.Replace("\"", "") == NameFilesNew[i])
                    {
                        break;
                    }
                    else
                    {
                        if (k == NameFilesOld.Length-1)
                        {
                            RezultCompare[j] = NameFilesNew[i];
                            j++;
                        }
                        k++;
                    }
                }
            }

            return RezultCompare;
        }

        //считываем из файла список файлов в массиив
        static String[] FilesOldToArray(String current_path)
        {
            if (!File.Exists(current_path))
            {
                File.WriteAllText(current_path, "");
            }
            String NameFilesFromFile = File.ReadAllText(current_path);
            String [] stringSeparators = { "\",\"" , "\""};
            String [] NameFilesFromFileArray = NameFilesFromFile.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            return NameFilesFromFileArray;
        }

        //считываем данные из каталога файлов в массив и записываем список файлов из каталога в файл
        static String[] FilesCurrentToArray(String my_path, String TargetPath)
        {
            String [] NameFilesDirectoryArray = {};

            if (Directory.Exists(TargetPath))
            {
                NameFilesDirectoryArray = Directory.GetFileSystemEntries(TargetPath);

                String[] NameFilesDirectoryArrayRezult = new string[NameFilesDirectoryArray.Length];
                String NameFilesDirectory = "";
                int i = 1;
                foreach (string ss in NameFilesDirectoryArray)
                {
                    NameFilesDirectoryArrayRezult[i - 1] = Path.GetFileName(ss);
                    NameFilesDirectory += "\"" + Path.GetFileName(ss) + "\"";
                    if (i < NameFilesDirectoryArray.Length)
                    {
                        NameFilesDirectory += ",";
                    }
                    i++;
                }
                File.WriteAllText(my_path, NameFilesDirectory);
                return NameFilesDirectoryArrayRezult;
            }
            return null;
        }

     }
}
