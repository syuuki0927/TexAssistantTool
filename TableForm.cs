using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace TexAssistantTool
{
    public partial class TableForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        //SettingsData sd = new SettingsData();
        //Form1 f1 = new Form1();

        private String fn;

        public TableForm(String filename)
        {
            InitializeComponent();
            fn = filename;
        }

        private void Table_Load(object sender, EventArgs e)
        {
            //設定を反映
            var settingP = Properties.Settings.Default;

            checkBoxPostion.Checked = settingP.TablePositionSpecified;
            checkBoxCaptionSet.Checked = settingP.TableCaptionSpecified;
            checkBoxLabelSet.Checked = settingP.TableLabelSpecified;
            checkBoxCenteringSpecification.Checked = settingP.TableCenteringSpecified;

            comboBoxTable1.SelectedIndex = settingP.TablePosition0;
            comboBoxTable2.SelectedIndex = settingP.TablePosition1;
            comboBoxTable3.SelectedIndex = settingP.TablePosition2;
            comboBoxTable4.SelectedIndex = settingP.TablePosition3;

            if (settingP.TableCaptionPos == true) comboBoxCaptionPostion.SelectedIndex = 0;
            else comboBoxCaptionPostion.SelectedIndex = 1;

        }

        private String TableAnalysing()
        {
            String TexText="";

            int i, j;

            int lastRow, firstRow, lastCol, firstCol;   //使用しているセルの範囲を保持

            var workbook = new XLWorkbook(fn);  
            var workseet = workbook.Worksheet("Sheet1");

            var lastline = workseet.Cell("A1").Style.Border.TopBorder;   //以前の線を保持。線の判定で使用
            var lastline2 = workseet.Cell("A1").Style.Border.TopBorder;   //以前の線を保持。線の判定で使用

            int first;  //線の判定で使用
            String line = "";    //線の判定で使用

            //var rangeUsed = workseet.RangeUsed();

            lastRow = workseet.LastRowUsed().RowNumber();
            firstRow = workseet.FirstRowUsed().RowNumber();
            lastCol = workseet.LastColumnUsed().ColumnNumber();
            firstCol = workseet.FirstColumnUsed().ColumnNumber();

            TexText += "\\begin{table}";
            if (checkBoxPostion.Checked)
            {
                TexText += "[";
                TexText += DecPos(comboBoxTable1.SelectedIndex);
                TexText += DecPos(comboBoxTable2.SelectedIndex);
                TexText += DecPos(comboBoxTable3.SelectedIndex);
                TexText += DecPos(comboBoxTable4.SelectedIndex);
                TexText += "]"+Environment.NewLine;
            }
            else
            {
                TexText += Environment.NewLine;
            }

            if (checkBoxCenteringSpecification.Checked) TexText += "\t\\centering" + Environment.NewLine;
            if (comboBoxCaptionPostion.SelectedIndex == 0 && checkBoxCaptionSet.Checked)TexText += "\t\\caption{"+textBoxCaption.Text+"}" + Environment.NewLine;
            if (checkBoxLabelSet.Checked) TexText += "\t\\label{" + textBoxLabel.Text + "}" + Environment.NewLine;

            TexText += "\t\\begin{tabular}{";

            //一番最初の線で一つ前の線を保持する変数を初期化
            lastline = workseet.Cell(firstRow, firstCol).Style.Border.TopBorder;

            //最初のセルが２列目以降の時は上のセルの下側の線についても検証する
            if (lastline != XLBorderStyleValues.Double && firstRow >= 2)
            {
                if (lastline == XLBorderStyleValues.None ||
                    (lastline == XLBorderStyleValues.Thin && workseet.Cell(firstRow - 1, firstCol).Style.Border.BottomBorder != XLBorderStyleValues.None))
                {
                    lastline = workseet.Cell(firstRow - 1, firstCol).Style.Border.BottomBorder;
                }
            }
           
            first = 1;
            //縦線の有無、文字の位置（c,r,l)を最初の行から判定
            for (i = firstCol; i <= lastCol; i++)
            {
                //縦線の判定
                if (workseet.Cell(firstRow, i).Style.Border.LeftBorder == XLBorderStyleValues.Double
                    || (i >= 2 && workseet.Cell(firstRow, i - 1).Style.Border.RightBorder == XLBorderStyleValues.Double)) TexText += "||";  //2本線の判定
                else if (workseet.Cell(firstRow, i).Style.Border.LeftBorder == XLBorderStyleValues.Thin
                    || (i >= 2 && workseet.Cell(firstRow, i - 1).Style.Border.RightBorder == XLBorderStyleValues.Thin)) TexText += "|";    //1本線の判定

                //列指定の判定
                if (workseet.Cell(firstRow, i).Style.Alignment.Horizontal == XLAlignmentHorizontalValues.Center) TexText += "c";
                else if (workseet.Cell(firstRow, i).Style.Alignment.Horizontal == XLAlignmentHorizontalValues.Right) TexText += "r";
                else TexText += "l";

                //表の一番上の線について判定
                try
                {
                    if (lastline == XLBorderStyleValues.None &&
                    (lastline != workseet.Cell(firstRow, i).Style.Border.TopBorder && lastline != workseet.Cell(firstRow - 1, i).Style.Border.BottomBorder))
                    {
                        first = i + 1 - firstCol;
                        if (workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.Double || workseet.Cell(firstRow - 1, i).Style.Border.BottomBorder == XLBorderStyleValues.Double)
                        {
                            lastline = XLBorderStyleValues.Double;
                        }
                        else
                        {
                            lastline = XLBorderStyleValues.Thin;
                        }
                    }
                    else if (lastline == XLBorderStyleValues.Thin &&
                        (workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.None && workseet.Cell(firstRow - 1, i).Style.Border.BottomBorder == XLBorderStyleValues.None))
                    {
                        line += "\\cline{" + first + "-" + (i - firstCol) + "}";
                        first = i + 1 - firstCol;
                        lastline = XLBorderStyleValues.None;
                    }
                    else if (lastline == XLBorderStyleValues.Thin &&
                        (workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.Double || workseet.Cell(firstRow - 1, i).Style.Border.BottomBorder == XLBorderStyleValues.Double))
                    {
                        line += "\\cline{" + first + "-" + (i - firstCol) + "}";
                        first = i + 1 - firstCol;
                        lastline = XLBorderStyleValues.Double;
                    }
                    else if (lastline == XLBorderStyleValues.Double &&
                        ((workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.None && workseet.Cell(firstRow - 1, i).Style.Border.BottomBorder == XLBorderStyleValues.None) ||
                        (workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.Thin && workseet.Cell(firstRow - 1, i).Style.Border.BottomBorder == XLBorderStyleValues.Thin)))
                    {
                        line += "\\cline{" + first + "-" + (i - firstCol) + "}";
                        line += "\\cline{" + first + "-" + (i - firstCol) + "}";
                        first = i + 1 - firstCol;
                        lastline = workseet.Cell(firstRow, i).Style.Border.TopBorder;
                        MessageBox.Show("二重線は途中で線の種類を変えることはできません.",
                        "エラー",
                        MessageBoxButtons.OK);
                        return "";
                    }
                }
                catch(ArgumentOutOfRangeException e)
                {
                    if (lastline == XLBorderStyleValues.None &&
                    (lastline != workseet.Cell(firstRow, i).Style.Border.TopBorder))
                    {
                        first = i + 1 - firstCol;
                        if (workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.Double)
                        {
                            lastline = XLBorderStyleValues.Double;
                        }
                        else
                        {
                            lastline = XLBorderStyleValues.Thin;
                        }
                    }
                    else if (lastline == XLBorderStyleValues.Thin &&
                        (workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.None))
                    {
                        line += "\\cline{" + first + "-" + (i - firstCol) + "}";
                        first = i + 1 - firstCol;
                        lastline = XLBorderStyleValues.None;
                    }
                    else if (lastline == XLBorderStyleValues.Thin &&
                        (workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.Double))
                    {
                        line += "\\cline{" + first + "-" + (i - firstCol) + "}";
                        first = i + 1 - firstCol;
                        lastline = XLBorderStyleValues.Double;
                    }
                    else if (lastline == XLBorderStyleValues.Double &&
                        ((workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.None ) ||
                        (workseet.Cell(firstRow, i).Style.Border.TopBorder == XLBorderStyleValues.Thin )))
                    {
                        line += "\\cline{" + first + "-" + (i - firstCol) + "}";
                        line += "\\cline{" + first + "-" + (i - firstCol) + "}";
                        first = i + 1 - firstCol;
                        lastline = workseet.Cell(firstRow, i).Style.Border.TopBorder;
                        MessageBox.Show("二重線は途中で線の種類を変えることはできません.",
                        "エラー",
                        MessageBoxButtons.OK);
                        return "";
                    }
                }
                
               

            }

            //最後の縦線の有無を判定
            if (workseet.Cell(firstRow, lastCol).Style.Border.RightBorder == XLBorderStyleValues.Double ||
                workseet.Cell(firstRow, lastCol + 1).Style.Border.LeftBorder == XLBorderStyleValues.Double) TexText += "||}"; 
            else if(workseet.Cell(firstRow, lastCol).Style.Border.RightBorder == XLBorderStyleValues.Thin ||
                workseet.Cell(firstRow, lastCol + 1).Style.Border.LeftBorder == XLBorderStyleValues.Thin) TexText += "|}";
            else TexText += "}";

            if (first == 1)
            {
                //firstが更新されていなければ出力はclineではなくhlineになる
                if (lastline == XLBorderStyleValues.Thin) line = "\\hline";
                else if (lastline == XLBorderStyleValues.Double) line = "\\hline \\hline";
                //else if (lastline2 == XLBorderStyleValues.Thin) line = "\\hline";
                //else if (lastline2 == XLBorderStyleValues.Double) line = "\\hline \\hline";
                else line = "";
            }

            TexText += line + Environment.NewLine;


            //表の要素の出力及び線の判定
            lastline = workseet.Cell(firstRow, firstCol).Style.Border.BottomBorder;
            //最初のセルが２列目以降の時は上のセルの下側の線についても検証する
            if (lastline != XLBorderStyleValues.Double )
            {
                if (lastline == XLBorderStyleValues.None ||
                    (lastline == XLBorderStyleValues.Thin && workseet.Cell(firstRow + 1, firstCol).Style.Border.TopBorder != XLBorderStyleValues.None))
                {
                    lastline = workseet.Cell(firstRow + 1, firstCol).Style.Border.TopBorder;
                }
            }

            //lastline = workseet.Cell(firstRow, firstCol).Style.Border.BottomBorder;
            ////２列目以降の時は上のセルの下側の線についても検証する
            //lastline2 = workseet.Cell(firstRow - 1, firstCol).Style.Border.TopBorder;
            first = 1;
            line = "";
            for (i = firstRow; i <= lastRow; i++)
            {
                //線の判定用変数の初期化
                //lastline = workseet.Cell(i, firstCol).Style.Border.BottomBorder;
                //lastline2 = workseet.Cell(i + 1, firstCol).Style.Border.TopBorder;
                lastline = workseet.Cell(i, firstCol).Style.Border.BottomBorder;
                //最初のセルが２列目以降の時は上のセルの下側の線についても検証する
                if (lastline != XLBorderStyleValues.Double)
                {
                    if (lastline == XLBorderStyleValues.None ||
                        (lastline == XLBorderStyleValues.Thin && workseet.Cell(i + 1, firstCol).Style.Border.TopBorder != XLBorderStyleValues.None))
                    {
                        lastline = workseet.Cell(i + 1, firstCol).Style.Border.TopBorder;
                    }
                }
                first = 1;
                line = "";
                for (j = firstCol; j <= lastCol; j++)
                {
                    if (j != firstCol) TexText += "&";
                    else TexText += "\t";
                    TexText += workseet.Cell(i, j).GetString();
                    if (j == lastCol) TexText += "\t\\\\";

                    //表の一番上の線について判定
                    if (lastline == XLBorderStyleValues.None && (lastline != workseet.Cell(i, j).Style.Border.BottomBorder && lastline != workseet.Cell(i + 1, j).Style.Border.TopBorder))
                    {
                        first = j + 1 - firstCol;
                        if (workseet.Cell(i, j).Style.Border.BottomBorder == XLBorderStyleValues.Double || workseet.Cell(i + 1, j).Style.Border.TopBorder == XLBorderStyleValues.Double)
                        {
                            lastline = XLBorderStyleValues.Double;
                        }
                        else
                        {
                            lastline = XLBorderStyleValues.Thin;
                        }
                    }
                    else if (lastline == XLBorderStyleValues.Thin &&
                        (workseet.Cell(i, j).Style.Border.BottomBorder == XLBorderStyleValues.None && workseet.Cell(i + 1, j).Style.Border.TopBorder == XLBorderStyleValues.None))
                    {
                        line += "\\cline{" + first + "-" + (j - firstCol) + "}";
                        first = j + 1 - firstCol;
                        lastline = XLBorderStyleValues.None;
                    }
                    else if (lastline == XLBorderStyleValues.Thin &&
                        (workseet.Cell(i, j).Style.Border.BottomBorder == XLBorderStyleValues.Double || workseet.Cell(i + 1, j).Style.Border.TopBorder == XLBorderStyleValues.Double))
                    {
                        line += "\\cline{" + first + "-" + (j - firstCol) + "}";
                        first = j + 1 - firstCol;
                        lastline = XLBorderStyleValues.Double;
                    }
                    else if (lastline == XLBorderStyleValues.Double &&
                        ((workseet.Cell(i, j).Style.Border.BottomBorder == XLBorderStyleValues.None && workseet.Cell(i + 1, j).Style.Border.TopBorder == XLBorderStyleValues.None) ||
                        (workseet.Cell(i, j).Style.Border.BottomBorder != XLBorderStyleValues.Double && workseet.Cell(i + 1, j).Style.Border.TopBorder != XLBorderStyleValues.Double)))
                    {
                        line += "\\cline{" + first + "-" + (j - firstCol) + "}";
                        line += "\\cline{" + first + "-" + (j - firstCol) + "}";
                        first = j + 1 - firstCol;
                        if (workseet.Cell(i, j).Style.Border.BottomBorder == XLBorderStyleValues.None && workseet.Cell(i + 1, j).Style.Border.TopBorder == XLBorderStyleValues.None)
                        {
                            lastline = XLBorderStyleValues.None;
                        }
                        else
                            lastline = XLBorderStyleValues.Thin;
                        MessageBox.Show("二重線は途中で線の種類を変えることはできません.",
                    "エラー",
                    MessageBoxButtons.OK);
                        return "";
                    }

                   
                }

                if (first == 1)
                {
                    //firstが更新されていなければ出力はclineではなくhlineになる
                    if (lastline == XLBorderStyleValues.Thin) line = "\\hline";
                    else if (lastline == XLBorderStyleValues.Double) line = "\\hline \\hline";
                    //else if (lastline2 == XLBorderStyleValues.Thin) line = "\\hline";
                    //else if (lastline2 == XLBorderStyleValues.Double) line = "\\hline \\hline";
                    else line = "";
                }
                else if (lastline == XLBorderStyleValues.Thin) line += "\\cline{" + first + "-" + (j - firstCol) + "}";
                else if (lastline == XLBorderStyleValues.Double)
                {
                    line += "\\cline{" + first + "-" + (j - firstCol) + "}";
                    line += "\\cline{" + first + "-" + (j - firstCol) + "}";
                } 
       
                TexText += line + Environment.NewLine;
            }

            TexText += "\t\\end{tabular}" + Environment.NewLine;
            if (comboBoxCaptionPostion.SelectedIndex == 1 && checkBoxCaptionSet.Checked) TexText += "\t\\caption{" + textBoxCaption.Text + "}" + Environment.NewLine;

            TexText += "\\end{table}";

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

            //エラーの判定
            if (checkBoxPostion.Checked &&
               (comboBoxTable1.SelectedIndex == comboBoxTable2.SelectedIndex ||
               comboBoxTable1.SelectedIndex == comboBoxTable3.SelectedIndex ||
               comboBoxTable1.SelectedIndex == comboBoxTable4.SelectedIndex ||
               comboBoxTable2.SelectedIndex == comboBoxTable3.SelectedIndex ||
               comboBoxTable2.SelectedIndex == comboBoxTable4.SelectedIndex ||
               comboBoxTable3.SelectedIndex == comboBoxTable4.SelectedIndex))
            {
                MessageBox.Show("表の表示位置に同じ場所を二度設定することはできません.",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }else if(checkBoxCaptionSet.Checked && textBoxCaption.Text == "")
            {
                MessageBox.Show("キャプションを設定してください",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }
            else if(checkBoxLabelSet.Checked && textBoxLabel.Text == "")
            {
                MessageBox.Show("ラベルを設定してください",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }else if(checkBoxColSpecification.Checked && textBoxColSpecification.Text == "")
            {
                MessageBox.Show("列指定を入力してください",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }
            else
            {
                textBoxResult.Text = TableAnalysing();

                //f1.setTexText(TableAnalysing());
                //this.Close();
                return;
            }

            
        }

        private void ButtonLabelAutoFill_Click(object sender, EventArgs e)
        {

        }
    }
}
