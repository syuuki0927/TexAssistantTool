﻿using System;
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




            SettingForm settingForm = new SettingForm();
            settingForm.Show(dockPanel1, DockState.Document);

        }


    }
}
