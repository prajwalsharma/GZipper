using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace GZipper
{
    public static class GZipHelper
    {
        public static string Compress(string sourceFilePath, string targetFilePath)
        {
            string compressedFilePath = String.Empty;

            FileInfo sourceFile = new FileInfo(sourceFilePath);

            string targetZipLocation = $"{targetFilePath}{sourceFile.Name}.gz";

            FileInfo compressedFile = new FileInfo(targetZipLocation);

            using(FileStream sourceStream = sourceFile.OpenRead())
            {
                using (FileStream targetStream = compressedFile.Create())
                {
                    using (GZipStream zipStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        try
                        {
                            sourceStream.CopyTo(zipStream);
                            compressedFilePath = compressedFile.FullName;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        
                    }
                }
            }

            return compressedFilePath;
        }

        public static string Decompress(string sourceFilePath, string targetFilePath)
        {
            string decompressedFilePath = String.Empty;

            FileInfo compressedFile = new FileInfo(sourceFilePath);

            using (FileStream sourceStream = compressedFile.OpenRead())
            {
                string decompressedFileName = targetFilePath + compressedFile.Name.Replace(".gz","");

                using (FileStream targetStream = File.Create(decompressedFileName))
                {
                    using (GZipStream zipStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        try
                        {
                            zipStream.CopyTo(targetStream);
                            decompressedFilePath = decompressedFileName;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        
                    }
                }

            }

            return decompressedFilePath;
        }
    }
}
