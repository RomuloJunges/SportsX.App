using System;

namespace SportsX.Application.Helpers
{
    public class Formatters
    {
        public string FromatCPForCPNJ(string value)
        {
            if (value.Length == 11)
            {
                return Convert.ToUInt64(value).ToString(@"000\.000\.000\-00");
            }
            else if (value.Length == 14)
            {
                return Convert.ToUInt64(value).ToString(@"00\.000\.000\/0000\-00");
            }

            return null;
        }
    }
}