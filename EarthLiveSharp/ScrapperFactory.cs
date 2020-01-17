using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthLiveSharp
{
    class ScrapperFactory
    {
        public static IScraper CreateScraperService(object config)
        {
            throw new NotImplementedException();
            switch(config)
            {
                default:
                    return new DownloadServiceHimawari8();
            }
        }
    }
}
