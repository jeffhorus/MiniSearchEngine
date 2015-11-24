using System;
using System.Windows.Forms;
using System.Threading;
using MiniSearchEngine.Engine;
using MiniSearchEngine.Datastructure;
using System.ComponentModel;

namespace MiniSearchEngine
{
    public partial class LoaderForm : Form
    {
        private string base_dir;

        public LoaderForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            
            //loadDocument();

        }
        
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Parser parser = new Parser(MainForm.doc_config, backgroundWorker1);
            parser.openDocumentFile(base_dir + @"\doc.all");
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProcess.Text = "Processed Document : " + e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                base_dir = folderBrowserDialog1.SelectedPath;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            MessageBox.Show("Load data selesai!");
        }
        
        private void txtFolder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                base_dir = txtFolder.Text;
                progressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
