using System;
namespace SwinAdventure
{
	public class CommandProcessor
	{
		private List<Command> ListCommand;

		public CommandProcessor() 
		{
			ListCommand = new List<Command>
			{
				new Look_Command(),
				new Move_Command()
			};
		}

		public string CommandExecute(Player p, string[] text)
		{
			Command executing;
			foreach (Command command in ListCommand)
			{
				if (command.AreYou(text[0]))
				{
					executing = command;
					return executing.Execute(p, text);
				}
			}
			return "Invalid command input.";
		}
	}
}

