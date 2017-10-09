using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleBoostr
{
    public class Bubble
    {
        public string title { get; set; }

        public string text { get; set; }

        public string url { get; set; }
    }

    public class ChatBubbles
    {
        public List<Bubble> bubbles { get; set; } = new List<Bubble>();
    }
}
