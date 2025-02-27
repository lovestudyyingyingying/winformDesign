using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinForm.MoveControl
{

    public static class ControlExtensions
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        static bool IsCtrlPressed()
        {
            return (GetAsyncKeyState(0xA2) & 0x8000) != 0 || (GetAsyncKeyState(0xA3) & 0x8000) != 0;
        }
        public static Dictionary<string, MouseEventHandler> EventList = new Dictionary<string, MouseEventHandler>();
        public static FrameControl FirstClickControl = null;
        /// <summary>
        /// 设置控件移动和调整大小
        /// </summary>
        public static void SetMove(this Control control)
        {
            if (control is FrameControl)
                return;
            // control.Enabled = false;
            //边框控件
            FrameControl fControl = null;
            //上一个鼠标坐标
            Point lastPoint = new Point();

            #region 绑定事件

            //鼠标键按下时
            MouseEventHandler mouseDown = (sender, e) =>
            {
                //记录鼠标坐标
                lastPoint = Cursor.Position;
                bool isAnyVisible = false;//是否全部可见
                //清除所有控件的边框区域，最主要的是清除上次点击控件的边框，恢复原来状态
                foreach (Control ctrl in control.Parent.Controls)
                {
                    if (ctrl is FrameControl)
                    {
                        if (!IsCtrlPressed())
                            ctrl.Visible = false;
                        if (ctrl.Visible)
                            isAnyVisible = true;
                    }

                }
                if (!isAnyVisible)
                    FirstClickControl = fControl;
                if (fControl == null)
                    fControl = new FrameControl(control);
                //设置边框背景色为透明，可以设置其它颜色
                fControl.BackColor = Color.Transparent;
                //把边框控件添加到当前控件的父控件中
                control.Parent.Controls.Add(fControl);
            };
            EventList.Add(control.Name + "MouseDown", mouseDown);

            control.MouseDown += EventList[control.Name + "MouseDown"];



            //鼠标单击时
            MouseEventHandler mouseClick = (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    control.BringToFront();
                }
            };
            EventList.Add(control.Name + "MouseClick", mouseClick);

            control.MouseClick += mouseClick;


            //鼠标在控件上移动时
            MouseEventHandler mouseMove = (sender, e) =>
               {
                   Point currentPoint = new Point();
                   Cursor.Current = Cursors.SizeAll;
                   if (e.Button == MouseButtons.Left)
                   {
                       currentPoint = Cursor.Position;
                       control.Location = new Point(control.Location.X + currentPoint.X - lastPoint.X,
                           control.Location.Y + currentPoint.Y - lastPoint.Y);

                       //移动时刷新实线
                       fControl.DrawSolids();

                       control.BringToFront();
                   }

                   lastPoint = currentPoint;
               };
            EventList.Add(control.Name + "MouseMove", mouseMove);

            control.MouseMove += mouseMove;

            //鼠标键释放时
            MouseEventHandler mouseUp = (sender, e) =>
            {
                //设置控件区域
                fControl.SetControlRegion();
            };
            EventList.Add(control.Name + "MouseUp", mouseUp);

            control.MouseUp += mouseUp;
            #endregion
        }

        /// <summary>
        /// 禁用控件移动和调整大小
        /// </summary>
        public static void DisMove(this Control control)
        {
            if (control is FrameControl) return;
            if (string.IsNullOrEmpty(control.Name)) return;
            List<string> list = new List<string>();
            foreach (var dic in EventList)
            {
                if (dic.Key.Contains(control.Name))
                {
                    if (dic.Key.Contains("MouseDown"))
                    {
                        control.MouseDown -= dic.Value;
                    }
                    if (dic.Key.Contains("MouseUp"))
                    {
                        control.MouseUp -= dic.Value;
                    }
                    if (dic.Key.Contains("MouseClick"))
                    {
                        control.MouseClick -= dic.Value;
                    }
                    if (dic.Key.Contains("MouseMove"))
                    {
                        control.MouseMove -= dic.Value;
                    }
                    list.Add(dic.Key);
                }
            }
            foreach (var dic in list)
            {
                EventList.Remove(dic);
            }
            //清除所有控件的边框区域，最主要的是清除上次点击控件的边框，恢复原来状态
            foreach (Control ctrl in control.Parent.Controls)
                if (ctrl is FrameControl)
                    ctrl.Visible = false;

        }
    }
}
