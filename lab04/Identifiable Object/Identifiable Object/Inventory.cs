using System;
namespace Identifiable_Object
{
	public class Inventory
	{
		private List<Item> _items;

		public Inventory()
		{
			_items = new List<Item>();
		}

		public bool HasItem(string id)
		{
			foreach (Item item in _items)
			{
				if (item.AreYou(id))
				{
					return true;
				}
			}
			return false;
		}

		public void Put(Item itm)
		{
			_items.Add(itm);
		}

		public Item Take(string id)
		{
			Item itemTaken = this.Fetch(id);
			_items.Remove(itemTaken);
			return itemTaken;
		}

		public Item Fetch(string id)
		{
			foreach (Item item in _items)
			{
				if (item.AreYou(id))
				{
					return item;
				}
			}

			return null;
		}

		public string ItemList
		{
			get
			{
				string itemlistreturn = "";
				foreach (Item item in _items)
				{
					itemlistreturn += $"{item.ShortDescription}\n";
				}
				return itemlistreturn;
			}
		}
	}
}

