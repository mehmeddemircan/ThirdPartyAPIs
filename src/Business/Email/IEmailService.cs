using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Email
{
    public interface IEmailService
    {
        Task<string> VerifyEmailAsync(string email);
    }
}
