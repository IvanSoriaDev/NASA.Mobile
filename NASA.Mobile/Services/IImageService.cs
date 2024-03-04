using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mobile.Services
{
    public interface IImageService
    {
        Task<bool> DownloadAndSaveImageAsync(string imageUrl);
    }
}
