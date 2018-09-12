using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("20!=");
        Factorial(20);
        Console.WriteLine();
        Console.WriteLine("25!=");
        Factorial(25);
        Console.WriteLine();
        Console.WriteLine("80!=");
        Factorial(80);
    }
    public static void Factorial(int n)
    {
        int s = 0;
        byte[] r = new byte[500];
        byte nRazr = 0;
        byte delta = 0;
        for (int k = 1; k <= n; k++)
        {
            if (k == 1)
                r[0] = 1;
            for (int i = 0; i <= nRazr; i++)
            {
                s = r[i] * k + delta;
                r[i] = (byte)(s % 10);
                delta = (byte)(s / 10);
                //	  if (k==1)  Console.WriteLine(i + "s " + s + " nRazr " + nRazr + " " + r[i] + " delta " + delta);
                if (i == nRazr)
                {
                    int j = 1;
                    while ((delta / j) >= 1)
                    {
                        r[nRazr + 1] = (byte)((delta / j) % 10);
                        nRazr++;
                        j *= 10;
                    }
                    delta = 0;
                    break;
                }
            }
        }

        for (int i = nRazr; i >= 0; i--)
        {
            if ((i + 1) % 3 == 0) Console.Write(" ");
            Console.Write(r[i]);
        }
   }
}
