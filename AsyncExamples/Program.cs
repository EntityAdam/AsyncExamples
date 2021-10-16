using System;
using System.Threading.Tasks;

namespace AsyncExamples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var example1 = new AsyncExample();
            await example1.Go();
            Console.WriteLine($"-----------------------------");

            var example2 = new AsyncCancellationExample();
            await example2.Go();
            Console.WriteLine($"-----------------------------");

            var example3 = new AsyncProgressSucceededExample();
            await example3.Go();
            Console.WriteLine($"-----------------------------");

            var example4 = new AsyncProgressCountExample();
            await example4.Go();
            Console.WriteLine($"-----------------------------");

            var example5 = new AsyncProgressPercentageExample();
            await example5.Go();
            Console.WriteLine($"-----------------------------");
        }
    }
}
