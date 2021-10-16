using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static AsyncExamples.AsyncProgressPercentageExample;

namespace AsyncExamples
{
    public sealed class SimulatedFile
    {
        #region Part1
        public async Task Copy(IEnumerable<string> files)
        {
            await SimulateCopy(files);
        }
        public async Task Copy(IEnumerable<string> files, CancellationToken cancellationToken)
        {
            await SimulateCopy(files, cancellationToken);
        }
        private async Task SimulateCopy(IEnumerable<string> files, CancellationToken cancellationToken = default)
        {
            for (var i = 0; i < files.Count(); i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await SimulateIo();
            }
        }
        private async Task SimulateIo() => await Task.Delay(TimeSpan.FromSeconds(1));
        #endregion

        #region Part2
        public async Task Copy(IEnumerable<string> files, IProgress<bool> progress, CancellationToken cancellationToken)
        {
            try
            {
                await SimulateCopy(files, cancellationToken);
                progress.Report(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Part3
        public async Task Copy(IEnumerable<string> files, IProgress<int> progress, CancellationToken cancellationToken)
        {
            try
            {
                await SimulateCopy(files, progress, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw new OperationCanceledException("File Copy Operation Cancelled");
            }
        }

        private async Task SimulateCopy(IEnumerable<string> files, IProgress<int> progress, CancellationToken cancellationToken = default)
        {
            for (var i = 0; i < files.Count(); i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await SimulateIo();
                progress.Report(i + 1);
            }
        }
        #endregion

        #region Part4
        public async Task Copy(IEnumerable<string> files, IProgress<FileCopyPercentage> progress, CancellationToken cancellationToken)
        {
            try
            {
                await SimulateCopy(files, progress, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw new OperationCanceledException("File Copy Operation Cancelled");
            }
        }

        private async Task SimulateCopy(IEnumerable<string> files, IProgress<FileCopyPercentage> progress, CancellationToken cancellationToken = default)
        {
            for (var i = 0; i < files.Count(); i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await SimulateIo();
                progress.Report(new FileCopyPercentage(i + 1, files.Count()));
            }
        }
        #endregion
    }
}
