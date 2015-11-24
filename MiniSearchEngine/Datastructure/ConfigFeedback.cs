using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Datastructure
{
    public class ConfigFeedback
    {
        public int mode;
        public int algorithm;
        public int pseudo;
        public int topn;
        public int tops;
        public int usesamecol;
        public int useexpand;

        public ConfigFeedback(int mode, int algorithm, int pseudo, int topn, int tops, int usesamecol, int useexpand)
        {
            this.mode = mode;
            this.algorithm = algorithm;
            this.pseudo = pseudo;
            this.topn = topn;
            this.tops = tops;
            this.usesamecol = usesamecol;
            this.useexpand = useexpand;
        }

        public ConfigFeedback() { }
    }
}
