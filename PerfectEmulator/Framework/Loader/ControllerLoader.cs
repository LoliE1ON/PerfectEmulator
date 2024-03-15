using System.Collections.Generic;
using PerfectEmulator.Framework.Interface;

namespace PerfectEmulator.Framework.Loader
{
    public class ControllerLoader
    {
        public void Load(IEnumerable<IControllerInterface> controllers)
        {
            foreach (var controller in controllers)
            {
                controller.Action();
            }
        }
    }
}