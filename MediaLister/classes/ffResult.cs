using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    public class FFResult
    {
        public List<object> programs { get; set; }
        public List<object> stream_groups { get; set; }
        public List<ffStream> streams { get; set; }
    }

    public class SideDataList
    {
    }

    
}
