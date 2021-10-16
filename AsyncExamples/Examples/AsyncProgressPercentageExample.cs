using System;
using System.Threading.Tasks;

namespace AsyncExamples
{
    public partial class AsyncProgressPercentageExample
    {
        private readonly SimulatedFile File = new SimulatedFile();
        private FileCopyProgress<FileCopyPercentage> Progress = new FileCopyProgress<FileCopyPercentage>();
        public async Task Go()
        {
            var files = SampleFiles.EnumerateFiles();
            Console.WriteLine("Starting Copy File Operation: Cancellation Unsupported");
            await File.Copy(files, Progress, default);
            Console.WriteLine("Done");
        }

        private class FileCopyProgress<T> : IProgress<FileCopyPercentage>
        {
            public void Report(FileCopyPercentage value)
            {
                Console.WriteLine($"{value.CalculatePercentage()} Complete");
            }
        }
    }
}
