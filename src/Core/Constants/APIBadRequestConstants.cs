using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class APIBadRequestConstants
    {
        #region Phone
        public const string GetFailedCountriesNumber = "Failed to retrieve countries.";
        public const string GetFailedVerifyNumber = "Failed to validate phone number.";
        #endregion


        #region Email
        public const string GetFailedEmailVerification = "Failed to verify email.";
        #endregion

        #region Translation
        public const string GetFailedLanguages = "Failed to retrieve languages.";
        #endregion

    }
}
