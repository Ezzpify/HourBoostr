namespace SingleBoostr.Core.Objects
{
    public class SessionInfo
    {
        public string APIKey { get; set; } = string.Empty;

        public string SteamMachineAuth { get; set; } = string.Empty;

        public string SessionId { get; set; } = string.Empty;

        public string SteamLogin { get; set; } = string.Empty;

        public string SteamRememberLogin { get; set; } = string.Empty;

        public string SteamParental { get; set; } = string.Empty;

        public bool IsLoggedIn()
        {
            return !string.IsNullOrWhiteSpace(SessionId) && !string.IsNullOrWhiteSpace(SteamLogin);
        }
    }
}