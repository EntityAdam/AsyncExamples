using System;

namespace AsyncExamples
{

    public partial class AsyncProgressPercentageExample
    {
        public class FileCopyPercentage
        {
            public FileCopyPercentage(int copied, int total)
            {
                if (total == 0) throw new ArgumentOutOfRangeException(nameof(total));
                Copied = copied;
                Total = total;
            }
            public int Total { get; private set; }
            public int Copied { get; private set; }

            public string CalculatePercentage() => $"{(Copied / (double)Total) * 100}%";
        }
    }
}
