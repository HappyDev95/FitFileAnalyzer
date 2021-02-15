using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityMetricsCore.Util
{
    public static class DateUtil
    {
        public static DateTime GetDateFromString(string date)
        {
            return DateTime.Parse(date.Substring(0, 10));
        }
    }
}
