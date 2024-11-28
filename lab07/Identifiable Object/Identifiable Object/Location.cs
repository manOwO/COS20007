using System;
namespace Identifiable_Object
{
	public class Location : Game_Object, IHaveInventory
	{
		
		private Inventory _inventory;

		public Location(string name, string desc) : base (new string[] { "location" }, name, desc)
		{
			_inventory = new Inventory();
		}

		public Game_Object Locate(string id)
		{
			if (AreYou(id))
			{
				return this;
			}
			return _inventory.Fetch(id);
		}

        public override string FullDescription
		{
			get
			{
				return $"The location is {Name}. \nDescription of this location:\n{FullDescription}\nItem is here:\n{Inventory.ItemList}";
            }
		} 

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}

