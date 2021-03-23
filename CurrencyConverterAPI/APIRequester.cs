using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Conversion_App
{
    class APIRequester
    {

        private string url;
        private WebClient client;

        public APIRequester(string url)
        {
            this.url = url;
            this.client = new WebClient();
        }

        public string SendAndGetResponse()
        {
            return client.DownloadString(url);
        }
    }
}
