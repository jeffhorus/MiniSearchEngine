using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Datastructure
{
    class Query
    {
        public int number;
        public string content;
        public Dictionary<string, int> term;

        public Query() {}

        public Query(int number_, string content_)
        {
            number = number_;
            content = content_;

            term = new Dictionary<string, int>();
            
        }
    }
}
