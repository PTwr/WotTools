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
        public static bool TryExtractFile(string packagePath, string filePath, Action<Stream> readFile, bool verbose = true)
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
                var fileEntry = zipFile.Entries.FirstOrDefault(i => i.FullName == filePath);

                if(fileEntry == null)
                {
                    return verbose ? throw new ArgumentException("Invalid file path") : false;
                }

                var stream = fileEntry.Open();

                readFile(stream);
            }

            return true;
        }
    }
}
