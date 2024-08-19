using DTOs.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Translation
{
    public interface ITranslationService
    {
        Task<string> GetSupportedLanguagesAsync();

        Task<string> TranslateTextAsync(TranslationRequest requestDto);

        Task<string> IdentifyLanguage(string text);
    }
}
