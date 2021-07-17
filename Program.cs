using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipper
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1. Set file paths
            string sourceFilePath = $"D:\\Programming\\.NET Standard\\GZipper\\SourceFiles\\Sample.txt";
            string compressedFileDirectory = $"D:\\Programming\\.NET Standard\\GZipper\\CompressedFiles\\";
            string decompressedFileDirectory = $"D:\\Programming\\.NET Standard\\GZipper\\DecompressedFiles\\";

            // 2. Compress File
            string compressedFilePath = GZipHelper.Compress(sourceFilePath, compressedFileDirectory);

            // 3. Decompress File
            string decompressedFileLocation = GZipHelper.Decompress(compressedFilePath, decompressedFileDirectory);
        }
    }
}
