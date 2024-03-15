using System;
using System.Collections.Generic;
using PerfectEmulator.Bundle.EmulatorBundle.Finder;

namespace PerfectEmulator.Bundle.EmulatorBundle.Provider
{
    public class WindowProvider
    {
        private readonly WindowFinder _windowFinder;

        public WindowProvider(WindowFinder windowFinder)
        {
            _windowFinder = windowFinder;
        }
        
        public List<IntPtr> FindByTitle(string title)
        {
            var cachedWindowHandles = new List<IntPtr>();
    
            cachedWindowHandles.AddRange(_windowFinder.FindWindowsWithSameTitle(title));

            return cachedWindowHandles;
        }
    }
}