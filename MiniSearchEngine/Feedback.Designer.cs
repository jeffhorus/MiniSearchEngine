namespace MiniSearchEngine
{
    partial class Feedback
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.cmbPseudoRel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUseSameCol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTopS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTopN = new System.Windows.Forms.TextBox();
            this.cmbQueryEx = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jenis Algoritma";
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Items.AddRange(new object[] {
            "Rocchio",
            "Ide Regular",
            "Ide Dec-Hi"});
            this.cmbAlgorithm.Location = new System.Drawing.Point(23, 269);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(414, 28);
            this.cmbAlgorithm.TabIndex = 1;
            // 
            // cmbPseudoRel
            // 
            this.cmbPseudoRel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPseudoRel.FormattingEnabled = true;
            this.cmbPseudoRel.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbPseudoRel.Location = new System.Drawing.Point(23, 348);
            this.cmbPseudoRel.Name = "cmbPseudoRel";
            this.cmbPseudoRel.Size = new System.Drawing.Size(414, 28);
            this.cmbPseudoRel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pseudo Relevance";
            // 
            // cmbUseSameCol
            // 
            this.cmbUseSameCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUseSameCol.FormattingEnabled = true;
            this.cmbUseSameCol.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbUseSameCol.Location = new System.Drawing.Point(23, 112);
            this.cmbUseSameCol.Name = "cmbUseSameCol";
            this.cmbUseSameCol.Size = new System.Drawing.Size(414, 28);
            this.cmbUseSameCol.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Use Same Collection";
            // 
            // txtTopS
            // 
            this.txtTopS.Location = new System.Drawing.Point(23, 504);
            this.txtTopS.Name = "txtTopS";
            this.txtTopS.Size = new System.Drawing.Size(414, 26);
            this.txtTopS.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 472);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "TOP S";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "TOP N";
            // 
            // txtTopN
            // 
            this.txtTopN.Location = new System.Drawing.Point(23, 428);
            this.txtTopN.Name = "txtTopN";
            this.txtTopN.Size = new System.Drawing.Size(414, 26);
            this.txtTopN.TabIndex = 8;
            // 
            // cmbQueryEx
            // 
            this.cmbQueryEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryEx.FormattingEnabled = true;
            this.cmbQueryEx.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbQueryEx.Location = new System.Drawing.Point(23, 187);
            this.cmbQueryEx.Name = "cmbQueryEx";
            this.cmbQueryEx.Size = new System.Drawing.Size(414, 28);
            this.cmbQueryEx.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Use Query Expansion";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(175, 565);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(111, 38);
            this.btnExecute.TabIndex = 12;
            this.btnExecute.Text = "Simpan";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Experiment",
            "Interactive"});
            this.cmbMode.Location = new System.Drawing.Point(23, 37);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(414, 28);
            this.cmbMode.TabIndex = 14;
            this.cmbMode.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mode";
            this.label7.Visible = false;
            // 
            // Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 621);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cmbQueryEx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTopN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTopS);
            this.Controls.Add(this.cmbUseSameCol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPseudoRel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAlgorithm);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Feedback";
            this.Text = "Feedback";
            this.Load += new System.EventHandler(this.Feedback_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.ComboBox cmbPseudoRel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUseSameCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTopS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTopN;
        private System.Windows.Forms.ComboBox cmbQueryEx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMode;
    }
}