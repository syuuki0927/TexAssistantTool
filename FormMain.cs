using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TexAssistantTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            dockPanel1.DocumentStyle = DocumentStyle.DockingWindow;


            //SettingForm settingForm = new SettingForm();
            //settingForm.Show(dockPanel1, DockState.Document);

            RootForm rootForm = new RootForm();
            rootForm.Show(dockPanel1, DockState.Document);

            //Setting setting = new Setting();
            //setting.Show(settingForm.Pane, DockAlignment.Bottom, 0.5);

        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show(dockPanel1, setting.Bounds);
        }
    }
}
