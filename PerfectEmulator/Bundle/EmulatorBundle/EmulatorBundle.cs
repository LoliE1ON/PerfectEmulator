using PerfectEmulator.Bundle.EmulatorBundle.Controller;
using PerfectEmulator.Bundle.EmulatorBundle.Finder;
using PerfectEmulator.Bundle.EmulatorBundle.Interceptor;
using PerfectEmulator.Bundle.EmulatorBundle.Provider;
using PerfectEmulator.Framework.Interface;
using SimpleInjector;

namespace PerfectEmulator.Bundle.EmulatorBundle
{
    public class EmulatorBundle: Framework.Bundle
    {
        public override void Register(Container container)
        {
            container.Collection.Register<IControllerInterface>(
                typeof(EmulatorController)
            );
            
            container.Register<WindowProvider>();
            container.Register<WindowFinder>();
            container.Register<KeyboardInterceptor>();
        }
    }
}