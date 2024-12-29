using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    internal class Column
    {
        public int Position {  get; set; }
        public string Name { get; set; }
        //public string Value { get; set; }
        public string Description { get; set; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return Description ?? Name;
        }
    }
}
