using System;
namespace minesweeper
{
	public class NotMine : Square
	{
		private int neighborsaround;

		public NotMine(int x, int y, string Role, int neighbors) : base(x, y, Role)
		{
			neighborsaround = neighbors;
		}

		public int LookNeighbors(int x, int y)
		{
			
			foreach (int xindex in Enumerable.Range(x-1, 3))
			{
				if (GameBoard.Board[i].GetPosition.X == xindex)
				{
					neighborsaround += 1;
				}
			}
		}
	}
}

