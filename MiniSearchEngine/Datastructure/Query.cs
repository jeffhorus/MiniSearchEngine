using MiniSearchEngine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Datastructure
{
    public class Query
    {
        public int number;
        public string content;
        public Dictionary<string, double> terms;

        private int max_occurence = 0;

        public Query() {}

        public Query(int number_, string content_)
        {
            number = number_;
            content = content_;
        }

        public void preprocessQuery()
        {
            this.terms = new Dictionary<string, double>();
            List<string> terms = Utility.separateData(content);
            terms = Utility.removeStopWord(terms);

            if (MainForm.query_config.stemmingOption == 1) terms = Utility.stemming(terms);
            //if (MainForm.query_config.normalizationOption == 1) terms = Utility.removeStopWord
            
            foreach (string s in terms)
            {
                if (this.terms.ContainsKey(s))
                {
                    this.terms[s]++;

                    if (max_occurence < this.terms[s]) max_occurence = (int) this.terms[s];
                }
                else
                {
                    this.terms.Add(s, 1);
                }
            }
        }

        public void calculateTerms()
        {
            foreach (KeyValuePair<string, double> entry in terms)
            {
                if (MainForm.query_config.tfOption == 0 || MainForm.query_config.tfOption == 3)
                {
                    this.terms[entry.Key] = 1;
                }else if(MainForm.query_config.tfOption == 2)
                {
                    this.terms[entry.Key] = 1 + Math.Log10(entry.Value);
                }else if(MainForm.query_config.tfOption == 4)
                {
                    this.terms[entry.Key] = 0.5 + 0.5 * entry.Value / (double)max_occurence;
                }
            }
        }
    }
}
