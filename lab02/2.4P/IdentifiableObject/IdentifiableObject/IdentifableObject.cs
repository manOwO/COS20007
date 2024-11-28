using System;
namespace SwinAdventure
{
	public class IdentifableObject
    {
		private List<string> _identifiers;


		public IdentifableObject(string[] idents)
		{
			_identifiers = new List<string>();
			foreach (string st in idents)
			{
				_identifiers.Add(st.ToLower());
			}
		}

		public bool AreYou(string id)
		{
			return _identifiers.Contains(id.ToLower());
		}

		public string FirstId
		{
			get
			{
				if (_identifiers.Count != 0)
				{
                    return _identifiers[0];
                }
				else
				{
					return "";
				}
					
			}
		}

		public void AddIdentifier(string id)
		{
			_identifiers.Add(id.ToLower());
		}
	}
}

