using System;
using System.Windows.Forms;
using System.Threading;
using MiniSearchEngine.Engine;
using MiniSearchEngine.Datastructure;
using System.ComponentModel;

namespace MiniSearchEngine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(loadDocument);
            thread.Start();

            //loadDocument();

        }

        private void loadDocument()
        {
            //MessageBox.Show("START");

            
            //MessageBox.Show("ASEM");
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Parser parser = new Parser(new Config(2, 1, 0, 1), @"D:\Kuliah\STBI\MiniSearchEngine\MiniSearchEngine\Test Collection\stopword.txt");
            parser.openDocumentFile(@"D:\Kuliah\STBI\MiniSearchEngine\MiniSearchEngine\Test Collection\ADI\adi.all");
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
