using System;
namespace SwinAdventure
{
	public interface IHaveInventory
	{
		public Game_Object Locate(string id);
		
		public string Name
		{
			get
			{
				return Name;
			}
		}
	}
}

