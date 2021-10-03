using SingleBoostr.Ui;
using System.Collections.Generic;

namespace SingleBoostr.Objects
{
    public class Settings
    {
        public bool EnableChatResponse { get; set; }

        public List<string> ChatResponses { get; set; } = new List<string>();

        public bool OnlyReplyIfIdling { get; set; } = true;

        public bool WaitBetweenReplies { get; set; } = true;

        public bool RestartGames { get; set; } = true;

        public bool RestartGamesAtRandom { get; set; } = true;

        public bool ForceOnlineStatus { get; set; } = true;

        public bool CheckForUpdates { get; set; } = true;

        public bool ClearRecentlyPlayedOnExit { get; set; }

        public bool SaveAppIdleHistory { get; set; } = true;

        public bool JoinSteamGroup { get; set; } = true;

        public bool SaveLoginCookies { get; set; } = true;

        public bool HideToTraybar { get; set; }

        public bool OnlyIdleGamesWithCertainMinutes { get; set; } = true;

        public int NumOnlyIdleGamesWithCertainMinutes { get; set; } = 120;

        public int NumGamesIdleWhenNoCards { get; set; } = 25;

        public int RestartGamesTime { get; set; } = 60;

        public int WaitBetweenRepliesTime { get; set; } = 10;

        public bool IdleCardsWithMostValue { get; set; } = true;

        /*UI hidden settings*/

        public bool VACWarningDisplayed { get; set; }

        public bool ChatResponseTipDisplayed { get; set; }

        public bool ShowedDiscordInfo { get; set; }

        public SessionInfo WebSession { get; set; } = new SessionInfo();

        public List<uint> GameHistoryIds { get; set; } = new List<uint>();

        public List<uint> BlacklistedCardGames { get; set; } = new List<uint>();

        public void Verify()
        {
            if (WaitBetweenRepliesTime > 1000 || WaitBetweenRepliesTime < 1)
                WaitBetweenRepliesTime = 10;

            if (RestartGamesTime > 1000 || RestartGamesTime < 1)
                RestartGamesTime = 10;

            if (NumGamesIdleWhenNoCards > 33 || NumGamesIdleWhenNoCards < 1)
                NumGamesIdleWhenNoCards = 10;

            if (NumOnlyIdleGamesWithCertainMinutes > 1000 || NumOnlyIdleGamesWithCertainMinutes < 1)
                NumOnlyIdleGamesWithCertainMinutes = 10;
        }
    }
}
