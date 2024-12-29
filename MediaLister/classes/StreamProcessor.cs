using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    internal class StreamProcessor
    {
        public static string GetCodecs(List<ffStream> ffStreams)
        {
            var codecs = ffStreams.Select(s => s.codec_name).Distinct();

            return string.Join(", ", codecs);
        }
    }
}
