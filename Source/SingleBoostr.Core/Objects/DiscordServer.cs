namespace SingleBoostr.Core.Objects
{
    public class DiscordServer
    {
        public string Name { get; private set; } = "Name Undefined";
        public string InviteCode { get; private set; } = "";
        public string InviteURL => $"https://{Name}.gg/{InviteCode}";
        public DiscordServer(string inviteCode, string name = "")
        {
            InviteCode = inviteCode;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name)) Name = name;
        }
    }
}
