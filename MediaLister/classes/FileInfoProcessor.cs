using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace MediaLister.classes
{
    internal static class FileInfoProcessor
    {
        internal static string GetGBFileSize(long fileSize)
        {
            int counter = 0;
            decimal rawSize = fileSize;
            while (Math.Round(rawSize / 1024) >= 1)
            {
                rawSize = rawSize / 1024;
                counter++;
            }

            return $"{Math.Round(rawSize, 2)} GB";
            //return string.Format("{0:n1}{1}", Math.Round(rawSize, 2), "GB");
        }


    }
    
}
