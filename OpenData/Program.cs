using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using API;

namespace OpenData
{
    class Program
    {
        static void Main(string[] args)
        {

            ApiRoutes apiRoutes = new ApiRoutes();

            OpenGeocoding coordGps = apiRoutes.GetOpenGeocodingsApi("Grenoble", "Boulevard Marechal Lyautey");

            Result result = coordGps.results.First();
            Location location = result.locations.First();
            double latitude = location.latLng.lat;
            double longitude = location.latLng.lng;

            List<LinesNear> lignes = apiRoutes.GetLinesNearApi(longitude, latitude, 1000);

            List<SortResult> cleanResults = new List<SortResult>();

            foreach (LinesNear ligne in lignes) {
                //Find station in the cleanResult List
                SortResult existResult = cleanResults.Find(delegate (SortResult cleanResult)
                { return (cleanResult.resultName == ligne.name); }
                );
                //If station don't exist
                if(existResult == null)
                {
                    SortResult station = new SortResult(ligne.name);
                    foreach (String line in ligne.lines)
                    {
                        if (!station.resultLines.Contains(line))
                        {
                            station.resultLines.Add(line);
                        }
                    }
                    cleanResults.Add(station);
                }
                //If station already exist
                else
                {
                    foreach (String line in ligne.lines)
                    {
                        if (!existResult.resultLines.Contains(line))
                        {
                            existResult.resultLines.Add(line);
                        }
                    }
                }
            }

            
            //Display cleaninbg results
            foreach (SortResult cleanResult in cleanResults)
            {
                Console.WriteLine(cleanResult.resultName);
                foreach(String line in cleanResult.resultLines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
            }

            Console.ReadKey();

        }
  
    }
}
