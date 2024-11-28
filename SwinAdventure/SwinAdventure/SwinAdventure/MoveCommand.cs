using System;
namespace SwinAdventure
{
    public class Move_Command : Command
    {
        public Move_Command() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            string identifier;
            Path path;

            if (text[0] == "move" || text[0] == "go" || text[0] == "head" || text[0] == "leave")
            {
                if (text.Length == 1) return "Where do you want to move to?";
                else if (text.Length == 2)
                {
                    if (p.Location.Paths.Count == 0)
                    {
                        return $"No path is found at {p.Location.Name}.";
                    }
                    else
                    {
                        identifier = text[1];
                        path = p.Location.LocatePath(identifier);

                        if (path == null)
                        {
                            return $"Path towards {text[1]} is not found at {p.Location.Name}.";
                        }
                        else
                        {
                            path.MovePlayer(p);
                            return $"The {p.Name} just {path.FullDescription}";
                        }
                    }
                }
                else
                {
                    return "Error in move command input.";
                }
            }
            else
            {
                return "Error in move command input.";
            }
        }
    }
}
