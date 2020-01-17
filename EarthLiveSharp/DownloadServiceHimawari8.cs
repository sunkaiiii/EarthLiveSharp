using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EarthLiveSharp
{
    class DownloadServiceHimawari8:IScraper
    {
        private int Interval { get; set; }
        private CancellationTokenSource _Token { get; set; }
        private readonly string JSON_URL = "http://himawari8.nict.go.jp/img/D531106/latest.json";
        private readonly string LAS_IMAGE = "0";
        private bool IsRun { get; set; }

        public DownloadServiceHimawari8()
        {
            IsRun = false;
        }

        public Task UpdateImage(CancellationTokenSource _cancelSource)
        {
            _Token = new CancellationTokenSource();
            IsRun = true;
            throw new NotImplementedException();
        }

        public void CleanCDN()
        {
            throw new NotImplementedException();
        }

        public void ResetState()
        {
            IsRun = false;
            throw new NotImplementedException();
        }
    }
}
