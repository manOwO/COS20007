using System;
namespace Identifiable_Object
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

