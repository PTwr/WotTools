﻿using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotTools
{
    public static class WotMod
    {
        public static bool TryCreateWotMod(string targetPath, string rootDirectory)
        {
            using (var zip = ICSharpCode.SharpZipLib.Zip.ZipFile.Create(targetPath))
            {                
                var root = new DirectoryInfo(rootDirectory);
                rootDirectory = root.FullName;

                zip.BeginUpdate();

                zip.AddDirectory("res");
                zip.AddDirectory($"res/{root.Name}");
                
                TraverseDirectory(root,
                    i =>
                    {
                        var relativePath = $"res/{root.Name}/{MakeRelativePath(rootDirectory, i.FullName)}";
                        zip.AddDirectory(relativePath);
                    },
                    i =>
                    {
                        var relativePath = $"res/{root.Name}/{MakeRelativePath(rootDirectory, i.FullName)}";

                        var dataSource = new ICSharpCode.SharpZipLib.Zip.StaticDiskDataSource(i.FullName);
                        zip.Add(dataSource, relativePath, CompressionMethod.Stored);
                    });

                zip.CommitUpdate();
            }

            //using (ZipFile z = ZipFile.Create(targetPath))
            {
                //z.BeginUpdate();
                //TraverseDirectory(new DirectoryInfo(rootDirectory),
                //    i =>
                //    {

                //    },
                //    i =>
                //    {
                //        var relativePath = "res/" + MakeRelativePath(rootDirectory, i.FullName);
                //        //var zipEntry = new ZipEntry(relativePath);
                //        z.Add(relativePath, i.FullName, CompressionMethod.Stored);
                //    });
                //z.CommitUpdate();

                //foreach (var filePath in filePaths)
                //{
                //    z.BeginUpdate();

                //    var filename = "res/" + filePath;

                //    //var dirs = filename.Split('/').Reverse().Skip(1).Reverse();
                //    //var path = "";
                //    //foreach (var dir in dirs)
                //    //{
                //    //    path = path + dir + "/";

                //    //    z.AddDirectory(path);
                //    //}

                //    var zipEntry = new ZipEntry(filename);

                //    z.Add(filename, CompressionMethod.Stored);
                //    //var entry = z.GetEntry("list.xml");
                //    //entry.CompressionMethod = CompressionMethod.Stored;
                //    //z.GetEntry(filename).CompressionMethod = CompressionMethod.Stored;

                //    z.CommitUpdate();
                //}
            }

            return true;
        }

        public static void TraverseDirectory(DirectoryInfo rootdirectory, Action<DirectoryInfo> forDirectory, Action<FileInfo> forFile)
        {
            foreach (var file in rootdirectory.EnumerateFiles())
            {
                forFile(file);
            }
            foreach (var dir in rootdirectory.EnumerateDirectories())
            {
                forDirectory(dir);
                TraverseDirectory(dir, forDirectory, forFile);
            }
        }

        /// <summary>
        /// Creates a relative path from one file or folder to another.
        /// </summary>
        /// <param name="fromPath">Contains the directory that defines the start of the relative path.</param>
        /// <param name="toPath">Contains the path that defines the endpoint of the relative path.</param>
        /// <returns>The relative path from the start directory to the end path or <c>toPath</c> if the paths are not related.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UriFormatException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static String MakeRelativePath(String fromPath, String toPath)
        {
            if (String.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
            if (String.IsNullOrEmpty(toPath)) throw new ArgumentNullException("toPath");

            fromPath = fromPath.EndsWith("\\") ? fromPath : fromPath + '\\';

            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            if (fromUri.Scheme != toUri.Scheme) { return toPath; } // path can't be made relative.

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase))
            {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath.Replace('\\', '/');
        }
    }
}
