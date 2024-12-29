using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    internal class FileOperations
    {
        private string optionsPath = Environment.CurrentDirectory;
        private string columnsFileName = "columnOptions.ath";
        public bool TrySaveColumns(List<Column> columns)
        {
            var jsonToSave = JsonSerializer.Serialize(columns);

            var saveTo = $"{optionsPath}\\{columnsFileName}";
            bool isSuccess = false;
            try
            {
                File.WriteAllText(saveTo, jsonToSave);
                isSuccess = true;
            }
            catch 
            { 
                
            }

            return isSuccess;
        }

        public List<Column> GetColumns()
        {
            var pathToOpen = $"{optionsPath}\\{columnsFileName}";
            if (File.Exists(pathToOpen))
            {
                var text = File.ReadAllText(pathToOpen);
                return JsonSerializer.Deserialize<List<Column>>(text);
            }
            return null;
        }
    }
}
