using Newtonsoft.Json;

public class WeatherResponse
{
    [JsonProperty("city")]
    public CityInfo City { get; set; }
    [JsonProperty("list")]
    public List<WeatherForecast> List { get; set; }
}


public class WeatherForecast
{
    public long Dt { get; set; }
    public MainWeatherInfo Main { get; set; }
    public List<WeatherDescription> Weather { get; set; }
    public CloudsInfo Clouds { get; set; }
    public WindInfo Wind { get; set; }
    public double Visibility { get; set; }
    public SysInfo Sys { get; set; }
    public string DtTxt { get; set; }
}

public class MainWeatherInfo
{
    public double Temp { get; set; }
    public double FeelsLike { get; set; }
    public double TempMin { get; set; }
    public double TempMax { get; set; }
    public double Pressure { get; set; }
    public double Humidity { get; set; }
}

public class WeatherDescription
{
    public string Main { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}

public class CloudsInfo
{
    public int All { get; set; }
}

public class WindInfo
{
    public double Speed { get; set; }
    public double Deg { get; set; }
    public double Gust { get; set; }
}

public class SysInfo
{
    public string Pod { get; set; }
}


public class City
{
    public string Name { get; set; }
    public double Temperature { get; set; }
    public string WeatherDescription { get; set; }
    public double Humidity { get; set; }
    public double Pressure { get; set; }
    public double WindSpeed { get; set; }
    public double WindGust { get; set; }
    public double WindDirection { get; set; }

    public string Country { get; set; } 

}

public class CityInfo
{
    public string Name { get; set; }
    public string Country { get; set; }
}

