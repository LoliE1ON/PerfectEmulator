using System.Runtime.InteropServices;

namespace PerfectEmulator.Bundle.EmulatorBundle.Interceptor
{
    public class KeyboardInterceptor
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public bool IsHotkeyPressed(int virtualKeyCode)
        {
            return GetAsyncKeyState(virtualKeyCode) < 0;
        }
    }
}