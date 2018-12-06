using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Helpers
{
    public class DateHelper
    {
        public static string GetCurrentyear()
        {
            return DateTime.Now.Year.ToString();
        }
    }
}
