using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace consumoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            GetItems();
        }

        private static void GetItems()
        {
            var url = $"https://gateway.marvel.com/v1/public/characters?ts=1&apikey=3960d3ed81d1c4632ff6f00d38165f7e&hash=bd762122135394fd714bb3ba8de901d5";
            var request = (System.Net.HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd().ToString();
                            // Do something with responseBody
                            JObject jsonPreservar = JObject.Parse(responseBody);
                            foreach (JObject jsonResult in jsonPreservar["data"]["results"].Children<JObject>())
                            {
                             
                                Console.Write(jsonResult["name"] + "\n");

                            }
 
                            Console.Write("Press any key to close the Calculator console app...");
                            Console.ReadKey();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }
    }
}
