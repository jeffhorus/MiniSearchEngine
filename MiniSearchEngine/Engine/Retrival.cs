using MiniSearchEngine.Datastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniSearchEngine.Engine
{
    public class Retrival
    {
        public static Dictionary<int, double> retrive(Query query)
        {
            searchSetTableAdapters.Document_TermTableAdapter documentTermTableAdapter = new searchSetTableAdapters.Document_TermTableAdapter();
            searchSet.Document_TermDataTable documentTermDataTable = new searchSet.Document_TermDataTable();

            Dictionary<int, double> list_document = new Dictionary<int, double>();
            

            
            foreach (KeyValuePair<string, double> entry in query.terms)
            {

                documentTermDataTable = documentTermTableAdapter.GetDataByTerm(entry.Key);

                foreach (searchSet.Document_TermRow row in documentTermDataTable)
                {
                    double SC = entry.Value * row.Weight;

                    if (list_document.ContainsKey(row.Document_ID))
                    {
                        list_document[row.Document_ID] += SC;
                    }
                    else
                    {
                        list_document.Add(row.Document_ID, SC);
                    }
                }
            }
            return list_document;
        }

        public static double calculateRecall(List<RelevantJudgement> relevant_judgement, Dictionary<int, double> result, int query_number)
        {
            int sum_relevant = 0;
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
                    sum_relevant++;
            }

            if (relevant.Count == 0) return 0;

            return (double)sum_relevant / (double)relevant.Count;
        }

        public static double calculatePrecision(List<RelevantJudgement> relevant_judgement, Dictionary<int, double> result, int query_number)
        {
            int sum_relevant = 0;
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
                    sum_relevant++;
            }

            if (result.Count == 0) return 0;

            return (double)sum_relevant / (double)result.Count;
        }

        public static double calculateNIAP(List<RelevantJudgement> relevant_judgement, Dictionary<int, double> result, int query_number)
        {
            double sum_precision = 0;
            double number_relevant = 0;
            int _query = query_number + 1;

            Dictionary<int, double> current_result = new Dictionary<int, double>();
            foreach (KeyValuePair<int, double> entry in result)
            {
                current_result.Add(entry.Key, entry.Value);
                foreach (RelevantJudgement rel in relevant_judgement)
                {
                    if (rel.queryNumber == _query && rel.documentNumber == entry.Key)
                    {
                        sum_precision += calculatePrecision(relevant_judgement, current_result, query_number);
                        number_relevant++;
                    }
                }
            }

            if (number_relevant == 0) return 0;
     
            return sum_precision / number_relevant;
        }

    }
}
