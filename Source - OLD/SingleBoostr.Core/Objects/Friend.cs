using Steam4NET;
using System.Text;

namespace SingleBoostr.Core.Objects
{
    public class Friend
    {
        private Steam Base { get; set; } = null;
        public ulong SteamID { get; private set; } = 0;
        public string Name => Base.SteamFriends015.GetFriendPersonaName(SteamID);
        public bool Added => Base.SteamFriends015.HasFriend(Base.Steam64ID, (int)EFriendFlags.k_EFriendFlagNone);
        public EPersonaState Status => Base.SteamFriends015.GetFriendPersonaState(new CSteamID(SteamID));

        public Friend(Steam steam, ulong steamID)
        {
            Base = steam;
            SteamID = steamID;
        }

        public bool Add() => !Added && Base.SteamFriends002.AddFriend(SteamID);
        public bool Remove() => Added && !Base.SteamFriends002.RemoveFriend(SteamID);
        public bool SendMessage(string content) => Base.SteamFriends002.SendMsgToFriend(SteamID, Steam4NET.EChatEntryType.k_EChatEntryTypeChatMsg, Encoding.UTF8.GetBytes(content));
        public string ReadMessage(int chatID, byte[] data, ref EChatEntryType type)
        {
            int message = Base.GetMessage(SteamID, chatID, data, ref type);

            return "";
        }
    }
}
