using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatureSwitches;
using TestAppLib;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine("AppContext switches used directly");
//            Spike();
            Console.WriteLine("AppContext switches used via Switches class");
            Spike2();

            Console.ReadLine();
        }

        private static void Spike()
        {
            AppContext.SetSwitch("MyFeature1", true);

            bool val;
            AppContext.TryGetSwitch("MyFeature1", out val);
            Console.WriteLine($"Program::MyFeature1 = {val}");
            var x = new TestAppLibClass();
            x.DeadEnd();
            x.GoDeeper();
        }

        private static void Spike2()
        {
            for (int i = 1; i <=5 ; i++)
            {
                Console.WriteLine($"Switch 'MyFeature{i}' = {Switches.State($"MyFeature{i}")}");
            }
            
        }
    }
}
