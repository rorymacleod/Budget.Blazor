using System;
using System.Linq;
using Budget.Build.Extensions;
using Cake.Common.Diagnostics;
using Cake.Common.IO;
using Cake.Core.IO;
using Cake.Frosting;

namespace Budget.Build.Tasks
{
    [TaskName("FindSolution")]
    public class FindSolutionTask: FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            foreach (var dir in context.GetParentDirectories(context.Environment.WorkingDirectory))
            {
                var files = context.Globber.Match(dir.CombineWithFilePath("*.sln").FullPath).ToList();
                if (files.Count == 0)
                {
                    continue;
                }
                else if (files.Count == 1)
                {
                    context.SolutionPath = context.File(files[0].FullPath);
                    context.SolutionDir = context.SolutionPath.GetDirectory();
                    context.SolutionName = context.SolutionPath.GetFilenameWithoutExtension().ToString();
                    context.Information($"Found solution: {context.SolutionPath}");
                    return;
                }
                else
                {
                    throw new Exception($"Found {files.Count} solutions, expected 1:\r\n- {string.Join("\r\n- ", files)}");
                }
            }

            throw new Exception("Solution file not found.");
        }
    }
}
