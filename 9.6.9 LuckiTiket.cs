/*
lpart - LeftPartNumberTicket
//левая часть номера билета

rpart - RightPartNumberTicket
//правая часть номера билета

Nticket - NumberTicket
//номер билета

*/
using System;
					
public class Program
{
	public static void Main() //9.6.9.c#
	{
		int NumberTicket=124007;
		int	LeftPartNumberTicket=NumberTicket/1000;
		int RightPartNumberTicket=NumberTicket%1000;
//		Console.WriteLine(LeftPartNumberTicket + " " + RightPartNumberTicket);
		LeftPartNumberTicket=LeftPartNumberTicket/100+(LeftPartNumberTicket/10)%10+LeftPartNumberTicket%10;
		RightPartNumberTicket=RightPartNumberTicket/100+(RightPartNumberTicket/10)%10+RightPartNumberTicket%10;
		
		if (LeftPartNumberTicket==RightPartNumberTicket) 
			Console.WriteLine("билет счастливый, сумма левой части: " + LeftPartNumberTicket + " сумма правой части: " + RightPartNumberTicket);
	}
}
