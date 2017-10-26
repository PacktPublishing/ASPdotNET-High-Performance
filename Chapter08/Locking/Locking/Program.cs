using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Locking
{
    public class Program
    {

        private static object l = new object();

        public static void Main(string[] args)
        {
            var result = 0;
            Console.WriteLine(result);

            var sw = Stopwatch.StartNew();

            var t1 = Task.Run(() => { DoWork(ref result); });
            var t2 = Task.Run(() => { DoWork(ref result); });
            Task.WaitAll(t1, t2);

            sw.Stop();

            Console.WriteLine(result);
            Console.WriteLine($"{sw.ElapsedMilliseconds}ms");

            Console.ReadKey(true);
        }

        private static void DoWork(ref int result)
        {
            lock (l)
            {
                for (int i = 0; i < 1000000; i++)
                {
                    result++;
                }
            }
        }
    }
}
