using SteamKit2;
using SteamKit2.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HourBoostr
{
    internal sealed class ExtraHandler : ClientMsgHandler
    {
        private readonly Bot Bot;

        internal ExtraHandler(Bot bot)
        {
            Bot = bot;
        }

        internal sealed class PlayingSessionStateCallback : CallbackMsg
        {
            internal readonly bool PlayingBlocked;

            internal PlayingSessionStateCallback(JobID jobID, CMsgClientPlayingSessionState msg)
            {
                if ((jobID == null) || (msg == null))
                {
                    throw new ArgumentNullException(nameof(jobID) + " || " + nameof(msg));
                }

                JobID = jobID;
                PlayingBlocked = msg.playing_blocked;
            }
        }

        public override void HandleMsg(IPacketMsg packetMsg)
        {
            if (packetMsg == null)
            {
                //Logging.LogNullError(nameof(packetMsg), Bot.BotName);
                return;
            }

            switch (packetMsg.MsgType)
            {
                case EMsg.ClientPlayingSessionState:
                    HandlePlayingSessionState(packetMsg);
                    break;
            }
        }

        private void HandlePlayingSessionState(IPacketMsg packetMsg)
        {
            if (packetMsg == null)
            {
                //Logging.LogNullError(nameof(packetMsg), Bot.BotName);
                return;
            }

            ClientMsgProtobuf<CMsgClientPlayingSessionState> response = new ClientMsgProtobuf<CMsgClientPlayingSessionState>(packetMsg);
            Client.PostCallback(new PlayingSessionStateCallback(packetMsg.TargetJobID, response.Body));
        }
    }
}