using System;
using System.Threading;
using PerfectEmulator.Bundle.EmulatorBundle.Config;
using PerfectEmulator.Bundle.EmulatorBundle.Finder;
using PerfectEmulator.Bundle.EmulatorBundle.Interceptor;
using PerfectEmulator.Bundle.EmulatorBundle.Provider;

namespace PerfectEmulator.Bundle.EmulatorBundle.Controller
{
    public class EmulatorController: Framework.Controller
    {
        private readonly KeyboardInterceptor _interceptor;
        private readonly WindowProvider _windowProvider;
        private readonly WindowFinder _windowFinder;
        
        public EmulatorController(KeyboardInterceptor interceptor, WindowProvider windowProvider, WindowFinder windowFinder)
        {
            _interceptor = interceptor;
            _windowProvider = windowProvider;
            _windowFinder = windowFinder;
        }

        public override void Action()
        {
            var windows = _windowProvider.FindByTitle(Window.Title);

            if (windows.Count == 0)
            {
                Console.WriteLine("[WARNING] No windows found with the title: " + Window.Title);
            }

            Console.WriteLine(">>> Press 'X' to trigger the custom hotkey.");

            while (true)
            {
                if (_interceptor.IsHotkeyPressed(Key.X))
                {
                    foreach (var window in windows)
                    {
                        _windowFinder.SendKeyToWindow(window, Key.F12);

                        DateTime currentTime = DateTime.Now;
                        string formattedTime = currentTime.ToString("HH:mm:ss");

                        Console.WriteLine("[OK][" + formattedTime + "] Sent to " + window);

                        Thread.Sleep(Performance.ThreadSleep);
                    }
                }
                
                Thread.Sleep(Performance.ThreadSleep); // Avoid CPU overload
            }
        }
    }
}