using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace p1
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            Program program = new Program();
            string url = "https://raw.githubusercontent.com/mayaxcn/china-ip-list/master/chn_ip.txt";
            WebClient client = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

            client.Headers.Add("user-agent", "a");

            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            
            string s = reader.ReadToEnd();
            s=s.Replace(" ", " - ");

            string docPath = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "ipfilter.dat")))
            {
                outputFile.WriteLine(s);
            }
            data.Close();
            reader.Close();
        }



    }
}
