using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exeptions
{
    public class InvalidPhoneNumberExeption : Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberExeption() : base(DEFAULT_EXCEPTION_MESSAGE)
        {

        }

        public InvalidPhoneNumberExeption(string message):base(message)
        {
            
        }
    }
}
