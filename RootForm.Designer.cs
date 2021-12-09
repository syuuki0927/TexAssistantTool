
namespace TexAssistantTool
{
    partial class RootForm
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
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxMain
            // 
            this.textBoxMain.AllowDrop = true;
            this.textBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMain.Location = new System.Drawing.Point(0, 0);
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.Size = new System.Drawing.Size(800, 450);
            this.textBoxMain.TabIndex = 0;
            this.textBoxMain.Text = "ここに表計算ファイル，画像ファイル，TeXファイルをドラッグアンドドロップ";
            this.textBoxMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxMain_DragDrop);
            this.textBoxMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxMain_DragEnter);
            // 
            // RootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxMain);
            this.Name = "RootForm";
            this.Text = "RootForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMain;
    }
}