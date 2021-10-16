using System;
using System.Threading.Tasks;

namespace AsyncExamples
{
    public class AsyncProgressCountExample
    {
        private readonly SimulatedFile File = new SimulatedFile();
        private FileCopyProgress<int> Progress = new FileCopyProgress<int>();
        public async Task Go()
        {
            var files = SampleFiles.EnumerateFiles();
            Console.WriteLine("Starting Copy File Operation: Cancellation Unsupported");
            await File.Copy(files, Progress, default);
            Console.WriteLine("Done");
        }

        private class FileCopyProgress<T> : IProgress<int>
        {
            public void Report(int value)
            {
                Console.WriteLine($"Copied {value} file(s)");
            }
        }
    }
}
