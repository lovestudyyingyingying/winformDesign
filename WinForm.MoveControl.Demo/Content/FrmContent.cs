using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WinForm.MoveControl.Demo.Content
{
    public partial class FrmContent : DockContent
    {
        public FrmContent()
        {
            InitializeComponent();
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0], 61451);
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[0], 61640);
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[1], 61490);
            uiNavMenu1.SetNodeSymbol(uiNavMenu1.Nodes[0].Nodes[2], 61489);
            uiNavMenu1.Visible = false;
        }
        private PropertyGrid propertyGrid1;
        private Panel panel1;
        private void uiNavMenu1_DoubleClick(object sender, EventArgs e)
        {
            var node = uiNavMenu1.SelectedNode;
            Control control = null;
            //if (node.Text == "button")
            //{
            //    control = new Button();
            //    control.Name = "button" + DateTime.Now.ToFileTimeUtc();
            //}
            //else if (node.Text == "label")
            //{
            //    control = new System.Windows.Forms.Label();
            //    control.Name = "label" + DateTime.Now.ToFileTimeUtc();
            //}
            //else if (node.Text == "number")
            //{
            //    control = new System.Windows.Forms.NumericUpDown();
            //    control.Name = "number" + DateTime.Now.ToFileTimeUtc();
            //}
            string typeStr = node.Text;
            string controlName = "Sunny.UI." + typeStr;
            Assembly winFormsAssembly = typeof(UIButton).Assembly;
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
        bool m_mouseDown = false;

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
        private void uiNavMenu1_MouseDown(object sender, MouseEventArgs e)
        {
            //if(uiNavMenu1.SelectedNode!=null)
            //this.DoDragDrop(uiNavMenu1.SelectedNode.Text, DragDropEffects.Move);
            //base.OnMouseDown(e);
            m_mouseDown = true;
        }
        private void uiNavMenu1_MouseUp(object sender, MouseEventArgs e)
        {
            m_mouseDown = false;
        }

        private void uiNavMenu1_MouseLeave(object sender, EventArgs e)
        {
            m_mouseDown = false;
        }

    }
}
