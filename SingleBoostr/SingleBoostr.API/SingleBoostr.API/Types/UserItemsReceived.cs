using System.Runtime.InteropServices;

namespace SingleBoostr.API.Types
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct UserItemsReceived
  {
    public ulong m_nGameID;
    public int Unknown;
    public int m_nItemCount;
  }
}
