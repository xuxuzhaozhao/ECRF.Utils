using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECRF.BatchExecuteTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "正在批量拉取免费单，请稍后";
            BatchExecuteTask.BatchPullInspection.Execute();
            Console.ReadLine();
        }
    }
}
