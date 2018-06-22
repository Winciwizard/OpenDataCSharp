using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API
{
    public class ApiRoutes
    {
        public List<LinesNear> GetLinesNearApi(double longitude, double latitude, int around)
        {
            String formatLongitude = longitude.ToString();
            String formatLatitude = latitude.ToString();

            formatLongitude = formatLongitude.Replace(",", ".");
            formatLatitude = formatLatitude.Replace(",", ".");


            String url = $"http://data.metromobilite.fr/api/linesNear/json?x={formatLongitude}&y={formatLatitude}&dist={around}&details=true";

            ApiRequest apiRequest = new ApiRequest(url);

            return JsonConvert.DeserializeObject<List<LinesNear>>(apiRequest.reponseJSON);
        }


        public List<Roads> GetRoadsApi()
        {
            String url = "http://data.metromobilite.fr/api/routers/default/index/routes";

            ApiRequest apiRequest = new ApiRequest(url);

            return JsonConvert.DeserializeObject<List<Roads>>(apiRequest.reponseJSON);
        }

        public OpenGeocoding GetOpenGeocodingsApi(String city, String adress)
        {
            String apiKey = "QFEyACfuT7DecR93rfqYAH7psxvhVWHy";

            String formatCity = city.Replace(" ", "-");
            String formatAdress = adress.Replace(" ", "-");

            String url = $"http://open.mapquestapi.com/geocoding/v1/address?key={apiKey}&location=france,{formatCity},{formatAdress}";

            ApiRequest apiRequest = new ApiRequest(url);

            return JsonConvert.DeserializeObject<OpenGeocoding>(apiRequest.reponseJSON);
        }
    }
}
