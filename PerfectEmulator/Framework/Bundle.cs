using System.Collections.Generic;
using PerfectEmulator.Framework.Interface;
using PerfectEmulator.Framework.Loader;
using SimpleInjector;

namespace PerfectEmulator.Framework
{
    public abstract class Bundle: IBundleInterface
    {
        public abstract void Register(Container container);

        public void Run(Container container)
        {
            var controllerLoader = container.GetInstance<ControllerLoader>();
            var controllers = container.GetAllInstances<IControllerInterface>();
            
            controllerLoader.Load(controllers);
        }
    }
}