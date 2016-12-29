// Decompiled with JetBrains decompiler
// Type: SAM.API.Types.ItemRequestResult
// Assembly: SAM.API, Version=6.3.0.804, Culture=neutral, PublicKeyToken=null
// MVID: 7DF108F6-41E2-4750-9029-3DA2C808D0A1
// Assembly location: E:\Dropbox\SPARA\Develop\HourBoostr\SingleBoostr\SingleBoostr\SAM.API.dll

namespace SingleBoostr.API.Types
{
  public enum ItemRequestResult
  {
    InvalidValue = -1,
    OK = 0,
    Denied = 1,
    ServerError = 2,
    Timeout = 3,
    Invalid = 4,
    NoMatch = 5,
    UnknownError = 6,
    NotLoggedOn = 7,
  }
}
