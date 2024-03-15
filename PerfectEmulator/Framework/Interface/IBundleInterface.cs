using SimpleInjector;

namespace PerfectEmulator.Framework.Interface
{
    public interface IBundleInterface
    { 
        void Register(Container container);

        void Run(Container container);
    }
}