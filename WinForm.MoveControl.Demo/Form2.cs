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
using WinForm.MoveControl.Demo.Content;

namespace WinForm.MoveControl.Demo
{
    public partial class Form2 : Form
    {
        TestForm testForm;
        public Form2()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            FrmContent frameControl = new FrmContent() { TabText="控件" };
            frameControl.Show(dockPanel1,  DockState.DockLeft);
             testForm = new TestForm() { TabText="测试" };
            testForm.Show(dockPanel1, DockState.Document);
            testForm.HideOnClose = true;

        }
    }
}
