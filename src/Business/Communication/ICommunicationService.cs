using DTOs.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Communication
{
    public interface ICommunicationService
    {
        Task<Dictionary<string, CountryResponse>> GetNumberCodeOfCountriesAsync();

        Task<string> ValidatePhoneNumberAsync(string number);
    }
}
