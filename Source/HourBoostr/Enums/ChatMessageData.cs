using System;

namespace HourBoostr.Enums
{
    internal class ChatMessageData
    {
        /// <summary>
        /// Steam account id
        /// </summary>
        public uint AccountId { get; set; }


        /// <summary>
        /// DataTime when we received the message
        /// </summary>
        public DateTime DateReceived { get; set; }
    }
}
