using SingleBoostr.Core.Misc;

namespace SingleBoostr.Core.Objects
{
    public class SteamGroup
    {
        public string Name { get; private set; } = "Name Undefined";
        public ulong ID { get; private set; } = 0;
        public string URL => Utils.STEAM_URL("community", $"gid/{ID}");

        public SteamGroup(ulong groupID, string name = "")
        {
            ID = groupID;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name)) Name = name;
        }
    }
}
