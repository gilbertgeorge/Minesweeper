using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemixTechScreen
{
	class Program
	{
		static void Main(string[] args)
		{
			const int rows = 4;
			const int columns = 7;
			const int numberOfMine = 4;

			char[,] boardState= new char[rows, columns];

			Random rnd = new Random();

			//populate board with mines
			for (int i = 1;i <= numberOfMine;i++)
			{
				var y = rnd.Next(0, columns);
				var x = rnd.Next(0, rows);

				if (boardState[x,y] == '*')
				{
					i--;
				}

				boardState[x,y] = '*';
			}

			//print board
			for (int x = 0; x < rows; x++)
			{
				string row = string.Empty;
				for (int y = 0; y < columns; y++)
				{
					if (boardState[x, y] != '*')
					{
						int count = 0;
						if (x != 0 && y != 0 && boardState[x - 1,y - 1]  == '*')
						{
							count++;
						}
						if (x != 0 && boardState[x - 1 , y] == '*')
						{
							count++;
						}
						if (x != 0 && y != columns - 1 && boardState[x - 1, y + 1] == '*')
						{
							count++;
						}
						if (y != 0 && boardState[x, y - 1] == '*')
						{
							count++;
						}
						if (y != columns-1 && boardState[x, y + 1] == '*')
						{
							count++;
						}
						if (x != rows-1 && y != 0 && boardState[x+1, y - 1] == '*')
						{
							count++;
						}
						if (x != rows-1 && boardState[x+1, y] == '*')
						{
							count++;
						}
						if (x != rows-1 && y != columns-1 && boardState[x+1, y + 1] == '*')
						{
							count++;
						}

						boardState[x, y] = count.ToString()[0];
					}

					row += boardState[x,y];
				}

				Console.WriteLine(row);
			}

			Console.Read();
		}
	}
}
