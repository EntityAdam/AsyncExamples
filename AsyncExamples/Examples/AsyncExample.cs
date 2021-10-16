using System;
using System.Threading.Tasks;

namespace AsyncExamples
{
    public class AsyncExample
    {
        private readonly SimulatedFile File = new SimulatedFile();

        public async Task Go()
        {
            var files = SampleFiles.EnumerateFiles();
            Console.WriteLine("Starting Copy File Operation: Cancellation Unsupported");
            await File.Copy(files);
            Console.WriteLine("Done");
        }
    }
}
