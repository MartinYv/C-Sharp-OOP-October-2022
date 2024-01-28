using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exeptions;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone()
        {

        }
        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberExeption();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber) => phoneNumber.All(x => char.IsLetterOrDigit(x));
        
    }
}
