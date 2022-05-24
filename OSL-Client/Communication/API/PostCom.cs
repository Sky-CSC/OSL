using Newtonsoft.Json;
using OSL_Client.RiotApp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Client.Communication.API
{
    internal class PostCom
    {
        public static void Test2()
        {
            //SSL.BypassSSL();
            string httpsLocalHost = "http://localhost:5000/weatherforecast";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsLocalHost);
            request.Headers["Accept"] = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            Console.WriteLine(reader.ReadToEnd());



            // Create a request for the URL. 		
            //WebRequest request = WebRequest.Create("https://localhost:5001/");
            //// If required by the server, set the credentials.
            ////request.Credentials = CredentialCache.DefaultCredentials;
            //// Get the response.
            ////request. = "GetWeatherForecast";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //// Display the status.
            //Console.WriteLine(response.StatusDescription);
            //// Get the stream containing content returned by the server.
            //Stream dataStream = response.GetResponseStream();
            //// Open the stream using a StreamReader for easy access.
            //StreamReader reader = new StreamReader(dataStream);
            //// Read the content.
            //string responseFromServer = reader.ReadToEnd();
            //// Display the content.
            //Console.WriteLine(responseFromServer);
            //// Cleanup the streams and the response.
            //reader.Close();
            //dataStream.Close();
            //response.Close();

        }

        //public static void Test()
        //{
        //    WebRequest request = WebRequest.Create("https://localhost:5001/");
        //    // Set the Method property of the request to POST.
        //    request.Method = "POST";

        //    // Create POST data and convert it to a byte array.
        //    //string postData = "This is a test that posts this string to a Web server.";
        //    //string str = "{ \"context_name\": { \"lower_bound\": \"value\", \"upper_bound\": \"value\", \"values\": [ \"value1\", \"valueN\" ] } }";
        //    string TypeMessage = "machin";

        //    var serialiseJsonInfo = new JsonIConnection
        //    {
        //        TypeMessage = TypeMessage,

        //    };
        //    dynamic postData = JsonConvert.SerializeObject(serialiseJsonInfo);


        //    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        //    // Set the ContentType property of the WebRequest.
        //    request.ContentType = "application/json";
        //    // Set the ContentLength property of the WebRequest.
        //    request.ContentLength = byteArray.Length;

        //    // Get the request stream.
        //    Stream dataStream = request.GetRequestStream();
        //    // Write the data to the request stream.
        //    dataStream.Write(byteArray, 0, byteArray.Length);

        //    Console.WriteLine("The value of 'ContentLength' property after sending the data is {0}", request.ContentLength);

        //    // Close the Stream object.
        //    dataStream.Close();

        //    // Get the response.
        //    WebResponse response = request.GetResponse();
        //    // Display the status.
        //    Console.WriteLine(((HttpWebResponse)response).StatusDescription);

        //    // Get the stream containing content returned by the server.
        //    // The using block ensures the stream is automatically closed.
        //    using (dataStream = response.GetResponseStream())
        //    {
        //        // Open the stream using a StreamReader for easy access.
        //        StreamReader reader = new StreamReader(dataStream);
        //        // Read the content.
        //        string responseFromServer = reader.ReadToEnd();
        //        // Display the content.
        //        Console.WriteLine(responseFromServer);
        //    }

        //    // Close the response.
        //    response.Close();
        //}
    }
}
