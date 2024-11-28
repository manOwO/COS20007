using System;
namespace minesweeper
{
	public class GameBoard
	{
		private List<Square> _board;
		private int _mines;

		public GameBoard()
		{
			_board = new List<Square>(81);
			_mines = 10;
		}

		public void CreateBoard()
		{

		}

		public List<Square> Board
		{
			get
			{
				return _board;
			}
		}

		public string PrintBoard
		{
			get
			{
				string boardprinted;
				foreach (Square square in _board)
				{
					if 
				}
				return boardprinted;
			}
		}
	}
}

