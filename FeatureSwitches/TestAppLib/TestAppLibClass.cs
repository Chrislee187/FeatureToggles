using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLib
{
    public class TestAppLibClass
    {
        public void DeadEnd()
        {
            bool val;
            AppContext.TryGetSwitch("MyFeature1", out val);
            Console.WriteLine($"DeadEnd::MyFeature1 = {val}");
        }

        public void GoDeeper()
        {
            var x = new TestAppLibDeeper.TestAppLibDeeper();
            x.DeadEnd();
        }
    }
}
