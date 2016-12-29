// Decompiled with JetBrains decompiler
// Type: SAM.API.Types.CallbackMessage
// Assembly: SAM.API, Version=6.3.0.804, Culture=neutral, PublicKeyToken=null
// MVID: 7DF108F6-41E2-4750-9029-3DA2C808D0A1
// Assembly location: E:\Dropbox\SPARA\Develop\HourBoostr\SingleBoostr\SingleBoostr\SAM.API.dll

using System;
using System.Runtime.InteropServices;

namespace SingleBoostr.API.Types
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct CallbackMessage
  {
    public int m_hSteamUser;
    public int m_iCallback;
    public IntPtr m_pubParam;
    public int m_cubParam;
  }
}
