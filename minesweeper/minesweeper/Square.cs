using System;
namespace minesweeper
{
	public abstract class Square
	{
		private Position position;
		private bool marked;
		private string role;

		public Square(int x, int y, string Role)
		{
			position = new Position(x, y);
			marked = false;
			role = Role;
		}

		public Position GetPosition
		{
			get
			{
				return position;
			}
		}

		public bool Marked
		{
			get
			{
				return marked;
			}
			set
			{
				marked = value;
			}
		}

		public string RealRole
		{
			get
			{
				return role;
			}
			set
			{
				role = value;
			}
		}
	}
}

