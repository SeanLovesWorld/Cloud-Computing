using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace simpleCrawler
{
    class Program
    {
        WebRequest r = WebRequest.Create(" https://www.w3schools.com/tags/att_a_href.asp");
        WebResponse respone = r.GetResponseAsync();

      
        static void Main(string[] url)
        {

            using (var webclient = new HttpClient())
            {
                webclient.BaseAddress = new Uri(" https://www.w3schools.com/tags/");
                HttpResponseMessage webResponse = webclient.GetStringAsync("att_a_href.asp").Result;
                webResponse.EnsureSuccessStatusCode();

                var result = webResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }

        }

        static async Task crawlAsync()
        {
            var url =  "http://courses.washington.edu/css502/dimpsey ";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlContent = new HtmlContent();

            new HttpWebRequest(
                this.Links = new List<string>();
            htmlContent nodes = HttpWebRequest.Html.documentNode.selectNodes("<a href >");
            foreach (var node in nodes)
            {
                string href = nodes.Atrribute["href"].Value;
                this.Links.Add(href);
            }
        }

        static void numhops (int[] hops)
        {
            foreach (hops, result url)
            {
                HttpClientHandler.Equals = IAsyncResult;
                hops++;
            }
            Console.WriteLine("The number of hops" + hops);
        }
   
     
 }

}
