using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();

            Console.ReadKey(true);
        }

        private static void Test1()
        {
            Task.Factory.StartNew(()=>
            {
                Thread.Sleep(2000);
                Console.WriteLine("write over");
            });
            Console.WriteLine("no write");
        }
    }
}
