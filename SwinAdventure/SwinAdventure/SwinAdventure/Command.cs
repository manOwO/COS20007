using System;
namespace SwinAdventure
{
	public abstract class Command : IdentifableObject
	{
		public Command(string[] ids) : base(ids)
		{
		}

		public abstract string Execute(Player p, string[] text);
	}
}

