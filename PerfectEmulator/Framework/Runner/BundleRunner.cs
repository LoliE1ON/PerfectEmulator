using System.Collections.Generic;
using PerfectEmulator.Framework.Interface;
using SimpleInjector;

namespace PerfectEmulator.Framework.Runner
{
    public class BundleRunner
    {
        public void Run(IEnumerable<IBundleInterface> bundles, Container container)
        {
            foreach (var bundle in bundles)
            {
                bundle.Run(container);
            }
        }
    }
}