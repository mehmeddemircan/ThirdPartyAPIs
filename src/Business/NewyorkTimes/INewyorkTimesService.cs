using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.NewyorkTimes
{
    public interface INewyorkTimesService
    {

        Task<string> GetMostPopularAsync();
    }
}
