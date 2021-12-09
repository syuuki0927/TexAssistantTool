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
    public partial class FigureForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        //SettingsData sd = new SettingsData();
        //Form1 f1 = new Form1();

        private String fn;

        public FigureForm(String filename)
        {
            InitializeComponent();
            fn = filename;

        }

        private void Figure_Load(object sender, EventArgs e)
        {
            //設定を反映
            var settingP = Properties.Settings.Default;

            checkBoxPostion.Checked = settingP.FigurePositionSpecified;
            checkBoxCaptionSet.Checked = settingP.FigureCaptionSpecified;
            checkBoxLabelSet.Checked = settingP.FigureLabelSpecified;
            checkBoxCenteringSpecification.Checked = settingP.FigureCenteringSpecified;

            comboBoxFigure1.SelectedIndex = settingP.FigurePosition0;
            comboBoxFigure2.SelectedIndex = settingP.FigurePosition1;
            comboBoxFigure3.SelectedIndex = settingP.FigurePosition2;
            comboBoxFigure4.SelectedIndex = settingP.FigurePosition3;

            if (settingP.FigureCaptionPos == true) comboBoxCaptionPostion.SelectedIndex = 0;
            else comboBoxCaptionPostion.SelectedIndex = 1;

            checkBoxRelativePathSpecification.Checked = settingP.FigureRelativePathSpesification;
            textBoxTeXFilePath.Text = settingP.TeXFilePath;

            pictureBox.ImageLocation = fn;

        }

        

        private String FigureAnalysing()
        {
            String TexText = "\\begin{figure}";   //TeX形式の文字列を保存する変数
            bool Opflag = false;    //Optionの指定が２つ以上あるときにtrueとなる

            //位置指定を適用
            if (checkBoxPostion.Checked)
            {
                TexText += "[";
                TexText += DecPos(comboBoxFigure1.SelectedIndex);
                TexText += DecPos(comboBoxFigure2.SelectedIndex);
                TexText += DecPos(comboBoxFigure3.SelectedIndex);
                TexText += DecPos(comboBoxFigure4.SelectedIndex);
                TexText += "]";
            }
            TexText += Environment.NewLine;

            if (checkBoxCenteringSpecification.Checked) TexText += "\t\\centering" + Environment.NewLine;   //センタリングの適用
            if (comboBoxCaptionPostion.SelectedIndex == 1 && checkBoxCaptionSet.Checked) TexText += "\t\\caption{" + textBoxCaption.Text + "}" + Environment.NewLine;   //キャプションの適用
            if (comboBoxCaptionPostion.SelectedIndex == 1 && checkBoxLabelSet.Checked) TexText += "\t\\label{" + textBoxLabel.Text + "}" + Environment.NewLine;  //ラベルの適用,バグを発見、labelはキャプションの下にないといけないらしい.修正


            TexText += "\t\\includegraphics";

            //オプションの挿入
            Opflag = false;
            if (checkBoxAngle.Checked ||
                checkBoxClip.Checked ||
                checkBoxWidth.Checked ||
                checkBoxHeight.Checked ||
                checkBoxScale.Checked) //オプションのどれかがチェックされている
            {
                TexText += "[";
                if (checkBoxWidth.Checked) {
                    TexText += "width=" + textBoxWidth.Text+"cm";
                    Opflag = true;
                }
                if (checkBoxHeight.Checked) {
                    if (Opflag == true) TexText += ",";
                    TexText += "height=" + textBoxHeight.Text+"cm";
                    Opflag = true;
                }
                if (checkBoxScale.Checked) {
                    if (Opflag == true) TexText += ",";
                    TexText += "scale=" + textBoxScale.Text;
                    Opflag = true;
                }
                if (checkBoxAngle.Checked) {
                    if (Opflag == true) TexText += ",";
                    TexText += "angle=" + textBoxAngle.Text;
                    Opflag = true;
                }
                if (checkBoxClip.Checked) {
                    if (Opflag == true) TexText += ",";
                    TexText += "clip";
                    Opflag = true;
                }
                TexText += "]";
            }


            //TexText += "{" + fn.Replace("\\","/") + "}" + Environment.NewLine;
            Uri texfile = new Uri(textBoxTeXFilePath.Text);
            Uri figurefile = new Uri(fn);
            Uri relativeUri = texfile.MakeRelativeUri(figurefile);
            string relativePath = relativeUri.ToString();
            TexText += "{" + relativePath + "}" + Environment.NewLine;



            if (comboBoxCaptionPostion.SelectedIndex == 0 && checkBoxCaptionSet.Checked) TexText += "\t\\caption{" + textBoxCaption.Text + "}" + Environment.NewLine;
            if (comboBoxCaptionPostion.SelectedIndex == 0 && checkBoxLabelSet.Checked) TexText += "\t\\label{" + textBoxLabel.Text + "}" + Environment.NewLine;  //ラベルの適用,バグを発見、labelはキャプションの下にないといけないらしい.

            TexText += "\\end{figure}";



            return TexText;
        }

        private String DecPos(int posIndex) //コンボボックスのインデックスから表示位置の文字（hbpt）を返す
        {
            switch (posIndex)
            {
                case 0:
                    return "h";
                case 1:
                    return "b";
                case 2:
                    return "p";
                case 3:
                    return "t";
                default:
                    return "h";

            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkBoxPostion.Checked &&
               (comboBoxFigure1.SelectedIndex == comboBoxFigure2.SelectedIndex ||
               comboBoxFigure1.SelectedIndex == comboBoxFigure3.SelectedIndex ||
               comboBoxFigure1.SelectedIndex == comboBoxFigure4.SelectedIndex ||
               comboBoxFigure2.SelectedIndex == comboBoxFigure3.SelectedIndex ||
               comboBoxFigure2.SelectedIndex == comboBoxFigure4.SelectedIndex ||
               comboBoxFigure3.SelectedIndex == comboBoxFigure4.SelectedIndex))
            {
                MessageBox.Show("表の表示位置に同じ場所を二度設定することはできません.",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }
            else if (checkBoxCaptionSet.Checked && textBoxCaption.Text == "")
            {
                MessageBox.Show("キャプションを設定してください",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }
            else if (checkBoxLabelSet.Checked && textBoxLabel.Text == "")
            {
                MessageBox.Show("ラベルを設定してください",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }
            textBoxResult.Text = FigureAnalysing();

            //f1.setTexText(FigureAnalysing());

        }

        //width,heightとscalseは一緒にチェックされない
        private void checkBoxHeight_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHeight.Checked) checkBoxScale.Checked = false;
        }

        private void checkBoxWidth_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxWidth.Checked) checkBoxScale.Checked = false;
        }

        private void checkBoxScale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxScale.Checked)
            {
                checkBoxWidth.Checked = false;
                checkBoxHeight.Checked = false;
            }
        }
    }
}
