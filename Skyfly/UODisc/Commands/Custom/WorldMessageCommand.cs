namespace Server.Custom.Skyfly.UODisc.Commands.Custom
{
	[Command]
	public class WorldMessageCommand : ICommand
	{
		public bool IsDisabled { get; set; }

		public string Command => "c";

		public AccessLevel AccessLevel => AccessLevel.Player;

		public CommandType CommandType => CommandType.None;

		public string Description => "Sends a world chat message";

		public string Usage => "{prefix}c <world message>";

		public int MinParameters => 1;

		public void Invoke(CommandHandler handler, CommandEventArgs args)
		{
			// Knives Chat Method
			string msg = args.ParameterString.Substring(0);
			SendWorldChatMessage(args.User.Username, msg);

			// Normal Chat Method
			//string msg = $"{args.User.Username}: " + args.Parameters[0];
			//SendWorldChatMessage(0x49, false, msg);
		}

		public static void SendWorldChatMessage(int hue, bool ascii, string text)
		{
			World.Broadcast(hue, ascii, AccessLevel.Player, text);
		}
		public static void SendWorldChatMessage(string name, string msg)
		{
			Mobile WMMobile = new Mobile(0x9000000);
			WMMobile.Name = name;
			WMMobile.RawName = name;
			Knives.Chat3.Channel.GetByName("World").OnChat(WMMobile, msg);
		}
	}
}
