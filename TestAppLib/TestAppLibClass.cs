using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatureToggles;

namespace TestAppLib
{
    public class TestAppLibClass
    {
        public void DeadEnd()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"'MyFeature{i}' = {Features.State($"MyFeature{i}")}");
            }
        }

        public void GoDeeper()
        {
            var x = new TestAppLibDeeper.TestAppLibDeeper();
            x.DeadEnd();
        }
    }
}
