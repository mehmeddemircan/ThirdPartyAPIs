using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Translation
{
    public class TranslationRequest
    {
        public string Target { get; set; }
        public string Source { get; set; }
        public string Text { get; set; }
    }
}
