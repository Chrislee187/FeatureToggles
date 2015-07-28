using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatureToggles;
using TestAppLib;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FeatureToggles at .config file level");

            for (int i = 1; i <=5 ; i++)
            {
                Console.WriteLine($"'MyFeature{i}' = {Features.State($"MyFeature{i}")}");
            }

            Console.WriteLine("FeatureToggle context maintained through child components");
            var x = new TestAppLibClass();
            x.DeadEnd();
            x.GoDeeper();

            Console.ReadLine();
        }
    }
}
