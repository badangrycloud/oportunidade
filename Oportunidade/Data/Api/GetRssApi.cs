using Data.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Data.Api
{
    public class GetRssApi : IApi
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string _url;

        public GetRssApi(string url)
        {
            _url = url ?? throw new ArgumentNullException(nameof(url));
        }

        public Rss GetRssData()
        {
            try
            {
                var rss = client.GetStreamAsync(_url).Result;
                var serializer = new XmlSerializer(typeof(Rss));
                return (Rss)serializer.Deserialize(rss);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
