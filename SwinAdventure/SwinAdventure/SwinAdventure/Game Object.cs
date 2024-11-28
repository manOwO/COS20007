using System;


namespace SwinAdventure
{
	public abstract class Game_Object : IdentifableObject
	{
		private string _description;
		private string _name;

		public Game_Object(string[] ids, string name, string desc) : base(ids)
		{
			_description = desc;
			_name = name;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string ShortDescription
		{
			get
			{
				return $"{_name} ({FirstId})";
			}
		}

		public virtual string FullDescription
		{
			get
			{
				return _description;
			}
		}
	}
}

