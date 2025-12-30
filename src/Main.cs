using ModLoader;
using System.Collections.Generic;

namespace UniLog
{
    public class Main : Mod
    {
        public static Main Instance { get; private set; }
        public Main()
        {
            Instance = this;
        }

        public override string ModNameID => "unilog";
        public override string DisplayName => "UniLog";
        public override string Author => "Koja Mori";
        public override string Description => "A simple logging dependency mod.";
        public override string ModVersion => "1.0.1";
        public override string MinimumGameVersionNecessary => "1.6.0.3";
        public override Dictionary<string, string> Dependencies => null;

        public override void Early_Load()
        {
        }

        public override void Load()
        {
        }
    }
}