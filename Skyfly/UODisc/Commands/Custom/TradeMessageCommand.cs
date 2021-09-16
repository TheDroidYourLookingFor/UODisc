using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			string msg = $"[Trade]{args.User.Username}: " + args.Parameters[0];
			World.Broadcast(0x42, false, msg);
		}
	}
}
