namespace TexAssistantTool
{
    partial class TableForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxTable4 = new System.Windows.Forms.ComboBox();
            this.comboBoxTable3 = new System.Windows.Forms.ComboBox();
            this.comboBoxTable2 = new System.Windows.Forms.ComboBox();
            this.comboBoxTable1 = new System.Windows.Forms.ComboBox();
            this.textBoxLabel = new System.Windows.Forms.TextBox();
            this.textBoxCaption = new System.Windows.Forms.TextBox();
            this.buttonLabelAutoFill = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCaptionPostion = new System.Windows.Forms.ComboBox();
            this.checkBoxCenteringSpecification = new System.Windows.Forms.CheckBox();
            this.checkBoxColSpecification = new System.Windows.Forms.CheckBox();
            this.textBoxColSpecification = new System.Windows.Forms.TextBox();
            this.checkBoxCaptionSet = new System.Windows.Forms.CheckBox();
            this.checkBoxLabelSet = new System.Windows.Forms.CheckBox();
            this.checkBoxPostion = new System.Windows.Forms.CheckBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(451, 404);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // comboBoxTable4
            // 
            this.comboBoxTable4.FormattingEnabled = true;
            this.comboBoxTable4.Items.AddRange(new object[] {
            "H",
            "B",
            "T",
            "P"});
            this.comboBoxTable4.Location = new System.Drawing.Point(395, 55);
            this.comboBoxTable4.Name = "comboBoxTable4";
            this.comboBoxTable4.Size = new System.Drawing.Size(45, 20);
            this.comboBoxTable4.TabIndex = 8;
            // 
            // comboBoxTable3
            // 
            this.comboBoxTable3.FormattingEnabled = true;
            this.comboBoxTable3.Items.AddRange(new object[] {
            "H",
            "B",
            "T",
            "P"});
            this.comboBoxTable3.Location = new System.Drawing.Point(344, 55);
            this.comboBoxTable3.Name = "comboBoxTable3";
            this.comboBoxTable3.Size = new System.Drawing.Size(45, 20);
            this.comboBoxTable3.TabIndex = 9;
            // 
            // comboBoxTable2
            // 
            this.comboBoxTable2.FormattingEnabled = true;
            this.comboBoxTable2.Items.AddRange(new object[] {
            "H",
            "B",
            "T",
            "P"});
            this.comboBoxTable2.Location = new System.Drawing.Point(293, 55);
            this.comboBoxTable2.Name = "comboBoxTable2";
            this.comboBoxTable2.Size = new System.Drawing.Size(45, 20);
            this.comboBoxTable2.TabIndex = 10;
            // 
            // comboBoxTable1
            // 
            this.comboBoxTable1.FormattingEnabled = true;
            this.comboBoxTable1.Items.AddRange(new object[] {
            "H",
            "B",
            "T",
            "P"});
            this.comboBoxTable1.Location = new System.Drawing.Point(242, 55);
            this.comboBoxTable1.Name = "comboBoxTable1";
            this.comboBoxTable1.Size = new System.Drawing.Size(45, 20);
            this.comboBoxTable1.TabIndex = 11;
            // 
            // textBoxLabel
            // 
            this.textBoxLabel.Location = new System.Drawing.Point(242, 118);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(100, 19);
            this.textBoxLabel.TabIndex = 13;
            // 
            // textBoxCaption
            // 
            this.textBoxCaption.Location = new System.Drawing.Point(242, 90);
            this.textBoxCaption.Name = "textBoxCaption";
            this.textBoxCaption.Size = new System.Drawing.Size(100, 19);
            this.textBoxCaption.TabIndex = 15;
            // 
            // buttonLabelAutoFill
            // 
            this.buttonLabelAutoFill.Location = new System.Drawing.Point(349, 114);
            this.buttonLabelAutoFill.Name = "buttonLabelAutoFill";
            this.buttonLabelAutoFill.Size = new System.Drawing.Size(99, 23);
            this.buttonLabelAutoFill.TabIndex = 16;
            this.buttonLabelAutoFill.Text = "ラベルの自動生成";
            this.buttonLabelAutoFill.UseVisualStyleBackColor = true;
            this.buttonLabelAutoFill.Click += new System.EventHandler(this.ButtonLabelAutoFill_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "キャプションの表示位置";
            // 
            // comboBoxCaptionPostion
            // 
            this.comboBoxCaptionPostion.FormattingEnabled = true;
            this.comboBoxCaptionPostion.Items.AddRange(new object[] {
            "上",
            "下"});
            this.comboBoxCaptionPostion.Location = new System.Drawing.Point(243, 149);
            this.comboBoxCaptionPostion.Name = "comboBoxCaptionPostion";
            this.comboBoxCaptionPostion.Size = new System.Drawing.Size(44, 20);
            this.comboBoxCaptionPostion.TabIndex = 17;
            // 
            // checkBoxCenteringSpecification
            // 
            this.checkBoxCenteringSpecification.AutoSize = true;
            this.checkBoxCenteringSpecification.Location = new System.Drawing.Point(101, 178);
            this.checkBoxCenteringSpecification.Name = "checkBoxCenteringSpecification";
            this.checkBoxCenteringSpecification.Size = new System.Drawing.Size(126, 16);
            this.checkBoxCenteringSpecification.TabIndex = 18;
            this.checkBoxCenteringSpecification.Text = "表のセンタリングを行う";
            this.checkBoxCenteringSpecification.UseVisualStyleBackColor = true;
            // 
            // checkBoxColSpecification
            // 
            this.checkBoxColSpecification.AutoSize = true;
            this.checkBoxColSpecification.Location = new System.Drawing.Point(101, 200);
            this.checkBoxColSpecification.Name = "checkBoxColSpecification";
            this.checkBoxColSpecification.Size = new System.Drawing.Size(134, 16);
            this.checkBoxColSpecification.TabIndex = 19;
            this.checkBoxColSpecification.Text = "表の列指定を入力する";
            this.checkBoxColSpecification.UseVisualStyleBackColor = true;
            // 
            // textBoxColSpecification
            // 
            this.textBoxColSpecification.Location = new System.Drawing.Point(243, 197);
            this.textBoxColSpecification.Name = "textBoxColSpecification";
            this.textBoxColSpecification.Size = new System.Drawing.Size(100, 19);
            this.textBoxColSpecification.TabIndex = 20;
            // 
            // checkBoxCaptionSet
            // 
            this.checkBoxCaptionSet.AutoSize = true;
            this.checkBoxCaptionSet.Location = new System.Drawing.Point(97, 90);
            this.checkBoxCaptionSet.Name = "checkBoxCaptionSet";
            this.checkBoxCaptionSet.Size = new System.Drawing.Size(138, 16);
            this.checkBoxCaptionSet.TabIndex = 21;
            this.checkBoxCaptionSet.Text = "キャプションの設定を行う";
            this.checkBoxCaptionSet.UseVisualStyleBackColor = true;
            // 
            // checkBoxLabelSet
            // 
            this.checkBoxLabelSet.AutoSize = true;
            this.checkBoxLabelSet.Location = new System.Drawing.Point(97, 120);
            this.checkBoxLabelSet.Name = "checkBoxLabelSet";
            this.checkBoxLabelSet.Size = new System.Drawing.Size(114, 16);
            this.checkBoxLabelSet.TabIndex = 21;
            this.checkBoxLabelSet.Text = "ラベルの設定を行う";
            this.checkBoxLabelSet.UseVisualStyleBackColor = true;
            // 
            // checkBoxPostion
            // 
            this.checkBoxPostion.AutoSize = true;
            this.checkBoxPostion.Location = new System.Drawing.Point(97, 59);
            this.checkBoxPostion.Name = "checkBoxPostion";
            this.checkBoxPostion.Size = new System.Drawing.Size(134, 16);
            this.checkBoxPostion.TabIndex = 21;
            this.checkBoxPostion.Text = "表示位置の設定を行う";
            this.checkBoxPostion.UseVisualStyleBackColor = true;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(111, 264);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(415, 123);
            this.textBoxResult.TabIndex = 22;
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 450);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.checkBoxLabelSet);
            this.Controls.Add(this.checkBoxPostion);
            this.Controls.Add(this.checkBoxCaptionSet);
            this.Controls.Add(this.textBoxColSpecification);
            this.Controls.Add(this.checkBoxColSpecification);
            this.Controls.Add(this.checkBoxCenteringSpecification);
            this.Controls.Add(this.comboBoxCaptionPostion);
            this.Controls.Add(this.buttonLabelAutoFill);
            this.Controls.Add(this.textBoxCaption);
            this.Controls.Add(this.textBoxLabel);
            this.Controls.Add(this.comboBoxTable4);
            this.Controls.Add(this.comboBoxTable3);
            this.Controls.Add(this.comboBoxTable2);
            this.Controls.Add(this.comboBoxTable1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonOK);
            this.Name = "Table";
            this.Text = "Table";
            this.Load += new System.EventHandler(this.Table_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxTable4;
        private System.Windows.Forms.ComboBox comboBoxTable3;
        private System.Windows.Forms.ComboBox comboBoxTable2;
        private System.Windows.Forms.ComboBox comboBoxTable1;
        private System.Windows.Forms.TextBox textBoxLabel;
        private System.Windows.Forms.TextBox textBoxCaption;
        private System.Windows.Forms.Button buttonLabelAutoFill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCaptionPostion;
        private System.Windows.Forms.CheckBox checkBoxCenteringSpecification;
        private System.Windows.Forms.CheckBox checkBoxColSpecification;
        private System.Windows.Forms.TextBox textBoxColSpecification;
        private System.Windows.Forms.CheckBox checkBoxCaptionSet;
        private System.Windows.Forms.CheckBox checkBoxLabelSet;
        private System.Windows.Forms.CheckBox checkBoxPostion;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}