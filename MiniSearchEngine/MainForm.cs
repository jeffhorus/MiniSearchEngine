using MiniSearchEngine.Datastructure;
using MiniSearchEngine.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniSearchEngine
{
    public partial class MainForm : Form
    {
        public static Config doc_config = new Config(1, 1, 1, 1);
        public static Config query_config = new Config(1, 1, 1, 1);
        public static ConfigFeedback feedback_config = new ConfigFeedback(0, 0, 0, 10, 25, 1, 0);

        private List<Query> queries;
        private List<RelevantJudgement> relevant_judgement;
        private Dictionary<int, double> result;

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

            /* UNTUK MENAMPILKAN SELURUH DATA DENGAN FORMAT no_q;precision;recall;niap */
            int id = 0;
            double sum_niap = 0;
            txtAnalysis.AppendText("Document Number;Precision;Recall;Non-Interpolated Average Precision\r\n");
            foreach (Query current_query in queries)
            {
                current_query.preprocessQuery();
                current_query.calculateTerms();
                int _query = id + 1;

                /* add to result */
                int counter = 0;
                Dictionary<int, double> result = Retrival.retrive(current_query);

                //listResults.Items.Clear();

                var items = from pair in result orderby pair.Value descending select pair;
                this.result = new Dictionary<int, double>();
                foreach (KeyValuePair<int, double> entry in items)
                {
                    //listResults.Items.Add("Document " + entry.Key);
                    this.result.Add(entry.Key, entry.Value);

                    if (MainForm.feedback_config.mode == 0)
                    {
                        counter++;
                        if (counter == feedback_config.tops) break;
                    }
                }

                /* print results */
                double current_niap = Retrival.calculateNIAP(relevant_judgement, this.result, id);
                sum_niap += current_niap;
                txtAnalysis.AppendText(_query + ";");
                txtAnalysis.AppendText(Retrival.calculateRecall(relevant_judgement, result, id) + ";");
                txtAnalysis.AppendText(Retrival.calculatePrecision(relevant_judgement, result, id) + ";");
                txtAnalysis.AppendText(current_niap + "\r\n");

                id++;
            }
            txtAnalysis.AppendText(";;Average of Non-Interpolated Average Precision;" + sum_niap/(double)queries.Count + "\r\n");

            /* MENAMPILKAN SELURUH HASIL FEEDBACK */
            id = 0;
            sum_niap = 0;
            txtAnalysis.AppendText("Document Number;Precision;Recall;Non-Interpolated Average Precision\r\n");
            foreach (Query current_query in queries)
            {
                RelevantFeedback rel;
                if (feedback_config.pseudo == 1)
                {
                    rel = new RelevantFeedback(this.result);
                }
                else
                {
                    if (feedback_config.mode == 0)
                    {
                        rel = new RelevantFeedback(relevant_judgement, this.result, id);

                    }
                    else
                    {
                        rel = new RelevantFeedback(listResults);

                    }
                }

                rel.applyAlgorithm(current_query);


                //retrive_current_query((MainForm.feedback_config.usesamecol == 0));
                int counter = 0;
                Dictionary<int, double> result = Retrival.retrive(current_query);


                if (MainForm.feedback_config.usesamecol == 0)
                {
                    foreach (string _id in listResults.Items)
                    {
                        result.Remove(Utility.getDocumentID(_id));
                    }

                }

                var items = from pair in result orderby pair.Value descending select pair;
                this.result = new Dictionary<int, double>();
                foreach (KeyValuePair<int, double> entry in items)
                {
                    this.result.Add(entry.Key, entry.Value);

                    if (MainForm.feedback_config.mode == 0)
                    {
                        counter++;
                        if (counter == feedback_config.tops) break;
                    }
                }

                if (feedback_config.mode == 0)
                {
                    txtAnalysis.AppendText(id+1 + ";");
                    txtAnalysis.AppendText(Retrival.calculateRecall(relevant_judgement, result, id) + ";");
                    txtAnalysis.AppendText(Retrival.calculatePrecision(relevant_judgement, result, id) + ";");
                    txtAnalysis.AppendText(Retrival.calculateNIAP(relevant_judgement, this.result, id) + "\r\n");
                }

                //MessageBox.Show("Hasil pencarian sudah diperbaharui dengan FeedBack");
                id++;
            }
            txtAnalysis.AppendText(";;Average of Non-Interpolated Average Precision;" + sum_niap / (double)queries.Count + "\r\n");
            MessageBox.Show("Done");
        }

        private void cmbQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(queries[cmbQuery.SelectedIndex].content);
            txtAnalysis.AppendText("Searching for query: ");
            txtAnalysis.AppendText(queries[cmbQuery.SelectedIndex].content);
            
            current_query = queries[cmbQuery.SelectedIndex];

            current_query.preprocessQuery();
            current_query.calculateTerms();
            int _query = cmbQuery.SelectedIndex + 1;

            txtAnalysis.AppendText("  Relevant Docs: \r\n");
            foreach (RelevantJudgement rel in relevant_judgement)
            {
                if (rel.queryNumber == _query)
                    txtAnalysis.AppendText("   - D" + rel.documentNumber + "\r\n");
            }


            txtAnalysis.AppendText("\r\n\r\nResult:\r\n");
            retrive_current_query(false);


            txtAnalysis.AppendText("---------------------------\r\n");
            txtAnalysis.AppendText("Recall = " + Retrival.calculateRecall(relevant_judgement, result, cmbQuery.SelectedIndex) + "\r\n");
            txtAnalysis.AppendText("Precision = " + Retrival.calculatePrecision(relevant_judgement, result, cmbQuery.SelectedIndex) + "\r\n");
            txtAnalysis.AppendText("NIAP = " + Retrival.calculateNIAP(relevant_judgement, this.result, cmbQuery.SelectedIndex) + "\r\n");
            txtAnalysis.AppendText("---------------------------\r\n");
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
                txtAnalysis.AppendText("Document " + entry.Key + ", score: " + entry.Value + "\n");
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
                txtAnalysis.AppendText("\r\n  Relevant Docs: \r\n");
                foreach (RelevantJudgement relv in relevant_judgement)
                {
                    if (relv.queryNumber == _query)
                        txtAnalysis.AppendText("    D" + relv.documentNumber + "\r\n");
                }
                txtAnalysis.AppendText("     --------\r\n\r\n Retrive results:\r\n");
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
                txtAnalysis.AppendText("---------------------------\r\n");
                txtAnalysis.AppendText("Recall = " + Retrival.calculateRecall(relevant_judgement, result, cmbQuery.SelectedIndex) + "\r\n");
                txtAnalysis.AppendText("Precision = " + Retrival.calculatePrecision(relevant_judgement, result, cmbQuery.SelectedIndex) + "\r\n");
                txtAnalysis.AppendText("NIAP = " + Retrival.calculateNIAP(relevant_judgement, this.result, cmbQuery.SelectedIndex) + "\r\n");
                txtAnalysis.AppendText("---------------------------\r\n");
            }

            MessageBox.Show("Hasil pencarian sudah diperbaharui dengan FeedBack");
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
