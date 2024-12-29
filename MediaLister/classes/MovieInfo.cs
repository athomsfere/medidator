using MediaLister.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    internal class MovieInfo
    {
        public string MovieName { get; set; }
        public string ParentFolder { get; set; }
        public Format Format { get; set; } 
        public string FileSizeGB { get; set; }
        public string Duration { get; set; }    
        public string Codecs {  get; set; }
        public string Resolution { get; set; }

    }
}
