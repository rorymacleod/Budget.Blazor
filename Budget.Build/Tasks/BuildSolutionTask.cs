using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Build;
using Cake.Frosting;

namespace Budget.Build.Tasks
{
    [TaskName("BuildSolution")]
    [TaskDescription("Builds the solution with 'dotnet build'")]
    [IsDependentOn(typeof(FindSolutionTask))]
    [IsDependentOn(typeof(RestorePackagesTask))]
    public class BuildSolutionTask: FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.DotNetCoreBuild(context.SolutionPath.FullPath, new DotNetCoreBuildSettings
            {
                Configuration = context.BuildConfiguration,
                NoRestore = true
            });
        }
    }
}
