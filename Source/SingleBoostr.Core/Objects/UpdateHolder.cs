using System.Collections.Generic;

namespace SingleBoostr.Core.Objects
{
    public class UpdateHolder
    {
        public List<Application> Applications { get; set; } 
    }
    public class Application
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public string Info { get; set; }
    }
}