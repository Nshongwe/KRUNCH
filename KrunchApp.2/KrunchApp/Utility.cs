using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunchApp
{
    public class Utility
    {
        public string GetAppSetting(string key)
        {
            string result = string.Empty;
            if (ConfigurationManager.AppSettings[key] != null)
            {
                result = ConfigurationManager.AppSettings[key];
            }

            return result;
        }

    }
}
