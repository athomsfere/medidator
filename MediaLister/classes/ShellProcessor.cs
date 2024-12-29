using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLister.classes
{
    internal class ShellProcessor
    {
        internal ShellPropertyCollection GetAllMediaProperties(string filePath)
        {
            ShellPropertyCollection shellProperties;
            try
            {
                using (ShellPropertyCollection properties = new ShellPropertyCollection(@filePath))
                {
                    return properties;

                }
            }
            catch (Exception ex)
            {
                //log eventually
            }


            return null;
        }
    }
}
