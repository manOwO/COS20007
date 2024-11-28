using System;
using System.ComponentModel;

namespace SwinAdventure
{
	public class Look_Command : Command
	{
		public Look_Command() : base(new string[] {"look"})
		{
		}

		public override string Execute(Player p, string[] text)
		{
			IHaveInventory container;
            string containerid;

            if (text.Length != 3 && text.Length != 5)
			{
				return "I don't know how to look like that";
			}
			else
			{
                if (text[0] != "look")
                {
                    return "Error in look input";
                }
				else
				{
					if (text[1] != "at")
					{
						return "What do you want to look at?";
                    }
                    else
					{
						
						if (text.Length == 5)
						{
							if (text[3] != "in")
							{
								return "Error in look input";
							}
							else
							{
                                containerid = text[4];
                                container = FetchContainer(p, containerid);
                            }
                        }
						else
						{
							container = p;
                            containerid = container.Name;
                        }

                        if (container == null)
						{
						    return $"I can't find the {containerid}";
                        }
						else
						{
                            return LookAtIn(text[2], container);
                        }
						
					}
				}
            }
			
			
		}

		private IHaveInventory FetchContainer(Player p, string containerid)
		{
			return p.Locate(containerid) as IHaveInventory;
		}

		private string LookAtIn(string thingId, IHaveInventory container)
		{
			if (container.Locate(thingId) == null)
			{
				return $"I can't find the {thingId} in the {container.Name}.";
			}
			else
			{
                return container.Locate(thingId).FullDescription;
            }
		}
	}
}

