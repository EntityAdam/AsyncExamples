using System.Collections.Generic;
using System.IO;

namespace AsyncExamples
{
    public static class SampleFiles
    {
        private const string ContentRoot = @"C:\users\n00b\";

        public static IEnumerable<string> EnumerateFiles() => new List<string>()
        {
            Path.Combine(ContentRoot, "kitty.jpg"),
            Path.Combine(ContentRoot, "baby.jpg"),
            Path.Combine(ContentRoot, "pelican.jpg"),
            Path.Combine(ContentRoot, "owl.jpg"),
            Path.Combine(ContentRoot, "puppy.jpg")
        };
    }
}
