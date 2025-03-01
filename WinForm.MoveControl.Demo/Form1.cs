using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WinForm.MoveControl.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ControlHelper.GetContorl(panel1);
            ControlHelper.propertyGrid = this.propertyGrid1;
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0], 61451);
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[0], 61640);
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[1], 61490);
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[2], 61489);


        }
        ControlManager ControlHelper = new ControlManager();
        private void Form1_Load(object sender, EventArgs e)
        {
            //button1.DisMove();
            //button1.SetMove();

            //label1.SetMove();

            propertyGrid1.Visible = false;
            uiNavMenu1.Visible = false;
        }

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
                uiNavMenu1.Visible = true;
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
                uiNavMenu1.Visible = false;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            ControlHelper.SaveContorl(panel1);
        }

        private void uiNavMenu1_DoubleClick(object sender, EventArgs e)
        {
            var node = uiNavMenu1.SelectedNode;
            Control control = null;
            if (node.Text == "button")
            {
                control = new Button();
                control.Name = "button" + DateTime.Now.ToFileTimeUtc();
            }
            else if (node.Text == "label")
            {
                control = new System.Windows.Forms.Label();
                control.Name = "label" + DateTime.Now.ToFileTimeUtc();
            }
            else if (node.Text == "number")
            {
                control = new System.Windows.Forms.NumericUpDown();
                control.Name = "number" + DateTime.Now.ToFileTimeUtc();
            }
            control.Text = "未命名";
            control.Size = new System.Drawing.Size(100, 20);
            control.Location = new System.Drawing.Point(0, 0);
            control.SetMove();
            control.Enabled = false;
            control.MouseClick += (obj, arg) =>
            {

                propertyGrid1.SelectedObject = obj;
            };
            control.BringToFront();
            panel1.Controls.Add(control);
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
                        frameControl.Location = new Point( frameControl.Location.X, center.Y - frameControl.Height / 2);
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
                        frameControl.control.Location = new Point( center.X - frameControl.control.Width / 2, frameControl.control.Location.Y);
                        frameControl.Location = new Point( center.X - frameControl.Width / 2, frameControl.Location.Y);
                    }
                }
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            var location = e.Location;
            foreach (Control control in panel1.Controls)
            {
                if (control is FrameControl) continue;
                if (control.Visible && control.Bounds.Contains(location))
                {
                    string dicStr = control.Name + "MouseClick";
                    if (ControlExtensions.EventList.ContainsKey(dicStr))
                    {
                        ControlExtensions.EventList[dicStr](control, e);
                        propertyGrid1.SelectedObject = control;
                    }
                }

            }
        }
        Control downControl = null;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            var location = e.Location;
            foreach (Control control in panel1.Controls)
            {
                if (control is FrameControl) continue;
                if (control.Visible && control.Bounds.Contains(location))
                {
                    string dicStr = control.Name + "MouseDown";
                    if (ControlExtensions.EventList.ContainsKey(dicStr))
                    {
                        ControlExtensions.EventList[dicStr](control, e);
                        downControl = control;
                    }
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            var location = e.Location;
            foreach (Control control in panel1.Controls)
            {
                if (control is FrameControl) continue;
                if (control.Visible && control.Bounds.Contains(location))
                {
                    string dicStr = control.Name + "MouseUp";
                    if (ControlExtensions.EventList.ContainsKey(dicStr))
                    {
                        ControlExtensions.EventList[dicStr](control, e);
                    }
                }
            }
            downControl = null;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (downControl == null) return;
            var location = e.Location;
            foreach (Control control in panel1.Controls)
            {
                if (control is FrameControl) continue;
                if (downControl != control) continue;
                if (control.Visible && control.Bounds.Contains(location))
                {
                    string dicStr = control.Name + "MouseMove";
                    if (ControlExtensions.EventList.ContainsKey(dicStr))
                    {
                        ControlExtensions.EventList[dicStr](control, e);
                    }
                }
            }
        }
    }

}
