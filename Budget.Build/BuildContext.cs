using Cake.Common;
using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;

namespace Budget.Build
{
    public class BuildContext : FrostingContext
    {
        public string BuildConfiguration { get; set; }
        public string BuildPlatform { get; set; }
        public FilePath SolutionPath { get; set; }
        public DirectoryPath SolutionDir { get; set; }
        public string SolutionName { get; set; }

        public BuildContext(ICakeContext context)
            : base(context)
        {
            this.BuildConfiguration = context.Argument("configuration", "Release");
            this.BuildPlatform = context.Argument("platform", "Any CPU");
        }
    }
}
