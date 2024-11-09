using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class CommonTask
    {


        public static bool IsEmpty(string value)
        {
            return string.IsNullOrEmpty(value); // Returns true if value is null or empty

        }
        public static string ComputerName
        {
            get
            {
                return System.Environment.MachineName;
            }
        }
    }
}
