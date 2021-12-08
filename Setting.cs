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
    public partial class Setting : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        SettingsData sd = new SettingsData();
        

        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {

            sd.pLoad();

            //設定のクラスからインターフェースに既存の設定値を反映させる
            //checkedListBoxTable.SetItemChecked(0, sd.getTableLabelSpecified());
            //checkedListBoxTable.SetItemChecked(1, sd.getTableCaptionSpecified());
            //checkedListBoxTable.SetItemChecked(2, sd.getTableCenteringSpecified());

            //checkedListBoxFigure.SetItemChecked(0, sd.getFigureLabelSpecified());
            //checkedListBoxFigure.SetItemChecked(1, sd.getFigureCaptionSpecified());
            //checkedListBoxFigure.SetItemChecked(2, sd.getFigureCenteringSpecified());

            //checkBoxTablePos.Checked = sd.getTablePositionSpecified();
            //checkBoxFigurePos.Checked = sd.getFigurePositionSpecified();

            //if (sd.getTableCaptionPos()) comboBoxTableCaptionPos.SelectedIndex = 0;
            //else comboBoxTableCaptionPos.SelectedIndex = 1;

            //if (sd.getFigureCaptionPos()) comboBoxFigureCaptionPos.SelectedIndex = 0;
            //else comboBoxFigureCaptionPos.SelectedIndex = 1;

            

            //comboBoxTable1.SelectedIndex = sd.getTablePosition()[0];
            //comboBoxTable2.SelectedIndex = sd.getTablePosition()[1];
            //comboBoxTable3.SelectedIndex = sd.getTablePosition()[2];
            //comboBoxTable4.SelectedIndex = sd.getTablePosition()[3];

            //comboBoxFigure1.SelectedIndex = sd.getFigurePosition()[0];
            //comboBoxFigure2.SelectedIndex = sd.getFigurePosition()[1];
            //comboBoxFigure3.SelectedIndex = sd.getFigurePosition()[2];
            //comboBoxFigure4.SelectedIndex = sd.getFigurePosition()[3];

            //kokokara

            var settingP = Properties.Settings.Default;

            checkedListBoxTable.SetItemChecked(0, settingP.TableLabelSpecified);
            checkedListBoxTable.SetItemChecked(1, settingP.TableCaptionSpecified);
            checkedListBoxTable.SetItemChecked(2, settingP.TableCenteringSpecified);

            checkedListBoxFigure.SetItemChecked(0, sd.getFigureLabelSpecified());
            checkedListBoxFigure.SetItemChecked(1, settingP.FigureCaptionSpecified);
            checkedListBoxFigure.SetItemChecked(2, settingP.FigureCenteringSpecified);

            checkBoxTablePos.Checked = settingP.TablePositionSpecified;
            checkBoxFigurePos.Checked = settingP.FigurePositionSpecified;

            if (settingP.TableCaptionPos) comboBoxTableCaptionPos.SelectedIndex = 0;
            else comboBoxTableCaptionPos.SelectedIndex = 1;

            if (settingP.FigureCaptionPos) comboBoxFigureCaptionPos.SelectedIndex = 0;
            else comboBoxFigureCaptionPos.SelectedIndex = 1;



            comboBoxTable1.SelectedIndex = settingP.TablePosition0;
            comboBoxTable2.SelectedIndex = settingP.TablePosition1;
            comboBoxTable3.SelectedIndex = settingP.TablePosition2;
            comboBoxTable4.SelectedIndex = settingP.TablePosition3;

            comboBoxFigure1.SelectedIndex = settingP.FigurePosition0;
            comboBoxFigure2.SelectedIndex = settingP.FigurePosition1;
            comboBoxFigure3.SelectedIndex = settingP.FigurePosition2;
            comboBoxFigure4.SelectedIndex = settingP.FigurePosition3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //エラーの判定
            if (comboBoxTable1.SelectedIndex == comboBoxTable2.SelectedIndex ||
               comboBoxTable1.SelectedIndex == comboBoxTable3.SelectedIndex ||
               comboBoxTable1.SelectedIndex == comboBoxTable4.SelectedIndex ||
               comboBoxTable2.SelectedIndex == comboBoxTable3.SelectedIndex ||
               comboBoxTable2.SelectedIndex == comboBoxTable4.SelectedIndex ||
               comboBoxTable3.SelectedIndex == comboBoxTable4.SelectedIndex)
            {
                MessageBox.Show("表の表示位置に同じ場所を二度設定することはできません.",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }
                

            if (comboBoxFigure1.SelectedIndex == comboBoxFigure2.SelectedIndex ||
               comboBoxFigure1.SelectedIndex == comboBoxFigure3.SelectedIndex ||
               comboBoxFigure1.SelectedIndex == comboBoxFigure4.SelectedIndex ||
               comboBoxFigure2.SelectedIndex == comboBoxFigure3.SelectedIndex ||
               comboBoxFigure2.SelectedIndex == comboBoxFigure4.SelectedIndex ||
               comboBoxFigure3.SelectedIndex == comboBoxFigure4.SelectedIndex)
            {
                MessageBox.Show("図の表示位置に同じ場所を二度設定することはできません.",
                    "エラー",
                    MessageBoxButtons.OK);
                return;
            }

            //SettingsDataのフィールドを書き換える
            //sd.setTableLabelSpecified(checkedListBoxTable.GetItemChecked(0));
            //sd.setTableCaptionSpecified(checkedListBoxTable.GetItemChecked(1));
            //sd.setTableCenteringSpecified(checkedListBoxTable.GetItemChecked(2));

            //sd.setFigureLabelSpecified(checkedListBoxFigure.GetItemChecked(0));
            //sd.setFigureCaptionSpecified(checkedListBoxFigure.GetItemChecked(1));
            //sd.setFigureCenteringSpecified(checkedListBoxFigure.GetItemChecked(2));

            //sd.setTablePositionSpecified(checkBoxTablePos.Checked);
            //sd.setFigurePositionSpecified(checkBoxFigurePos.Checked);

            //if (comboBoxTableCaptionPos.SelectedIndex == 0) sd.setTableCaptionPos(true);
            //else sd.setTableCaptionPos(false);

            //if (comboBoxFigureCaptionPos.SelectedIndex == 0) sd.setFigureCaptionPos(true);
            //else sd.setFigureCaptionPos(false);

            //sd.setTablePosition(comboBoxTable1.SelectedIndex,
            //    comboBoxTable2.SelectedIndex,
            //    comboBoxTable3.SelectedIndex,
            //    comboBoxTable4.SelectedIndex);

            //sd.setFigurePosition(comboBoxFigure1.SelectedIndex,
            //    comboBoxFigure2.SelectedIndex,
            //    comboBoxFigure3.SelectedIndex,
            //    comboBoxFigure4.SelectedIndex);

            //sd.pEnd();





            var settingP = Properties.Settings.Default;
            settingP.TableLabelSpecified = checkedListBoxTable.GetItemChecked(0);
            settingP.TableCaptionSpecified = checkedListBoxTable.GetItemChecked(1);
            settingP.TableCenteringSpecified = checkedListBoxTable.GetItemChecked(2);

            settingP.FigureLabelSpecified = checkedListBoxFigure.GetItemChecked(0);
            settingP.FigureCaptionSpecified = checkedListBoxFigure.GetItemChecked(1);
            settingP.FigureCenteringSpecified = checkedListBoxFigure.GetItemChecked(2);

            settingP.TablePositionSpecified = checkBoxTablePos.Checked;
            settingP.FigurePositionSpecified = checkBoxFigurePos.Checked;

            settingP.TableCaptionPos = (comboBoxTableCaptionPos.SelectedIndex == 0);
            settingP.FigureCaptionPos = (comboBoxFigureCaptionPos.SelectedIndex == 0);

            settingP.TablePosition0 = comboBoxTable1.SelectedIndex;
            settingP.TablePosition1 = comboBoxTable2.SelectedIndex;
            settingP.TablePosition2 = comboBoxTable3.SelectedIndex;
            settingP.TablePosition3 = comboBoxTable4.SelectedIndex;

            settingP.FigurePosition0 = comboBoxFigure1.SelectedIndex;
            settingP.FigurePosition1 = comboBoxFigure2.SelectedIndex;
            settingP.FigurePosition2 = comboBoxFigure3.SelectedIndex;
            settingP.FigurePosition3 = comboBoxFigure4.SelectedIndex;

            settingP.Save();




            this.Close();

        }
    }
}
