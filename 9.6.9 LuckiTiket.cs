using System;
					
public class Program
{
	public static void Main() //9.6.9.c#
	{
		int Nticket=124007,lpart,rpart;
	
		lpart=Nticket/1000;
		rpart=Nticket%1000;
//		Console.WriteLine(lpart + " " + rpart);
		lpart=lpart/100+(lpart/10)%10+lpart%10;
		rpart=rpart/100+(rpart/10)%10+rpart%10;
		
		if (lpart==rpart) 
			Console.WriteLine("билет счастливый, сумма левой части: " + lpart + " сумма правой части: " + rpart);
	}
}
