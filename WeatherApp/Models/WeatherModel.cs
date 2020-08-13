namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public int cod;
        public main main;
        public wind wind;
        public string message;
        public string reccomendation;
    }

    public class main
    {
        public double temp;
        public double feels_like;
        public double temp_min;
        public double temp_max;
        public int pressure;
        public int humidity;
    }

    public class wind
    {
        public double speed;
        public int deg;
    }

}