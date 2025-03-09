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

namespace WinForm.MoveControl.Demo.Content
{
    public partial class FrmProPer :  DockContent
    {
        ControlManager ControlHelper;
        public FrmProPer(ControlManager controlManager)
        {
            InitializeComponent();
            ControlHelper = controlManager;
            ControlHelper.propertyGrid = this.propertyGrid1;
        }

    }
}
