﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			string msg = $"[World]{args.User.Username}: " + args.Parameters[0];

			World.Broadcast(0x49, false, msg);
			//args.Channel.SendEmbedMessage("Sent message").ConfigureAwait(false);
		}
	}
}
