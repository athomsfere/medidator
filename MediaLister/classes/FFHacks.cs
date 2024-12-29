using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace medidator.classes
{
    internal class FFHacks
    {
        private async void unzip(string file)
        {
            string extractedPath = FFLocator.getFFPaths() + "\\ff";
            string zipPath = extractedPath + $@"\{file}";
                
            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractedPath);
        }
        internal void unzipProbe()
        {
            unzip("ffprobe.zip");
        }

        internal void unzipMpeg()
        {
            unzip("ffmpeg.zip");
        }
    }

    internal static class FFLocator
    { 
        internal static string getFFPaths()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        }
        internal static bool hasProbe()
        {
            var executablePath = getFFPaths();

            return File.Exists(@$"{executablePath}\ff\ffprobe.exe");
        }
    }
}


