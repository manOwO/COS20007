using System;
namespace Identifiable_Object
{
	public class Player : Game_Object, IHaveInventory
	{
		private Inventory _inventory;
		private string _description;
		private Location _location;

		public Player(string name, string desc) : base (new string[] {"me", "inventory"}, name, desc)
		{
			_inventory = new Inventory();
			_description = desc;
		}

		public Game_Object Locate(string id)
		{
			if (AreYou(id))
			{
				return this;
			}
			if (_inventory.Fetch(id) != null)
			{
				return _inventory.Fetch(id);
            }
			if (_location != null)
			{
				return _location.Locate(id);
			}
			else
			{
				return null;
			}
		}

		public override string FullDescription
		{
			get
			{
				return $"You are {Name}, {_description}. You are carrying:\n{_inventory.ItemList}"; 
			}
		}

		public Inventory Inventory
		{
			get
			{
				return _inventory;
			}
		}

		public Location Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}
	}
}

