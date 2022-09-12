using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Adotepet.Api.Servicos
{
    public class GeolocationService
    {
        public static void BuscarGeolocalizacao(string? municipio, out decimal? latitude, out decimal? longitude)
        {
            latitude = null;
            longitude = null;
            using(var httpClient = new HttpClient())
            {
                try
                {
                    var result = httpClient.GetStringAsync(
                        $"https://api.mapbox.com/geocoding/v5/mapbox.places/{municipio} Brasil.json?limit=1&types=place%2Cpostcode%2Caddress&language=pt&access_token=pk.eyJ1IjoiZWx0b25kczg4IiwiYSI6ImNsN3l1eWZzeTE5aWEzbm81ZzZ0a3R0aHoifQ.R7-C1sQf9nxdx_c8U8557A"
                    ).Result;
                    var json = JsonConvert.DeserializeObject<JObject>(result);
                    if (json == null)
                    {
                        return;
                    }

                    if (json.ContainsKey("features"))
                    {
                        var feature = (JObject)((JArray)json.GetValue("features"))[0];
                        if (feature.ContainsKey("center"))
                        {
                            var latLng = (JArray)feature.GetValue("center");
                            longitude = latLng[0].Value<decimal>();
                            latitude = latLng[1].Value<decimal>();
                        }
                    }
                }
                catch(Exception e)
                {
                    //TODO - adicionar log
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                
            }
        }
    }
}
