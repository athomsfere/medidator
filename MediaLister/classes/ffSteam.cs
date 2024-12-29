using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    public class ffStream
    {
        public string codec_name { get; set; }
        public string codec_long_name { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public List<SideDataList> side_data_list { get; set; }

        public string sample_aspect_ratio { get; set; }
        public string color_space { get; set; }
        public string r_frame_rate { get; set; }
        public string avg_frame_rate { get; set; }
        public string bit_rate { get; set; }
    }

    //public class Stream
    //{
        
    //}
}
