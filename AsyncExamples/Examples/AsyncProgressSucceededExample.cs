using System;
using System.Threading.Tasks;

namespace AsyncExamples
{
    public class AsyncProgressSucceededExample
    {
        private readonly SimulatedFile File = new SimulatedFile();
        private FileCopyProgress<bool> Progress = new FileCopyProgress<bool>();
        public async Task Go()
        {
            var files = SampleFiles.EnumerateFiles();
            Console.WriteLine("Starting Copy File Operation: Cancellation Unsupported");
            await File.Copy(files, Progress, default);
        }

        private class FileCopyProgress<T> : IProgress<bool>
        {
            public void Report(bool value)
            {
                Console.WriteLine("Copy Operation Successful!");
            }
        }
    }
}
