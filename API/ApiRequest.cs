using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ApiRequest
    {
        public String reponseJSON { get; set; }

        public ApiRequest(String url)
        {
            WebRequest request = WebRequest.Create(url);
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            String responseFromServer = reader.ReadToEnd();

            this.reponseJSON = responseFromServer;

            // Clean up the streams and the response.  
            reader.Close();
            response.Close();
        }
    }
}
