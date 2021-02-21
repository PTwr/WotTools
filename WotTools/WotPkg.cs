using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotTools
{
    public static class WotPkg
    {
        public static bool TryExtractFile(string packagePath, string filePath, Action<Stream> readFile, bool verbose = true, bool caseSensitive = false)
        {
            if(!File.Exists(packagePath))
            {
                return verbose ? throw new FileNotFoundException("Package file not found") : false;
            }

            if(string.IsNullOrWhiteSpace(filePath))
            {
                return verbose ? throw new ArgumentNullException("File path is requried") : false;
            }

            using (var zipFile = System.IO.Compression.ZipFile.Open(packagePath, System.IO.Compression.ZipArchiveMode.Read))
            {
                var fileEntry = caseSensitive ?
                    zipFile.Entries.FirstOrDefault(i => i.FullName == filePath)
                    :
                    zipFile.Entries.FirstOrDefault(i => string.Equals(i.FullName, filePath, StringComparison.InvariantCultureIgnoreCase))
                    ;

                if(fileEntry == null)
                {
                    return verbose ? throw new ArgumentException("Invalid file path") : false;
                }

                var stream = fileEntry.Open();

                readFile(stream);
            }

            return true;
        }

        public static bool TryExtractDirectory(string packagePath, string directoryPath, Action<Stream, System.IO.Compression.ZipArchiveEntry> readFile, bool verbose = true, bool caseSensitive = false)
        {
            if (!File.Exists(packagePath))
            {
                return verbose ? throw new FileNotFoundException("Package file not found") : false;
            }

            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                return verbose ? throw new ArgumentNullException("Directory path is requried") : false;
            }

            using (var zipFile = System.IO.Compression.ZipFile.Open(packagePath, System.IO.Compression.ZipArchiveMode.Read))
            {
                var fileEntries = caseSensitive ?
                    zipFile.Entries.Where(i => i.FullName.StartsWith(directoryPath))
                    :
                    zipFile.Entries.Where(i => i.FullName.StartsWith(directoryPath, StringComparison.InvariantCultureIgnoreCase))
                    ;

                if (!fileEntries.Any())
                {
                    return verbose ? throw new ArgumentException("Invalid directory path, or directory is empty") : false;
                }

                foreach (var fileEntry in fileEntries)
                {                    
                    var stream = fileEntry.Open();
                    readFile(stream, fileEntry);
                }
            }

            return true;
        }
    }
}
