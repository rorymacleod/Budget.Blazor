using Cake.Common.Tools.NuGet;
using Cake.Common.Tools.NuGet.Restore;
using Cake.Frosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Build.Tasks
{
    [TaskName("RestorePackages")]
    [IsDependentOn(typeof(FindSolutionTask))]
    public class RestorePackagesTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.NuGetRestore(context.SolutionPath, new NuGetRestoreSettings
            {
                
            });
        }
    }
}
