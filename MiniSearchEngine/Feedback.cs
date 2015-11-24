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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            cmbMode.SelectedIndex = MainForm.feedback_config.mode;
            cmbAlgorithm.SelectedIndex = MainForm.feedback_config.algorithm;
            cmbPseudoRel.SelectedIndex = MainForm.feedback_config.pseudo;
            cmbQueryEx.SelectedIndex = MainForm.feedback_config.useexpand;
            cmbUseSameCol.SelectedIndex = MainForm.feedback_config.usesamecol;
            txtTopN.Text = MainForm.feedback_config.topn.ToString();
            txtTopS.Text = MainForm.feedback_config.tops.ToString();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            MainForm.feedback_config.mode = cmbMode.SelectedIndex;
            MainForm.feedback_config.algorithm = cmbAlgorithm.SelectedIndex;
            MainForm.feedback_config.pseudo = cmbPseudoRel.SelectedIndex;
            MainForm.feedback_config.useexpand = cmbQueryEx.SelectedIndex;
            MainForm.feedback_config.usesamecol = cmbUseSameCol.SelectedIndex;
            MainForm.feedback_config.topn = Int32.Parse(txtTopN.Text);
            MainForm.feedback_config.tops = Int32.Parse(txtTopS.Text);

            this.Close();
        }
    }
}
