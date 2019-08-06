using System;
using System.Collections.Generic;
using System.Text;

namespace Cart_CleanCodePractices
{
    class ServerConfiguration
    {
        private static int _discount = 15;
        public static int GetPercentageDiscount()
        {
            //Hardcoded Discount Percentage
            return(_discount);
        }
    }
}
