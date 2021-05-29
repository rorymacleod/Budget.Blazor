using Cake.Common.IO;
using Cake.Core;
using Cake.Core.IO;
using System.Collections.Generic;
using System.IO;

namespace Budget.Build.Extensions
{
    internal static class DirectoryExtensions
    {
        /// <summary>
        /// Enumerates over the parents of the given starting directory until the root is reached.
        /// </summary>
        public static IEnumerable<DirectoryPath> GetParentDirectories(this ICakeContext context, DirectoryPath start)
        {
            var dir = start.MakeAbsolute(context.Environment);
            yield return dir;

            while (context.TryGetParentDirectory(dir, out var parentDir))
            {
                yield return parentDir;
                dir = parentDir;
            }
        }

        /// <summary>
        /// Attempts to return the parent of the given directory, unless the directory is the root.
        /// </summary>
        public static bool TryGetParentDirectory(this ICakeContext context, DirectoryPath directory, out DirectoryPath parent)
        {
            var info = Directory.GetParent(directory.FullPath);
            if (info == null)
            {
                parent = null;
            }
            else
            {
                parent = context.Directory(info.FullName);
            }

            return parent != null;
        }
    }
}
