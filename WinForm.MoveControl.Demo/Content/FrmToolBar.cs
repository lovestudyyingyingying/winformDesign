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
    public partial class FrmToolBar : DockContent
    {
        public FrmToolBar( ControlManager controlManager, PropertyGrid propertyGrid, Panel panel)
        {
            InitializeComponent();
            ControlHelper = controlManager;
            propertyGrid1 = propertyGrid;
            panel1 = panel;
        }
        private PropertyGrid propertyGrid1;
        private Panel panel1;
        ControlManager ControlHelper;
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "启用")
            {
                button2.Text = "disable";
                foreach (Control item in panel1.Controls)
                {
                    if (item is FrameControl) continue;
                    item.SetMove();
                    item.Enabled = false;
                }
                propertyGrid1.Visible = true;
                //uiNavMenu1.Visible = true;
            }
            else
            {
                button2.Text = "启用";
                foreach (Control item in panel1.Controls)
                {
                    item.DisMove();
                    item.Enabled = true;
                }
                propertyGrid1.Visible = false;
                // uiNavMenu1.Visible = false;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            ControlHelper.SaveContorl(panel1);
        }



        private void btnSameMax_Click(object sender, EventArgs e)
        {
            var standerControl = ControlExtensions.FirstClickControl;
            if (standerControl != null && standerControl.control != null)
            {

                foreach (Control control in panel1.Controls)
                {
                    if (!control.Visible) continue;

                    if (control is FrameControl frameControl)
                    {
                        frameControl.control.Size = standerControl.control.Size;
                        frameControl.Size = standerControl.Size;
                        frameControl.BringToFront();
                    }
                }
            }
        }

        private void btnSameMiddle_Click(object sender, EventArgs e)
        {
            var standerControl = ControlExtensions.FirstClickControl;
            if (standerControl != null && standerControl.control != null)
            {
                // 获取控件的中心位置
                Point center = new Point(
                    standerControl.control.Left + standerControl.control.Width / 2,
                    standerControl.control.Top + standerControl.control.Height / 2
                );
                foreach (Control control in panel1.Controls)
                {
                    if (!control.Visible) continue;
                    if (control is FrameControl frameControl)
                    {
                        frameControl.control.Location = new Point(frameControl.control.Location.X, center.Y - frameControl.control.Height / 2);
                        frameControl.Location = new Point(frameControl.Location.X, center.Y - frameControl.Height / 2);
                    }
                }
            }
        }

        private void btnVertialSame_Click(object sender, EventArgs e)
        {
            var standerControl = ControlExtensions.FirstClickControl;
            if (standerControl != null && standerControl.control != null)
            {
                // 获取控件的中心位置
                Point center = new Point(
                    standerControl.control.Left + standerControl.control.Width / 2,
                    standerControl.control.Top + standerControl.control.Height / 2
                );
                foreach (Control control in panel1.Controls)
                {
                    if (!control.Visible) continue;
                    if (control is FrameControl frameControl)
                    {
                        frameControl.control.Location = new Point(center.X - frameControl.control.Width / 2, frameControl.control.Location.Y);
                        frameControl.Location = new Point(center.X - frameControl.Width / 2, frameControl.Location.Y);
                    }
                }
            }
        }



    }
}
