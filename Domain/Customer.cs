using System;
using Utils;

namespace Domain
{
    public class Customer 
    {
        private long socialSecurityNumber;

        public long GetSocialSecurityNumber() 
        {
            return socialSecurityNumber;
        }

        public void SetSocialSecurityNumber(long socialSecurityNumber) 
        {
            if (socialSecurityNumber != null && !AccountUtil.GyldigFnr(socialSecurityNumber.ToString())) 
            {
                throw new ArgumentException("socialSecurityNumber");
            }
            this.socialSecurityNumber = socialSecurityNumber;
        }

        public string Name { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int PostalCode { get; set; }
        public string Town { get; set; }
    }
}
