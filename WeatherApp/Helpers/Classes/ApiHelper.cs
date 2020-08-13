using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using WeatherApp.Models;

namespace WeatherApp.Helpers.Classes
{
    public class ApiHelper : IApiHelper
    {
        public WeatherModel GetWeatherInfo(string cityName)
        {

            string html = string.Empty;

            WeatherModel myObject = new WeatherModel();

            string serverUrl = @"http://api.openweathermap.org/data/2.5/weather?";

            string cityInfo = "q=" + cityName;

            string keyInfo = "&appid=489e8ed5c83cf8b3b6756b6d8d62d0c8";

            string unitsInfo = "&units=metric";

            string languageInfo = "&lang=ru";

            string url = serverUrl + cityInfo + keyInfo + unitsInfo + languageInfo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {

                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();

                        var objText = reader.ReadToEnd();

                        myObject = (WeatherModel)js.Deserialize(objText, typeof(WeatherModel));

                        switch (myObject.main.temp)
                        {
                            case var _ when myObject.main.temp < 0:
                                myObject.reccomendation = "Одевайтесь потеплее, на улице холодно";
                                break;

                            case var _ when myObject.main.temp > 25:
                                myObject.reccomendation = "На улице жарко, возьмите с собой воду :)";

                                break;

                            default:
                                myObject.reccomendation = "Рекомендаций не будет, на улице чудесная погода";
                                break;
                        }
                        }

                }
            }

            catch (Exception)
            {
                myObject.message = "Данные отсутствуют";
            }

            return myObject;
        }
    }
}