using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    internal class ColumnCreator
    {
        internal List<Column> GetDefaultColumns()
        {
            List<Column> columns = new List<Column>();
            //add this logic
            int position = 1;

            foreach (var item in typeof(MovieInfo).GetProperties())
            {
                var column = new Column()
                {
                    Description = item.Name,
                    Name = item.Name,
                    Position = position,     
                    IsChecked = true,
                };

                columns.Add(column);
                position++;
            }

            return columns;
        }


    }
}
