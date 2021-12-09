using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TexAssistantTool
{
    public partial class RootForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private FormMain formMain;  //メインフォームのインスタンスを保持

        public RootForm(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            textBoxMain.AppendText(Environment.NewLine);
        }

        private void textBoxMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            textBoxMain.AppendText(fileName[0] + "が入力されました" + Environment.NewLine);
            string extension = System.IO.Path.GetExtension(fileName[0]);

            if(extension==".xlsx")
            {
                //エクセルファイルに対応するフォームを起動
                formMain.TableFormShow(fileName[0]);
                
            }
            else if(extension == ".png" || extension == ".jpg" || extension == ".JPG" || extension == ".JPEG" || extension == ".jpeg" || extension == ".eps")
            {
                //画像ファイルに対応するフォームを起動
                formMain.FigureFormShow(fileName[0]);
            }
            else if(extension == ".tex")
            {
                //TeXファイルに対応するフォームを起動
                var settingP = Properties.Settings.Default;
                settingP.TeXFilePath = System.IO.Path.GetDirectoryName(fileName[0]) + "\\";
                settingP.Save();
                MessageBox.Show(settingP.TeXFilePath + "がTeXファイルのディレクトリに設定されました",
                    "メッセージ",
                    MessageBoxButtons.OK);


            }
        }

        private void textBoxMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
