using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PerfectEmulator.Bundle.EmulatorBundle.Finder
{
    public class WindowFinder
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public IntPtr[] FindWindowsWithSameTitle(string title)
        {
            Console.WriteLine("Registering windows...");
            var windows = new List<IntPtr>();
            IntPtr hWnd = IntPtr.Zero;
            while ((hWnd = FindWindowEx(IntPtr.Zero, hWnd, null, null)) != IntPtr.Zero)
            {
                StringBuilder windowText = new StringBuilder(255);
                GetWindowText(hWnd, windowText, windowText.Capacity);
                if (windowText.ToString() == title)
                {
                    Console.WriteLine("Registered window: " + hWnd);
                    windows.Add(hWnd);
                }
            }
            return windows.ToArray();
        }

        public void SendKeyToWindow(IntPtr hWnd, ConsoleKey key)
        {
            SetForegroundWindow(hWnd);
            PostMessage(hWnd, WM_KEYDOWN, (IntPtr)key, IntPtr.Zero);
            PostMessage(hWnd, WM_KEYUP, (IntPtr)key, IntPtr.Zero);
        }
    }
}