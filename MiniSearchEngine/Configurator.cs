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
    public partial class Configurator : Form
    {
        public Configurator()
        {
            InitializeComponent();

            cmdDocTF.SelectedIndex = MainForm.doc_config.tfOption;
            cmdDocIDF.SelectedIndex = MainForm.doc_config.idfOption;
            cmdDocNorm.SelectedIndex = MainForm.doc_config.normalizationOption;
            cmdDocStemming.SelectedIndex = MainForm.doc_config.stemmingOption;

            cmdQTF.SelectedIndex = MainForm.query_config.tfOption;
            cmdQIDF.SelectedIndex = MainForm.query_config.idfOption;
            cmdQNorm.SelectedIndex = MainForm.query_config.normalizationOption;
            cmdQStem.SelectedIndex = MainForm.query_config.stemmingOption;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MainForm.doc_config.tfOption = cmdDocTF.SelectedIndex;
            MainForm.doc_config.idfOption = cmdDocIDF.SelectedIndex;
            MainForm.doc_config.normalizationOption = cmdDocNorm.SelectedIndex;
            MainForm.doc_config.stemmingOption = cmdDocStemming.SelectedIndex;

            MainForm.query_config.tfOption = cmdQTF.SelectedIndex;
            MainForm.query_config.idfOption = cmdQIDF.SelectedIndex;
            MainForm.query_config.normalizationOption = cmdQNorm.SelectedIndex;
            MainForm.query_config.stemmingOption = cmdQStem.SelectedIndex;

            MessageBox.Show("If you modify document configuration, changes will affect until next rebuild");
            this.Close();
        }
    }
}
