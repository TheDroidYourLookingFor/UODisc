namespace Server.Custom.Skyfly.UODisc.Commands.Custom
{
	[Command]
	public class TradeMessageCommand : ICommand
	{
		public bool IsDisabled { get; set; }

		public string Command => "t";

		public AccessLevel AccessLevel => AccessLevel.Player;

		public CommandType CommandType => CommandType.None;

		public string Description => "Sends a trade chat message";

		public string Usage => "{prefix}t <trade chat message>";

		public int MinParameters => 1;

		public void Invoke(CommandHandler handler, CommandEventArgs args)
		{
			// Knives Chat Method
			string msg = args.Parameters[0];
			SendTradeChatMessage(args.User.Username, msg);

			// Normal Chat Method
			//string msg = $"[Trade]{args.User.Username}: " + args.Parameters[0];
			//SendTradeChatMessage(0x49, false, msg);
		}

		public static void SendTradeChatMessage(int hue, bool ascii, string text)
		{
			World.Broadcast(hue, ascii, AccessLevel.Player, text);
		}
		public static void SendTradeChatMessage(string name, string msg)
		{
			Mobile WMMobile = new Mobile(0x9000000);
			WMMobile.Name = name;
			WMMobile.RawName = name;
			Knives.Chat3.Channel.GetByName("Trade").OnChat(WMMobile, msg);
		}
	}
}
