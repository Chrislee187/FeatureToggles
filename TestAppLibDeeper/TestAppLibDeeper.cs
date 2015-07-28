using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatureToggles;

namespace TestAppLibDeeper
{
    public class TestAppLibDeeper
    {
        public void DeadEnd()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"'MyFeature{i}' = {Features.State($"MyFeature{i}")}");
            }
        }
    }
}
