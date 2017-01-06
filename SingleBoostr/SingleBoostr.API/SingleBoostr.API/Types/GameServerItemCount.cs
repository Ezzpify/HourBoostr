using System.Runtime.InteropServices;

namespace SingleBoostr.API.Types
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct GameServerItemCount
  {
    public ulong SteamId;
    public ItemRequestResult Error;
    public uint ItemCount;
  }
}
