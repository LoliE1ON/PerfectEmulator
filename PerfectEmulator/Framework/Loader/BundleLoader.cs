using System.Collections.Generic;
using PerfectEmulator.Framework.Interface;
using SimpleInjector;

namespace PerfectEmulator.Framework.Loader
{
    public class BundleLoader
    {
        public void Load(IEnumerable<IBundleInterface> bundles, Container container)
        {
            foreach (var bundle in bundles)
            {
                bundle.Register(container);
            }
        }
    }
}