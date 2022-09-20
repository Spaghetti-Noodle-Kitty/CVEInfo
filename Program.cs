using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Automation
{
    internal class Program
    {
        public static string NIST_CVE_SERV = "https://services.nvd.nist.gov/rest/json/cve/1.0/"; // The base URL to get NVD-Entries //
        private static string API_KEY = ""; // API-Key used for heightend request number at the NVD //
        private static bool DESCRIPTION_FLAG = false;

    static void Main(string[] args)
        {
            try
            {
                if (!Regex.Match(args[0], "CVE-\\d{4}-\\d{4,7}").Success) // Test if provided CVE has a valid format //
                    Console.WriteLine("Invalid CVE"); // mald //
                else
                {
                    try
                    {
                        // Create a web-request using get, targeting the NVD-Json-API and pass the API-Key in URL //
                        HttpWebRequest REQUEST_TO_NVD = (HttpWebRequest)WebRequest.Create(String.Format("https://services.nvd.nist.gov/rest/json/cve/1.0/{0}?apiKey={1}", args[0], API_KEY));
                        REQUEST_TO_NVD.Method = "GET";
                        // Get response from NVD and read it //
                        WebResponse NVD_RESPONSE = REQUEST_TO_NVD.GetResponse();
                        Stream RESPONSE_STREAM = NVD_RESPONSE.GetResponseStream();
                        StreamReader RESPONSE_READER = new StreamReader(RESPONSE_STREAM);
                        String JSON_RESPONSE = RESPONSE_READER.ReadToEnd();
                        // Send read JSON to parser method //
                        JsonReader.GetCVEInfo(JSON_RESPONSE, DESCRIPTION_FLAG);
                    }
                    catch
                    { Console.WriteLine("Error Getting CVE Information"); /* mald because of network/API issue */ }

                }
            }
            catch
            { Console.WriteLine("You must provide a CVE-Number"); }
            Console.WriteLine();
            

        }
    }
}
