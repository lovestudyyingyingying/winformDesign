using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.MoveControl.Demo
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ResizableControlHelper
    {
        private Control targetControl;
        private bool resizing = false;
        private Point lastMousePosition;
        private int resizeBorderSize = 10; // 边框检测范围
        private ResizeDirection resizeDirection = ResizeDirection.None;

        public ResizableControlHelper(Control control, int borderSize = 10)
        {
            targetControl = control;
            resizeBorderSize = borderSize;

            targetControl.MouseDown += TargetControl_MouseDown;
            targetControl.MouseMove += TargetControl_MouseMove;
            targetControl.MouseUp += TargetControl_MouseUp;
        }

        private void TargetControl_MouseDown(object sender, MouseEventArgs e)
        {
            resizeDirection = GetResizeDirection(e.Location);
            if (resizeDirection != ResizeDirection.None)
            {
                resizing = true;
                lastMousePosition = e.Location;
            }
        }

        private void TargetControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (resizing)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;

                if (resizeDirection.HasFlag(ResizeDirection.Right))
                    targetControl.Width = Math.Max(50, targetControl.Width + deltaX);
                if (resizeDirection.HasFlag(ResizeDirection.Bottom))
                    targetControl.Height = Math.Max(50, targetControl.Height + deltaY);
                if (resizeDirection.HasFlag(ResizeDirection.Left))
                {
                    int newWidth = Math.Max(50, targetControl.Width - deltaX);
                    targetControl.Left += targetControl.Width - newWidth;
                    targetControl.Width = newWidth;
                }
                if (resizeDirection.HasFlag(ResizeDirection.Top))
                {
                    int newHeight = Math.Max(50, targetControl.Height - deltaY);
                    targetControl.Top += targetControl.Height - newHeight;
                    targetControl.Height = newHeight;
                }

                lastMousePosition = e.Location;
            }
            else
            {
                targetControl.Cursor = GetCursorShape(e.Location);
            }
        }

        private void TargetControl_MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
            resizeDirection = ResizeDirection.None;
        }

        private ResizeDirection GetResizeDirection(Point mouseLocation)
        {
            bool left = mouseLocation.X <= resizeBorderSize;
            bool right = mouseLocation.X >= targetControl.Width - resizeBorderSize;
            bool top = mouseLocation.Y <= resizeBorderSize;
            bool bottom = mouseLocation.Y >= targetControl.Height - resizeBorderSize;

            if (left && top) return ResizeDirection.TopLeft;
            if (right && top) return ResizeDirection.TopRight;
            if (left && bottom) return ResizeDirection.BottomLeft;
            if (right && bottom) return ResizeDirection.BottomRight;
            if (left) return ResizeDirection.Left;
            if (right) return ResizeDirection.Right;
            if (top) return ResizeDirection.Top;
            if (bottom) return ResizeDirection.Bottom;

            return ResizeDirection.None;
        }

        private Cursor GetCursorShape(Point mouseLocation)
        {
            switch (GetResizeDirection(mouseLocation))
            {
                case ResizeDirection.TopLeft:
                case ResizeDirection.BottomRight:
                    return Cursors.SizeNWSE;
                case ResizeDirection.TopRight:
                case ResizeDirection.BottomLeft:
                    return Cursors.SizeNESW;
                case ResizeDirection.Left:
                case ResizeDirection.Right:
                    return Cursors.SizeWE;
                case ResizeDirection.Top:
                case ResizeDirection.Bottom:
                    return Cursors.SizeNS;
                default:
                    return Cursors.Default;
            }
        }

        [Flags]
        private enum ResizeDirection
        {
            None = 0,
            Left = 1,
            Right = 2,
            Top = 4,
            Bottom = 8,
            TopLeft = Top | Left,
            TopRight = Top | Right,
            BottomLeft = Bottom | Left,
            BottomRight = Bottom | Right
        }
    }

}
