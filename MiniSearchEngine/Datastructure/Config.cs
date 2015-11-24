using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Datastructure
{
    public class Config
    {
        public int tfOption;
        public int idfOption;
        public int stemmingOption;
        public int normalizationOption;

        public Config(int tfOption_, int idfOption_, int stemmingOption_, int normalizationOption_)
        {
            tfOption = tfOption_;
            idfOption = idfOption_;
            stemmingOption = stemmingOption_;
            normalizationOption = normalizationOption_;
        }
    }
}
