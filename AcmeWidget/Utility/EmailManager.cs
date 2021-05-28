using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidget.Utility
{
    public class EmailManager
    {
        public string EmailAddress { get; set; }

        public int EmailCategoty(EmailManager email)
        {

            if (email.EmailAddress.ToLower().Contains("@gmail"))
            {
                return 3;
            }

            if (email.EmailAddress.ToLower().Contains("@yahoo"))
            {
                return 2;
            }

            if (email.EmailAddress.Contains("@ocas"))
            {
                return 1;
            }
            return 0;

        }

    }
}
