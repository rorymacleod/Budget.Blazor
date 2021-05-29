using Budget.Build.Tasks;
using Cake.Frosting;
using System;

public static class Program
{
    public static int Main(string[] args)
    {
        return new CakeHost()
            .UseContext<BuildContext>()
            .InstallTool(new Uri("nuget:?package=NuGet.CommandLine&version=5.9.1"))
            .Run(args);
    }
}

[TaskName("Default")]
[IsDependentOn(typeof(BuildSolutionTask))]
public class DefaultTask : FrostingTask
{
}