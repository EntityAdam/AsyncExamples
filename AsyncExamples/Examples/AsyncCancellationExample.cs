using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExamples
{
    public class AsyncCancellationExample
    {
        private readonly SimulatedFile File = new SimulatedFile();
        private readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        public async Task Go()
        {
            Console.CancelKeyPress += (source, args) =>
            {
                Console.Error.WriteLine("Cancelling");
                args.Cancel = true;
                CancellationTokenSource.Cancel();
            };

            try
            {
                Console.WriteLine("Starting Copy File Operation: Cancellation Supported");
                var files = SampleFiles.EnumerateFiles();
                await File.Copy(files, CancellationTokenSource.Token);
            }
            catch (OperationCanceledException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Console.WriteLine("Done");
        }
    }
}
