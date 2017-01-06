using System.Runtime.InteropServices;

namespace SingleBoostr.API.Types
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct AppDataChanged
  {
    public uint m_nAppID;
    public bool m_eResult;
  }
}
