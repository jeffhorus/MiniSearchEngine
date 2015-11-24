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
    public partial class QueryLoader : Form
    {
        public List<Query> queries = new List<Query>();
        public List<RelevantJudgement> judgements = new List<RelevantJudgement>();

        private string base_path;

        public QueryLoader()
        {
            InitializeComponent();
            
        }

        private void txtFolder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                base_path = txtFolder.Text;
                load_data();
            }

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                base_path = folderBrowserDialog1.SelectedPath;
                load_data();
            }
        }

        private void load_data()
        {
            queries = Parser.openQueryFile(base_path + @"\query.text");
            judgements = Parser.getRelevantJudgement(base_path + @"\qrels.text");

            MessageBox.Show("Load complete");
            this.Close();
        }
    }
}
