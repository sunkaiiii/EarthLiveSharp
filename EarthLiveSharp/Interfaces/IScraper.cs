using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthLiveSharp.Interfaces
{
    interface IScraper
    {
        void UpdateImage();
        void CleanCDN();
        void ResetState();
    }
}
