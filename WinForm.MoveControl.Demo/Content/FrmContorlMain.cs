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
    public partial class FrmContorlMain : DockContent
    {
        private PropertyGrid propertyGrid1;
        private ControlManager ControlHelper;
        public FrmContorlMain(ControlManager controlManager, PropertyGrid propertyGrid)
        {
            InitializeComponent();
            ControlHelper = controlManager;
            propertyGrid1 = propertyGrid;
            ControlHelper.GetContorl(panel1);
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            GlobalKeyboardHook.OnKeyDown += (sender, e) =>
            {
                if (e != Keys.Delete) return;

                List<Control> list = new List<Control>();
                foreach (Control control in panel1.Controls)
                {
                    if (!control.Visible) continue;

                    if (control is FrameControl frameControl)
                    {
                        list.Add(frameControl);
                        list.Add(frameControl.control);
                    }
                }
                foreach (Control control in list)
                {
                    panel1.Controls.Remove(control);

                }
            };


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




        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string type = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.All;                                                              //
        }


    }
}
