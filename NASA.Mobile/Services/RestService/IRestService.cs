using NASA.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mobile.Services
{
    public interface IRestService
    {
        Task<MarsPhotoResponse> GetRovers(DateTime dateTime);
    }
}
