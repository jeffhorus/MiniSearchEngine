using MiniSearchEngine.Datastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniSearchEngine.Engine
{
    public class RelevantFeedback
    {
        public List<int> relevant_doc;
        public List<int> irelevant_doc;

        public RelevantFeedback(List<RelevantJudgement> relevant_judgement, Dictionary<int, double> result, int query_number)
        {
            relevant_doc = new List<int>();
            irelevant_doc = new List<int>();

            int _query = query_number + 1;
            List<int> relevant = new List<int>();
            foreach (RelevantJudgement rel in relevant_judgement)
            {
                if (rel.queryNumber == _query)
                    relevant.Add(rel.documentNumber);
            }

            foreach (KeyValuePair<int, double> entry in result)
            {
                if (relevant.Contains(entry.Key))
                {
                    relevant_doc.Add(entry.Key);
                }
                else
                {
                    irelevant_doc.Add(entry.Key);
                }
            }

            printLists();

        }

        public RelevantFeedback(CheckedListBox list)
        {
            relevant_doc = new List<int>();
            irelevant_doc = new List<int>();

            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.CheckedIndices.Contains(i))
                {
                    relevant_doc.Add(Utility.getDocumentID(list.Items[i].ToString()));
                }
                else
                {
                    irelevant_doc.Add(Utility.getDocumentID(list.Items[i].ToString()));
                }
            }

            
            printLists();

        }

        public RelevantFeedback(Dictionary<int, double> result)
        {
            relevant_doc = new List<int>();
            irelevant_doc = new List<int>();
            int i = 0;

            foreach (KeyValuePair<int, double> entry in result)
            {
                i++;
                if (i <= MainForm.feedback_config.topn)
                {
                    relevant_doc.Add(entry.Key);
                }
                else
                {
                    irelevant_doc.Add(entry.Key);
                }
            }
            printLists();
        }

        public void applyAlgorithm(Query query)
        {
            double pembagi_relevan, pembagi_irelevan;

            if (MainForm.feedback_config.algorithm == 0)
            {
                pembagi_irelevan = irelevant_doc.Count;
                pembagi_relevan = relevant_doc.Count;
            }
            else
            {
                pembagi_irelevan = 1;
                pembagi_relevan = 1;
            }

            foreach (int rel in relevant_doc)
            {
                searchSetTableAdapters.Document_TermTableAdapter documentTermTableAdapter = new searchSetTableAdapters.Document_TermTableAdapter();
                searchSet.Document_TermDataTable documentTermDataTable = new searchSet.Document_TermDataTable();

                documentTermDataTable = documentTermTableAdapter.GetDataByDocID(rel);
                foreach (searchSet.Document_TermRow row in documentTermDataTable)
                {
                    if (MainForm.feedback_config.useexpand == 0)
                    {
                        if (query.terms.ContainsKey(row.Term))
                            query.terms[row.Term] += row.Weight / pembagi_relevan;
                    }
                    else
                    {
                        if (query.terms.ContainsKey(row.Term))
                            query.terms[row.Term] += row.Weight / pembagi_relevan;
                        else
                            query.terms.Add(row.Term, row.Weight / pembagi_relevan);
                    }
                }
            }

            foreach (int rel in irelevant_doc)
            {
                searchSetTableAdapters.Document_TermTableAdapter documentTermTableAdapter = new searchSetTableAdapters.Document_TermTableAdapter();
                searchSet.Document_TermDataTable documentTermDataTable = new searchSet.Document_TermDataTable();

                documentTermDataTable = documentTermTableAdapter.GetDataByDocID(rel);
                foreach (searchSet.Document_TermRow row in documentTermDataTable)
                {
                    if (query.terms.ContainsKey(row.Term))
                    {
                        query.terms[row.Term] -= row.Weight / pembagi_irelevan;

                        if (query.terms[row.Term] <= 0)
                            query.terms.Remove(row.Term);
                    }
                    
                }

                if (MainForm.feedback_config.algorithm == 2) break;
            }


            /*foreach (KeyValuePair<string, double> entry in query.terms)
            {
                Console.WriteLine(entry.Key + " --> " + entry.Value);
            }*/


        }

        private void printLists()
        {
            /*Console.WriteLine("REL: ");
            foreach ( int l in relevant_doc)
            {
                Console.WriteLine(l + ", ");
            }

            Console.WriteLine("\r\nIREL: ");
            foreach (int l in irelevant_doc)
            {
                Console.WriteLine(l + ", ");
            }*/

        }
    }
}
