using PerfectEmulator.Bundle.EmulatorBundle;
using PerfectEmulator.Bundle.TestBundle;
using PerfectEmulator.Framework.Interface;
using PerfectEmulator.Framework.Loader;
using PerfectEmulator.Framework.Runner;
using SimpleInjector;

namespace PerfectEmulator.Framework
{
    public class Bootstrap
    {
        private readonly Container _systemContainer = new Container();
        private readonly Container _applicationContainer = new Container();
        private readonly BundleLoader _bundleLoader = new BundleLoader();
        private readonly BundleRunner _bundleRunner = new BundleRunner();
        
        public void Register()
        {
            _applicationContainer.Register<ControllerLoader>();
            
            _systemContainer.Collection.Register<IBundleInterface>(
                typeof(EmulatorBundle),
                typeof(TestBundle)
            );
        }

        public void LoadBundles()
        {
            var bundles = _systemContainer.GetAllInstances<IBundleInterface>();
            _bundleLoader.Load(bundles, _applicationContainer);    
        }
        
        public void RunApplication()
        {
            var bundles = _systemContainer.GetAllInstances<IBundleInterface>();
            _bundleRunner.Run(bundles, _applicationContainer);
        }
    }
}