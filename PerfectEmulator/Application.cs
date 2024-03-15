using System;

namespace PerfectEmulator
{
    internal class Application
    {
        private static void Main(string[] args)
        {
            var bootstrap = new PerfectEmulator.Framework.Bootstrap();

            bootstrap.Register();
            bootstrap.LoadBundles();
            bootstrap.RunApplication();
            
            Console.ReadLine();
        }
    }
}