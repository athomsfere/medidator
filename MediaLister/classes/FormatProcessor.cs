using MediaLister.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    internal class FormatProcessor
    {
        private static Dictionary<int, Format> formatLengths = new Dictionary<int, Format>()
        {
            { 720, Format.DVD},
            { 1920, Format.Bluray },
            { 3840, Format.UHD }
        };

        internal static Format GetGuessedFormat(List<ffStream> ffProbeFormat)
        {
            ffProbeFormat.OrderBy(o => o.height);
            string xLength = ffProbeFormat[0].width.ToString();

            var hasWidth = int.TryParse(xLength, out int width);
            if (hasWidth)
            {
                if (formatLengths.ContainsKey(width))
                {
                    return formatLengths[width];
                }
                else
                {
                    return Format.UNKNOWN;
                }
            }

            return Format.UNKNOWN;
        }
    }
}
