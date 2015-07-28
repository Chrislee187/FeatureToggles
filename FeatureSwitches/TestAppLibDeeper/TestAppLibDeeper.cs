using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLibDeeper
{
    public class TestAppLibDeeper
    {
        public void DeadEnd()
        {
            bool val;
            AppContext.TryGetSwitch("MyFeature1", out val);
            Console.WriteLine($"MyFeature1 = {val}");
        }
    }
}
