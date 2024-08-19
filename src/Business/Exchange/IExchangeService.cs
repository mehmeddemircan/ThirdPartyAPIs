using Entities.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exchange
{
    public interface IExchangeService
    {
        Task<string> GetCurrencySymbolsAsync();

        Task<string> ConvertCurrencyAsync(CurrencyConversionRequest currencyConversionRequest);
    }
}
