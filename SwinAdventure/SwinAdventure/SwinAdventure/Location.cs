using System;
namespace SwinAdventure
{
	public class Location : Game_Object, IHaveInventory
	{
		
		private Inventory _inventory;
		private List<Path> _paths;

		public Location(string name, string desc) : base (new string[] { "location" }, name, desc)
		{
			_inventory = new Inventory();
			_paths = new List<Path>();
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

		public Path LocatePath(string id)
		{
			foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

			return null;
        }

		public void AddPath(Path path)
		{
			_paths.Add(path);
		}

		public List<Path> Paths
		{
			get
			{
				return _paths;
			}
		}

		public string PathsList
		{
			get
			{
				string _pathslist; 
				if (_paths.Count == 0)
				{
					_pathslist = "There is no path you can go from this location";
				}
				else
				{
                    _pathslist = "Paths you can go via this location:";
                    foreach (Path path in _paths)
					{
						_pathslist += "\n" + path.FullDescription;
                    }
				}
				return _pathslist;
			}
		}
    }
}

