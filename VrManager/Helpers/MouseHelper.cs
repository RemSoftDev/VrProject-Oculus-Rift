﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VrManager.Helpers
{

    class MouseHelper
    {
        public static int X { get; set; }
        public static int Y { get; set; }
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static void SetCursorPosition()
        {
            try
            {
                SetCursorPos(X, Y);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public static void SetCursorPosition(MousePoint point)
        {
            try
            {
                SetCursorPos(point.X, point.Y);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public static MousePoint GetCursorPosition()
        {
            try
            {
                MousePoint currentMousePoint;
                var gotPoint = GetCursorPos(out currentMousePoint);
                if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
                return currentMousePoint;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return new MousePoint();
            }
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            try
            {
                MousePoint position = GetCursorPosition();

                mouse_event
                    ((int)value,
                     position.X,
                     position.Y,
                     0,
                     0)
                    ;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public static void Click()
        {
            try
            {
                MouseHelper.SetCursorPosition();
                MouseHelper.MouseEvent(MouseHelper.MouseEventFlags.LeftDown | MouseHelper.MouseEventFlags.LeftUp);
                Thread.Sleep(100);
                MouseHelper.MouseEvent(MouseHelper.MouseEventFlags.LeftDown | MouseHelper.MouseEventFlags.LeftUp);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }

        }

    }
}