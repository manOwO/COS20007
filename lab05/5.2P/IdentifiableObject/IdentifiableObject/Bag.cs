using System;
namespace Identifiable_Object
{
	public class Bag : Item, IHaveInventory
	{
		private Inventory _inventory;

		public Bag(string[] ids, string name, string desc) : base (ids, name, desc)
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
				string _desc = $"In the {Name} you can see:\n";
				_desc += _inventory.ItemList;
				return _desc;
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

