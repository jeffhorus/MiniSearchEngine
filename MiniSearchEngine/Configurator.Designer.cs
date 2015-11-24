namespace MiniSearchEngine
{
    partial class Configurator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdDocTF = new System.Windows.Forms.ComboBox();
            this.cmdDocIDF = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdDocNorm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdDocStemming = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdQStem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdQNorm = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdQIDF = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdQTF = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdDocStemming);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmdDocNorm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdDocIDF);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdDocTF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 339);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Document";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TF";
            // 
            // cmdDocTF
            // 
            this.cmdDocTF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDocTF.FormattingEnabled = true;
            this.cmdDocTF.Items.AddRange(new object[] {
            "No TF",
            "Raw TF",
            "Log TF",
            "Binary TF",
            "Augmented TF"});
            this.cmdDocTF.Location = new System.Drawing.Point(20, 63);
            this.cmdDocTF.Name = "cmdDocTF";
            this.cmdDocTF.Size = new System.Drawing.Size(283, 28);
            this.cmdDocTF.TabIndex = 1;
            // 
            // cmdDocIDF
            // 
            this.cmdDocIDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDocIDF.FormattingEnabled = true;
            this.cmdDocIDF.Items.AddRange(new object[] {
            "No IDF",
            "Using IDF"});
            this.cmdDocIDF.Location = new System.Drawing.Point(20, 130);
            this.cmdDocIDF.Name = "cmdDocIDF";
            this.cmdDocIDF.Size = new System.Drawing.Size(283, 28);
            this.cmdDocIDF.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "IDF";
            // 
            // cmdDocNorm
            // 
            this.cmdDocNorm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDocNorm.FormattingEnabled = true;
            this.cmdDocNorm.Items.AddRange(new object[] {
            "No Normalization",
            "Using Normalization"});
            this.cmdDocNorm.Location = new System.Drawing.Point(20, 200);
            this.cmdDocNorm.Name = "cmdDocNorm";
            this.cmdDocNorm.Size = new System.Drawing.Size(283, 28);
            this.cmdDocNorm.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Normalization";
            // 
            // cmdDocStemming
            // 
            this.cmdDocStemming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdDocStemming.FormattingEnabled = true;
            this.cmdDocStemming.Items.AddRange(new object[] {
            "No Stemming",
            "Using Stemming"});
            this.cmdDocStemming.Location = new System.Drawing.Point(20, 269);
            this.cmdDocStemming.Name = "cmdDocStemming";
            this.cmdDocStemming.Size = new System.Drawing.Size(283, 28);
            this.cmdDocStemming.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stemming";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdQStem);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmdQNorm);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmdQIDF);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmdQTF);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(361, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 339);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Query";
            // 
            // cmdQStem
            // 
            this.cmdQStem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdQStem.FormattingEnabled = true;
            this.cmdQStem.Items.AddRange(new object[] {
            "No Stemming",
            "Using Stemming"});
            this.cmdQStem.Location = new System.Drawing.Point(20, 269);
            this.cmdQStem.Name = "cmdQStem";
            this.cmdQStem.Size = new System.Drawing.Size(283, 28);
            this.cmdQStem.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Stemming";
            // 
            // cmdQNorm
            // 
            this.cmdQNorm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdQNorm.FormattingEnabled = true;
            this.cmdQNorm.Items.AddRange(new object[] {
            "No Normalization",
            "Using Normalization"});
            this.cmdQNorm.Location = new System.Drawing.Point(20, 200);
            this.cmdQNorm.Name = "cmdQNorm";
            this.cmdQNorm.Size = new System.Drawing.Size(283, 28);
            this.cmdQNorm.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Normalization";
            // 
            // cmdQIDF
            // 
            this.cmdQIDF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdQIDF.FormattingEnabled = true;
            this.cmdQIDF.Items.AddRange(new object[] {
            "No IDF",
            "Using IDF"});
            this.cmdQIDF.Location = new System.Drawing.Point(20, 130);
            this.cmdQIDF.Name = "cmdQIDF";
            this.cmdQIDF.Size = new System.Drawing.Size(283, 28);
            this.cmdQIDF.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "IDF";
            // 
            // cmdQTF
            // 
            this.cmdQTF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdQTF.FormattingEnabled = true;
            this.cmdQTF.Items.AddRange(new object[] {
            "No TF",
            "Raw TF",
            "Log TF",
            "Binary TF",
            "Augmented TF"});
            this.cmdQTF.Location = new System.Drawing.Point(20, 63);
            this.cmdQTF.Name = "cmdQTF";
            this.cmdQTF.Size = new System.Drawing.Size(283, 28);
            this.cmdQTF.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "TF";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(578, 371);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 47);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Configurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 430);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Configurator";
            this.Text = "Configurator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmdDocStemming;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmdDocNorm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmdDocIDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmdDocTF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmdQStem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmdQNorm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmdQIDF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmdQTF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
    }
}