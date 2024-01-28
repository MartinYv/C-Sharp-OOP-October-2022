using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exeptions
{
   public class InvalidURLException : Exception
    {
        private const string Default_URL_Message = "Invalid URL!";
        public InvalidURLException():base(Default_URL_Message)
        {

        }
        public InvalidURLException(string message): base(message)
        {

        }
    }
}
