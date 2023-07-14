/*
old - TreeAgeOfYear
//возраст дерева в годах

h - HightCrownTree
// высота кроны дерева

w - WeightCrownTree
// - ширина кроны дерева

*/

using System;
					
public class Program
{
	public static void Main()
	{
		
		Tree [] Trees = new Tree[3];
		Tree MyTree1 = new Tree();
		MyTree1.TreeCrown=new int [,] {{0,1,0,0},{0,0,1,0},{0,1,0,0}};
		Trees[0]=MyTree1;
		
		Tree MyTree2 = new Tree();
		MyTree2.TreeCrown=new int [,] {{0,0,0,0,0,0,0},
									  {0,0,0,1,0,0,0},
									  {0,0,0,0,1,0,0},
									  {0,0,0,0,0,0,0},
									  {1,1,0,0,0,0,0},
									  {1,1,0,0,0,0,0}
									 };
		Trees[1]=MyTree2;
		
		Tree MyTree3 = new Tree();
		MyTree3.CrownFillRandom(5,6);
		Trees[2]=MyTree3;

		for (int i=0;i<3;i++)
		{
			Console.WriteLine("Дерево " + (i+1));
			Trees[i].View(true); // false - вид дерева + и ., true  - возраст веток
			for (int j=1;j<25;j++)
			{
				Trees[i].NextYear();
				Trees[i].View(true);
			}
		}
	}
	public class Tree
	{	
		public int [,] TreeCrown;
		public int TreeAgeOfYear;
		public Tree()
		{
			TreeAgeOfYear=1;
		}
		public void CrownFillRandom (int WeightCrownTree, int HightCrownTree) // заполнение дерева в первый год случайными ветками
		{
			Random rand=new Random(); 
			TreeCrown=new int [HightCrownTree,WeightCrownTree];
			for(int i=0; i<HightCrownTree; i++) 
				for(int j=0; j<WeightCrownTree; j++) 
				{
					TreeCrown[i,j]=rand.Next(0,2);
				}
		}
		public void NextYear () //дерево растет на один год
		{
			//растим ветки
			TreeAgeOfYear++;
			int HightCrownTree=TreeCrown.GetLength(0);
			int WeightCrownTree=TreeCrown.GetLength(1);

			for(int i=0; i<HightCrownTree; i++) 
			{
				for(int j=0; j<WeightCrownTree; j++) 
				{
					TreeCrown[i,j]++;
				}
			}
			//уничтожаем ветки
			if (TreeAgeOfYear%2!=0 ) // ветки уничтожаются в четный год
			{
				for(int i=0; i<HightCrownTree; i++) 
				{
					for(int j=0; j<WeightCrownTree; j++) 
					{
						if (TreeCrown[i,j]>=3)
						{	
							TreeCrown[i,j]=0;
							for (int l=0;l<=1;l++)
								for (int k=-1;k<=1;k+=2)
								{
									int iScan=0;
									int jScan=0;
											
									if (l==0) 
									{
										jScan=j;
										iScan=i+k;
									}
									else
									{
										iScan=i;
										jScan=j+k;
									};
									if ((iScan>=0) && (iScan<HightCrownTree) && (jScan>=0) && (jScan<w))
											if (TreeCrown[iScan,jScan]<=2)
											{
												TreeCrown[iScan,jScan]=0;
											}
							}
						}
					}
				}
			}
		}
		public void View (bool AsIs) // прорисовка дерева
		{
			Console.WriteLine("возраст дерева, лет: " + TreeAgeOfYear);

			for(int i=0; i<TreeCrown.GetLength(0); i++) 
			{
				for(int j=0; j<TreeCrown.GetLength(1); j++) 
				{
					if (AsIs)
						Console.Write(TreeCrown[i,j]);
					else 
						if (TreeCrown[i,j]>=1)
							Console.Write("+");
						else Console.Write(".");
				}
				Console.WriteLine();
			}
		}
		
		
	}
	
}
