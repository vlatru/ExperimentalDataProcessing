using System;
using System.Drawing;
using System.Windows.Forms;

namespace WaveProcessing
{
    public class ResizeableControl
    {
        Control resizableControl;
        Control givenControl
        {
            get { return resizableControl; }
            set
            {
                resizableControl = value;
                if (resizableControl != null)
                {
                    resizableControl.MouseDown += mControl_MouseDown;
                    resizableControl.MouseUp += mControl_MouseUp;
                    resizableControl.MouseMove += mControl_MouseMove;
                    resizableControl.MouseLeave += mControl_MouseLeave;
                }
            }
        }
        bool mouseDown = false;
        EdgeEnum mEdge = EdgeEnum.None;
        int borderWidth = 5;
        enum EdgeEnum
        { None, Right, Left, Top, Bottom, LeftTop, RightTop, LeftBottom, RightBottom, MoveArea }

        public ResizeableControl(Control ctrl)
        { givenControl = ctrl; }

        void mControl_MouseDown(object sender, MouseEventArgs e)
        { if (e.Button == MouseButtons.Left) mouseDown = true; }
        void mControl_MouseUp(object sender, MouseEventArgs e)
        { mouseDown = false; }
        void mControl_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            
            if (mouseDown & mEdge != EdgeEnum.None)
            {
                int minSZ = 5 * borderWidth;
                ctrl.SuspendLayout();
                int l = 0, t = 0, w = 0, h = 0;
                switch (mEdge)
                {
                    case EdgeEnum.Left:
                        l = ctrl.Left + e.X; t = ctrl.Top; w = ctrl.Width - e.X; h = ctrl.Height; break;
                    case EdgeEnum.Right:
                        l = ctrl.Left; t = ctrl.Top; w = e.X; h = ctrl.Height; break;
                    case EdgeEnum.Top:
                        l = ctrl.Left; t = ctrl.Top + e.Y; w = ctrl.Width; h = ctrl.Height - e.Y; break;                    
                    case EdgeEnum.Bottom:
                        l = ctrl.Left; t = ctrl.Top; w = ctrl.Width; h = e.Y; break;
                    case EdgeEnum.MoveArea:
                        l = ctrl.Left + e.X; t = ctrl.Top + e.Y; w = ctrl.Width; h = ctrl.Height; break;
                    case EdgeEnum.LeftTop:
                        l = ctrl.Left + e.X; t = ctrl.Top + e.Y; w = ctrl.Width - e.X; h = ctrl.Height - e.Y; break;
                    case EdgeEnum.RightTop:
                        l = ctrl.Left; t = ctrl.Top + e.Y; w = e.X; h = ctrl.Height - e.Y; break;
                    case EdgeEnum.LeftBottom:
                        l = ctrl.Left + e.X; t = ctrl.Top; w = ctrl.Width - e.X; h = e.Y; break;
                    case EdgeEnum.RightBottom:
                        l = ctrl.Left; t = ctrl.Top; w = e.X; h = e.Y; break;
                }
                if (w <= minSZ) { w = minSZ; l = ctrl.Left; }
                if (h <= minSZ) { h = minSZ; t = ctrl.Top; }
                ctrl.BringToFront();
                ctrl.SetBounds(l, t, w, h);
                ctrl.ResumeLayout();
            }
            else
            {
                if (e.X <= borderWidth &&
                    e.Y > 2 * borderWidth &&
                    e.Y < ctrl.Height - borderWidth) //left edge
                {
                    ctrl.Cursor = Cursors.SizeWE;
                    mEdge = EdgeEnum.Left;
                }
                else if (e.X >= ctrl.Width - borderWidth &&
                    e.Y > borderWidth &&
                    e.Y < ctrl.Height - borderWidth) //right edge
                {
                    ctrl.Cursor = Cursors.SizeWE;
                    mEdge = EdgeEnum.Right;
                }
                else if (e.Y <= borderWidth &&
                    e.X > 2*borderWidth &&
                    e.X < ctrl.Width - borderWidth) //top edge
                {
                    ctrl.Cursor = Cursors.SizeNS;
                    mEdge = EdgeEnum.Top;
                }                    
                else if (e.Y >= ctrl.Height - borderWidth &&
                    e.X > borderWidth &&
                    e.X < ctrl.Width - borderWidth) //bottom edge
                {
                    ctrl.Cursor = Cursors.SizeNS;
                    mEdge = EdgeEnum.Bottom;
                }
                else if (e.X <= 2*borderWidth &&
                    e.Y <= 2 * borderWidth) //left top corner // move area edge
                {
                    ctrl.Cursor = Cursors.SizeAll;
                    mEdge = EdgeEnum.MoveArea;
                }
                else if (e.X >= ctrl.Width - borderWidth &&
                    e.Y <= borderWidth) //right top corner
                {
                    ctrl.Cursor = Cursors.SizeNESW;
                    mEdge = EdgeEnum.RightTop;
                }
                else if (e.X <= borderWidth &&
                    e.Y >= ctrl.Height - borderWidth) //left bottom corner
                {
                    ctrl.Cursor = Cursors.SizeNESW;
                    mEdge = EdgeEnum.LeftBottom;
                }
                else if (e.X >= ctrl.Width - borderWidth &&
                    e.Y >= ctrl.Height - borderWidth) //right bottom corner
                {
                    ctrl.Cursor = Cursors.SizeNWSE;
                    mEdge = EdgeEnum.RightBottom;
                }
                else //no edge
                {
                    ctrl.Cursor = Cursors.Default;
                    mEdge = EdgeEnum.None;
                }
            }
        }
        void mControl_MouseLeave(object sender, EventArgs e)
        { ((Control)sender).Refresh(); }
    }
}

