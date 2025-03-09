using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WinForm.MoveControl.Demo
{
    public partial class Form1 : UIForm
    {
        /// <summary>
        /// 控件类型名称如：Sunny.UI
        /// </summary>
        [Category("自定义属性"), DisplayName("控件类型名称"), Description("控件类型名称如：Sunny.UI")]
        public string ContorlTypeName { get; set; } = "Sunny.UI";

        /// <summary>
        /// 控件类型名称如：Sunny
        /// </summary>
        [Category("自定义属性"), DisplayName("控件可链接动态库dll名称"), Description("可链接动态库dll文件名称")]
        public string ContorlDllName { get; set; } = "SunnyUI";

        public Form1()
        {
            InitializeComponent();
            ControlHelper.GetContorl(panel1);
            ControlHelper.propertyGrid = this.propertyGrid1;
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0], 61451);
            //uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[0], 61640);
            //uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[1], 61490);
            //uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[2], 61489);

            //在左侧菜单栏加载控件
            uiNavMenu1.Nodes[0].Nodes.Clear();

            var assList = Assembly.Load(ContorlDllName).GetTypes();
            foreach (var ass in assList)
            {
                if (ass.Namespace == ContorlTypeName && !ass.IsSealed && ass.IsPublic)
                {
                    var isContorl = CheckTypeIsContorl(ass);
                    if (isContorl)
                        uiNavMenu1.Nodes[0].Nodes.Add(ass.Name);
                }
            }
            foreach (UIImageButton control in panel2.Controls)
            {
                UIToolTip tip = new UIToolTip();
                tip.SetToolTip(control, control.TagString);
            }
            GlobalKeyboardHook.OnKeyDown += (sender, e) =>
            {
                if (e != Keys.Delete) return;

                List<Control> list = GetSelectControls();
                foreach (Control control in list)
                {
                    panel1.Controls.Remove(control);

                }
            };
            new ResizableControlHelper(uiNavMenu1);
            new ResizableControlHelper(uiPanel1);

        }
        ControlManager ControlHelper = new ControlManager();
        private void Form1_Load(object sender, EventArgs e)
        {

            uiPanel1.Visible = false;
            uiNavMenu1.Visible = false;
        }
        private bool CheckTypeIsContorl(Type type)
        {
            if (type == null)
                return false;
            if (type.Name.Contains("Form"))
                return false;
            if (type.Name == "Control")
                return true;
            else
                return CheckTypeIsContorl(type.BaseType);


        }
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (btnLock.TagString == "启用")
            {
                btnLock.TagString = "禁用";
                btnLock.Image = Properties.Resources.启用;
                foreach (Control item in panel1.Controls)
                {
                    if (item is FrameControl) continue;
                    item.SetMove();
                    item.Enabled = false;
                }
                uiPanel1.Visible = true;
                uiNavMenu1.Visible = true;
            }
            else
            {
                btnLock.TagString = "启用";
                btnLock.Image = Properties.Resources.禁用;

                foreach (Control item in panel1.Controls)
                {
                    item.DisMove();
                    item.Enabled = true;
                }
                uiPanel1.Visible = false;
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

            string typeStr = node.Text;
            string controlName = ContorlTypeName + "." + typeStr;
            Assembly winFormsAssembly = Assembly.Load(ContorlDllName);
            Type type = winFormsAssembly.GetType(controlName);
            // Type test = Type.GetType(controlName);
            if (type == null)
                return;
            control = (Control)Activator.CreateInstance(type);
            control.Name = typeStr + DateTime.Now.ToFileTimeUtc();
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
        bool m_mouseDown = false;
        private void uiNavMenu1_MouseDown(object sender, MouseEventArgs e)
        {
            //if(uiNavMenu1.SelectedNode!=null)
            //this.DoDragDrop(uiNavMenu1.SelectedNode.Text, DragDropEffects.Move);
            //base.OnMouseDown(e);
            m_mouseDown = true;
        }

        private void uiNavMenu1_MouseMove(object sender, MouseEventArgs e)
        {
            if (uiNavMenu1.SelectedNode == null) return;
            if (Cursor.Current != Cursors.Default) return;

            base.OnMouseMove(e);
            if (m_mouseDown)
            {
                this.DoDragDrop(uiNavMenu1.SelectedNode.Text, DragDropEffects.Move);
            }
            //base.OnMouseMove(e);

        }



        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string typeStr = e.Data.GetData(DataFormats.Text).ToString();
            Control control = null;
            string controlName = ContorlTypeName + "." + typeStr;
            Assembly winFormsAssembly =Assembly.Load(ContorlDllName);
            Type type = winFormsAssembly.GetType(controlName);
            if (type == null) return;
            control = (Control)Activator.CreateInstance(type);
            control.Name = typeStr + DateTime.Now.ToFileTimeUtc();
            control.Text = "未命名";
            control.Size = new System.Drawing.Size(100, 20);
            control.SetMove();
            control.Enabled = false;

            control.MouseClick += (obj, arg) =>
            {

                propertyGrid1.SelectedObject = obj;
            };
            control.BringToFront();
            panel1.Controls.Add(control);
            Point clientPos = control.Parent.PointToClient(Cursor.Position);
            control.Location = clientPos;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.All; //

        }

        private void uiNavMenu1_MouseUp(object sender, MouseEventArgs e)
        {
            m_mouseDown = false;
        }

        private void uiNavMenu1_MouseLeave(object sender, EventArgs e)
        {
            m_mouseDown = false;
        }

        private void btnMiddleDist_Click(object sender, EventArgs e)
        {
            List<Control> listControl = GetSelectControls(false);
            listControl = listControl.OrderBy(x => x.Location.Y).ToList();
            Control maxCon = listControl.Last();
            Control minCon = listControl.First();
            listControl.Remove(minCon);
            listControl.Remove(maxCon);
            int minY = minCon.Location.Y + minCon.Height;
            int maxY = maxCon.Location.Y;
            int dist = maxY - minY - listControl.Sum(x => x.Size.Height);
            int single = dist / (listControl.Count + 1);
            int lastHeigh = minY;
            foreach (Control control in listControl)
            {
                control.Location = new Point(control.Location.X, minY + single);
                minY = control.Location.Y + control.Height;
            }

        }
        private List<Control> GetSelectControls(bool isGetFrame = true)
        {
            List<Control> list = new List<Control>();
            foreach (Control control in panel1.Controls)
            {
                if (!control.Visible) continue;

                if (control is FrameControl frameControl)
                {
                    if (isGetFrame)
                        list.Add(frameControl);
                    list.Add(frameControl.control);
                }
            }
            return list;
        }

        private void btnHorSort_Click(object sender, EventArgs e)
        {
            List<Control> listControl = GetSelectControls(false);
            if (listControl.Count < 1) return;
            listControl = listControl.OrderBy(x => x.Location.X).ToList();
            Control maxCon = listControl.Last();
            Control minCon = listControl.First();

            listControl.Remove(minCon);
            listControl.Remove(maxCon);
            int minX = minCon.Location.X + minCon.Width;
            int maxX = maxCon.Location.X;
            int dist = maxX - minX - listControl.Sum(x => x.Size.Width);
            int single = dist / (listControl.Count + 1);
            int lastWidth = minX;
            foreach (Control control in listControl)
            {
                control.Location = new Point(minX + single, control.Location.Y);
                minX = control.Location.X + control.Width;
            }

        }
    }

}
