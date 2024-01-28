using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exeptions;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ISmartphone
    {
       
        public string BrowseURL(string url)
        {
            if (!ValidateURL(url))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberExeption();
            }

            return $"Calling... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber) => phoneNumber.All(x => char.IsDigit(x));
        private bool ValidateURL(string url) => url.All(x => !char.IsDigit(x));
    }
}
