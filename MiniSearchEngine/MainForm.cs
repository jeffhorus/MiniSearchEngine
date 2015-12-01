using MiniSearchEngine.Datastructure;
using MiniSearchEngine.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniSearchEngine
{
    public partial class MainForm : Form
    {
        public static Config doc_config = new Config(1, 0, 0, 0);
        public static Config query_config = new Config(1, 0, 0, 0);
        public static ConfigFeedback feedback_config = new ConfigFeedback(0, 0, 0, 10, 25, 1, 0);

        private List<Query> queries;
        private List<RelevantJudgement> relevant_judgement;
        private Dictionary<int, double> result;

        private double niap_1_total = 0;
        private double niap_2_total = 0;

        private Query current_query;

        public MainForm()
        {
            InitializeComponent();
            Utility.getStopWord();
        }

        private void bukaDokumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LoaderForm().ShowDialog();
        }

        private void bukaKoleksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryLoader qloader = new QueryLoader();
            qloader.ShowDialog();
            queries = qloader.queries;
            relevant_judgement = qloader.judgements;

            for(int i = 1; i <= queries.Count; i++)
            {
                cmbQuery.Items.Add("Query " + i);
            }

            MethodInvoker myProcessStarter = new MethodInvoker(generateSecondRetrieval);

            myProcessStarter.BeginInvoke(null, null);

            //generateSecondRetrieval();

            //generateSecondRetrieval();
        }

        private void generateSecondRetrieval()
        {
            bool isbreak = false;

            for (int algorithm = 0; algorithm <= 2 && !isbreak; algorithm++)
            {
                for (int pseudo = 0; pseudo <= 1 && !isbreak; pseudo++)
                {
                    for (int samecoll = 0; samecoll <= 1 && !isbreak; samecoll++)
                    {
                        for (int expand = 0; expand <= 1 && !isbreak; expand++)
                        {
                            int id = 0;
                            niap_1_total = 0;
                            niap_2_total = 0;
                            

                            feedback_config = new ConfigFeedback(0, algorithm, pseudo, feedback_config.topn, feedback_config.tops, samecoll, expand);
                            string kombinasi = algorithm + ", " + pseudo + ", " + samecoll + ", " + expand;
                            Console.WriteLine("working on : " + kombinasi);
                            txtAnalysis.AppendText("\r\nKombinasi : " + kombinasi + "\r\n");
                            txtAnalysis.AppendText("Query Number;Recall;Precision;Non-Interpolated Average Precision;;Query Number;Recall;Precision;Non-Interpolated Average Precision\r\n");
                            foreach (Query current_query in queries)
                            {
                                cmbQuery.SelectedIndex = id;
                                generatePerformance();
                                id++;
                                Console.WriteLine("query : " + id);
                                //break;
                            }
                            txtAnalysis.AppendText("Average Non-Interpolated Average Precision;;;" + niap_1_total / queries.Count);
                            txtAnalysis.AppendText(";;Average Non-Interpolated Average Precision;;;" + niap_2_total / queries.Count);

                            FileStream fs = new FileStream("out.csv", FileMode.Append, FileAccess.Write);

                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine(txtAnalysis.Text);
                            }

                            txtAnalysis.ResetText();
                        }
                    }
                }
            }
        }

        private void cmbQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_query = queries[cmbQuery.SelectedIndex];

            current_query.preprocessQuery();
            current_query.calculateTerms();
            int _query = cmbQuery.SelectedIndex + 1;
            
            retrive_current_query(false);

            
            txtAnalysis.AppendText(_query + ";" + Retrival.calculateRecall(relevant_judgement, result, cmbQuery.SelectedIndex) + ";");
            txtAnalysis.AppendText(Retrival.calculatePrecision(relevant_judgement, result, cmbQuery.SelectedIndex) + ";");
            double current_niap = Retrival.calculateNIAP(relevant_judgement, result, cmbQuery.SelectedIndex);
            niap_1_total += current_niap;
            txtAnalysis.AppendText( current_niap + ";");
        }

        private void retrive_current_query(bool uniq)
        {
            int counter = 0;
            Dictionary<int, double> result = Retrival.retrive(current_query);

            
            if (uniq)
            {
                foreach (string _id in listResults.Items)
                {
                    result.Remove(Utility.getDocumentID(_id));
                }
                
            }

            listResults.Items.Clear();

            var items = from pair in result orderby pair.Value descending select pair;
            this.result = new Dictionary<int, double>();
            foreach (KeyValuePair<int, double> entry in items)
            {
                listResults.Items.Add("Document " + entry.Key);
                this.result.Add(entry.Key, entry.Value);

                if (MainForm.feedback_config.mode == 0)
                {
                    counter++;
                    if (counter == feedback_config.tops) break;
                }
            }

        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Configurator().ShowDialog();
        }

        private void configToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Feedback().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RelevantFeedback rel;
            if (feedback_config.pseudo == 1)
            {
                 rel = new RelevantFeedback(result);
            }
            else
            {
                if (feedback_config.mode == 0)
                {
                    rel = new RelevantFeedback(relevant_judgement, result, cmbQuery.SelectedIndex);

                }
                else
                {
                    rel = new RelevantFeedback(listResults);

                }
            }

            rel.applyAlgorithm(current_query);

            if (feedback_config.mode == 0)
            {
                int _query = cmbQuery.SelectedIndex + 1;
            }
            else
            {
                txtAnalysis.AppendText("\r\n -- NEW WEIGHT --\r\n");
                foreach (KeyValuePair<string, double> entry in current_query.terms)
                {
                    txtAnalysis.AppendText(entry.Key + " --> " + entry.Value + "\r\n");
                }
                txtAnalysis.AppendText("     --------\r\n\r\n Retrive results:\r\n");

            }


            
            retrive_current_query((MainForm.feedback_config.usesamecol == 0));

            if (feedback_config.mode == 0)
            {
                txtAnalysis.AppendText(";" + (cmbQuery.SelectedIndex+1) + ";" + Retrival.calculateRecall(relevant_judgement, result, cmbQuery.SelectedIndex) + ";");
                txtAnalysis.AppendText(Retrival.calculatePrecision(relevant_judgement, result, cmbQuery.SelectedIndex) + ";");
                double current_niap = Retrival.calculateNIAP(relevant_judgement, result, cmbQuery.SelectedIndex);
                txtAnalysis.AppendText(current_niap + "\r\n");
                niap_2_total += current_niap;
            }

            //MessageBox.Show("Hasil pencarian sudah diperbaharui dengan FeedBack");
        }

        private void generatePerformance()
        {
            RelevantFeedback rel;
            if (feedback_config.pseudo == 1)
            {
                rel = new RelevantFeedback(result);
            }
            else
            {
                if (feedback_config.mode == 0)
                {
                    rel = new RelevantFeedback(relevant_judgement, result, cmbQuery.SelectedIndex);

                }
                else
                {
                    rel = new RelevantFeedback(listResults);

                }
            }

            rel.applyAlgorithm(current_query);

            if (feedback_config.mode == 0)
            {
                int _query = cmbQuery.SelectedIndex + 1;
            }
            else
            {
                //txtAnalysis.AppendText("\r\n -- NEW WEIGHT --\r\n");
                //foreach (KeyValuePair<string, double> entry in current_query.terms)
                //{
                //    txtAnalysis.AppendText(entry.Key + " --> " + entry.Value + "\r\n");
                //}
                //txtAnalysis.AppendText("     --------\r\n\r\n Retrive results:\r\n");

            }



            retrive_current_query((MainForm.feedback_config.usesamecol == 0));

            if (feedback_config.mode == 0)
            {
                txtAnalysis.AppendText(";" + (cmbQuery.SelectedIndex + 1) + ";" + Retrival.calculateRecall(relevant_judgement, result, cmbQuery.SelectedIndex) + ";");
                txtAnalysis.AppendText(Retrival.calculatePrecision(relevant_judgement, result, cmbQuery.SelectedIndex) + ";");
                double current_niap = Retrival.calculateNIAP(relevant_judgement, result, cmbQuery.SelectedIndex);
                txtAnalysis.AppendText(current_niap + "\r\n");
                niap_2_total += current_niap;
            }

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                feedback_config.mode = 0;
            else
                feedback_config.mode = 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtAnalysis.AppendText("Searching for query: ");
            txtAnalysis.AppendText(txtQuery.Text);
            txtAnalysis.AppendText("\r\n\r\nResult:\r\n");

            current_query = new Query(999, txtQuery.Text);

            current_query.preprocessQuery();
            current_query.calculateTerms();

            txtAnalysis.AppendText(" -- OLD WEIGHT --\r\n");
            foreach (KeyValuePair<string, double> entry in current_query.terms)
            {
                txtAnalysis.AppendText(entry.Key + " --> " + entry.Value + "\r\n");
            }
            txtAnalysis.AppendText("     --------\r\n\r\n Retrive results:\r\n");

            retrive_current_query(false);
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            searchSet.DocumentsDataTable docTable = new searchSet.DocumentsDataTable();
            searchSetTableAdapters.DocumentsTableAdapter docAdapter = new searchSetTableAdapters.DocumentsTableAdapter();

            docTable = docAdapter.GetDataByID(Utility.getDocumentID(listResults.Items[listResults.SelectedIndex].ToString()));
            MessageBox.Show(docTable[0].Title + "\n\n" + docTable[0].Authors + "\n\n" + docTable[0].Content);

        }
    }
}
