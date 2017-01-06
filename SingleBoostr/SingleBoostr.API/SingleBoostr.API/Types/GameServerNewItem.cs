using System.Runtime.InteropServices;

namespace SingleBoostr.API.Types
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct GameServerNewItem
  {
    public ulong SteamId;
    public ItemRequestResult Error;
    public uint Unknown1;
    public ulong ItemId;
    public uint Transaction;
    public uint Unknown3;
  }
}
