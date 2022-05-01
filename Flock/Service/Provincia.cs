using Flock.IServices;
using Flock.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace Flock.Service
{
    public class Provincia: IProvincia
    {
        public Models.Georreferenciacion LatLon(string nombreProvincia)
        {
            RestClient client = new RestClient("https://apis.datos.gob.ar/georef/api/provincias?nombre="+ $"{nombreProvincia}");

            client.AddDefaultHeader("Content-Type", "application/json");

            var request = new RestRequest(Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            var restRequest = client.Execute(request);

            if (restRequest.StatusCode == HttpStatusCode.OK)
            {
                var responseString = restRequest.Content;
                return JsonConvert.DeserializeObject<Models.Georreferenciacion>(responseString);
            }
            else 
            {
                return null;
            }
        }
        public async Task<Georreferenciacion> LatLonAsync(string nombreProvincia)
        {
            RestClient client = new RestClient("https://apis.datos.gob.ar/georef/api/provincias?nombre=" + $"{nombreProvincia}");

            client.AddDefaultHeader("Content-Type", "application/json");

            var request = new RestRequest(Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            var restRequest = await client.ExecuteAsync(request);

            if (restRequest.StatusCode == HttpStatusCode.OK)
            {
                var responseString = restRequest.Content;
                return JsonConvert.DeserializeObject<Models.Georreferenciacion>(responseString);
            }
            else
            {
                return null;
            }
        }
    }
}
