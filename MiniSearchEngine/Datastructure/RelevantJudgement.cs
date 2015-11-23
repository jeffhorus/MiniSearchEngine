using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Datastructure
{
    class RelevantJudgement
    {
        public int queryNumber;
        public int documentNumber;

        public RelevantJudgement() {}

        public RelevantJudgement(int queryNumber_, int documentNumber_)
        {
            queryNumber = queryNumber_;
            documentNumber = documentNumber_;
        }
    }
}
