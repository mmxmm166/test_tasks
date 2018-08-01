using System;
					
public class Program
{
	public static void Main()
	{
		byte [,] SourceArray;
		byte [,] FArray;
		//исходный массив
		String [] Source = 
		{
			"4 6 029402 560202 029694 780288",
			"3 3 321 694 798",
			"15 15 900934352126360 119214144058652 979486082875698 322436531185165 887105930987956 232802644488782 302771989566798 073573207654780 311755785362806 909007939272309 395094805516080 562910805349811 993854324744973 768703404219199 630625270887199",
			"5 15 000000000000000 000000000000000 000000100000000 000000000000000 000000000000000"
		};
		//массив который нужно найти в исходном
		String [] Find = 
		{
			"2 2 02 94",
			"2 2 69 98",
			"2 2 99 99",
			"3 5 00000 00000 00001"
		};

		for (int i=0; i < Source.Length; i++)
		{
			SourceArray = FillArray(Source [i]);
			FArray = FillArray(Find[i]);
			Console.WriteLine("массив " + (i+1));
			if (!FindArray(SourceArray,FArray))
				Console.WriteLine("совпадений нет");
		}
	}
	
	public static byte [,] FillArray (String str) 
	{
		char [] ca = str.ToCharArray();
		
		int h = 0;
		int w = 0;
		int k = 0;
		
		for (int i = 1; i <= 2; i++)
		{	
            String s = "";
			do 
			{
			  s=s+ca[k];
			  k++;		
			}
            while (ca[k]!=' ');
			
		 	k++;
			
		 	if (i == 1) 
				h = Convert.ToInt32(s);	
			else 
				w = Convert.ToInt32(s);	
		}
		byte [,] array = new byte [h,w];
		
		for (int y = 0; y < h; y++)
		{
			for (int x = 0; x < w; x++ )
			{
				if (ca[k] == ' ') 
					k++;
				if (ca[k] != ' ' && k <=ca.Length-1 )
				{
					array[y,x] = Convert.ToByte(ca[k]-'0');
				}
			
				k++;
			}
		}		
		return array;
	}
	
	public static bool FindArray (byte [,] sArray, byte [,] fArray) 
	{
		bool Rezult = false;
		int Hs = sArray.GetLength(0);
		int Ws = sArray.GetLength(1);
		
		int Hf = fArray.GetLength(0);
		int Wf = fArray.GetLength(1);
		
		int SquareFArray = Hf*Wf;
		
		int fRezult = 0;
		
		for (int y = 0; y < Hs-Hf+1; y++)
		{
			for (int x = 0; x < Ws-Wf+1; x++)
			{	
				fRezult = 0;
				for (int yf = 0; yf < Hf; yf++ )
				{
					for (int xf = 0; xf < Wf; xf++)
					{
						//Console.WriteLine(" x " + x+" y " +y +" xf " +xf+" yf " +yf);
						if (sArray[y+yf,x+xf] == fArray[yf,xf])
							fRezult++;
						
						if (fRezult == SquareFArray) 
						{
							Console.WriteLine("есть совпадение, координаты начала x = " + (x+1) + ", y = " + (y+1));
							return true;
						}
					}
				}	

			}
		}
		return Rezult;
	}
}
