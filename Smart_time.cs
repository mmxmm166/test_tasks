/*
пример где рекомендации из "Имена переменных"  применены и переменные уже названы понятно
*/

using System;

public class Program
{
    public static void Main()
    {

        for (int h = 0; h <= 23; h++)
        {
            for (int m = 0; m <= 59; m++)
            {
                Console.WriteLine(h + ":" + m + " " + TimeForHuman(h, m));
            }
        }
    }

    public static String TimeForHuman(int Hours, int Minuts)
    {
        String TypeMinuts = "";
        String Rezult = "";
        String[] NameMinuts = {
                                "одна",
                                "две",
                                "три",
                                "четыре",
                                "пять",
                                "шесть",
                                "семь",
                                "восемь",
                                "девять",
                                "десять",
                                "одиннадцать",
                                "двенадцать",
                                "тринадцать",
                                "четырнадцать",
                                "пятнадцать",
                                "шестнадцать",
                                "семнадцать",
                                "восемнадцать",
                                "девятнадцать",
                                "двадцать",
                                "тридцать"
        };

        String[] NameMinutsWithout =  {
                                        "одной",
                                        "двух",
                                        "трех",
                                        "четырех",
                                        "пяти",
                                        "шести",
                                        "семи",
                                        "восьми",
                                        "девяти",
                                        "десяти",
                                        "одиннадцати",
                                        "двенадцати",
                                        "тринадцати",
                                        "четырнадцати",
                                        "пятнадцати",
                                        "шестнадцати",
                                        "семнадцати",
                                        "восемнадцати",
                                        "девятнадцати",
                                        "двадцати"
        };

        String[] NameHours =  {
                                    "к полуночи",
                                    "первого",
                                    "второго",
                                    "третьего",
                                    "четвертого",
                                    "пятого",
                                    "шестого",
                                    "седьмого",
                                    "восьмого",
                                    "девятого",
                                    "десятого",
                                    "одиннадцатого",
                                    "двенадцатого",
                                    "первого"
        };

        String[] NameHoursZero = {
                                    "полночь",
                                    "час",
                                    "два",
                                    "три",
                                    "четыре",
                                    "пять",
                                    "шесть",
                                    "семь",
                                    "восемь",
                                    "девять",
                                    "десять",
                                    "одиннадцать",
                                    "двенадцать",
                                    "час"
        };


        if (Hours == 23 && Minuts > 0)
            Hours = -1;

        if (Hours >= 12)
            Hours -= 12;

        if (Minuts <= 30)
        {
            if (Minuts == 1 || Minuts == 21)
                TypeMinuts = " минута ";

            else if ((Minuts >= 2 && Minuts < 5) || (Minuts >= 22 && Minuts < 25))
                TypeMinuts = " минуты ";

            else if (Minuts >= 5)
                TypeMinuts = " минут ";


            if (Minuts == 0)
                Rezult = NameHoursZero[Hours];

            else if (Minuts <= 20)
                Rezult = NameMinuts[Minuts - 1] + TypeMinuts + NameHours[Hours + 1];

            else if (Minuts == 30)
                Rezult = NameMinuts[20] + TypeMinuts + NameHours[Hours + 1];

            else
                Rezult = NameMinuts[19] + " " + NameMinuts[Minuts - 21] + TypeMinuts + NameHours[Hours + 1];
        }
        else
        {
            Minuts = 60 - Minuts;

            if (Minuts == 1 || Minuts == 21)
                TypeMinuts = " минуты ";

            else if (Minuts >= 2)
                TypeMinuts = " минут ";

            if (Minuts >= 1 && Minuts <= 20)
                Rezult = "без " + NameMinutsWithout[Minuts - 1] + TypeMinuts + NameHoursZero[Hours + 1];

            else
                Rezult = "без " + NameMinutsWithout[19] + " " + NameMinutsWithout[Minuts - 21] + TypeMinuts + NameHoursZero[Hours + 1];

        }
        return Rezult;
    }
}
