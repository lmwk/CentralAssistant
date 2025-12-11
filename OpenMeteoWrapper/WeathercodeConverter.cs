using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenMeteoWrapper
{
    public class WeathercodeConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int weathercode = reader.GetInt32();


            switch (weathercode)
            {
                case 0:
                    return "Clear sky";
                case 1:
                    return "Mainly clear";
                case 2:
                    return "Partly cloudy";
                case 3:
                    return "Overcast";
                case 45:
                    return "Fog";
                case 48:
                    return "Depositing rime Fog";
                case 51:
                    return "Light drizzle";
                case 53:
                    return "Moderate drizzle";
                case 55:
                    return "Dense drizzle";
                case 56:
                    return "Light freezing drizzle";
                case 57:
                    return "Dense freezing drizzle";
                case 61:
                    return "Slight rain";
                case 63:
                    return "Moderate rain";
                case 65:
                    return "Heavy rain";
                case 66:
                    return "Light freezing rain";
                case 67:
                    return "Heavy freezing rain";
                case 71:
                    return "Slight snow fall";
                case 73:
                    return "Moderate snow fall";
                case 75:
                    return "Heavy snow fall";
                case 77:
                    return "Snow grains";
                case 80:
                    return "Slight rain showers";
                case 81:
                    return "Moderate rain showers";
                case 82:
                    return "Violent rain showers";
                case 85:
                    return "Slight snow showers";
                case 86:
                    return "Heavy snow showers";
                case 95:
                    return "Thunderstorm";
                case 96:
                    return "Thunderstorm with light hail";
                case 99:
                    return "Thunderstorm with heavy hail";
                default:
                    return "Invalid weathercode";
            }
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            switch(value) 
            {
                case "Clear sky":
                    writer.WriteNumberValue(0);
                    break;
                case "Mainly clear":
                    writer.WriteNumberValue(1);
                    break;
                case "Partly cloudy":
                    writer.WriteNumberValue(2);
                    break;
                case "Overcast":
                    writer.WriteNumberValue(3);
                    break;
                case "Fog":
                    writer.WriteNumberValue(45);
                    break;
                case "Depositing rime Fog":
                    writer.WriteNumberValue(48);
                    break;
                case "Light drizzle":
                    writer.WriteNumberValue(51);
                    break;
                case "Moderate drizzle":
                    writer.WriteNumberValue(53);
                    break;
                case "Dense drizzle":
                    writer.WriteNumberValue(55);
                    break;
                case "Light freezing drizzle":
                    writer.WriteNumberValue(56);
                    break;
                case "Dense freezing drizzle":
                    writer.WriteNumberValue(57);
                    break;
                case "Slight rain":
                    writer.WriteNumberValue(61);
                    break;
                case "Moderate rain":
                    writer.WriteNumberValue(63);
                    break;
                case "Heavy rain":
                    writer.WriteNumberValue(65);
                    break;
                case "Light freezing rain":
                    writer.WriteNumberValue(66);
                    break;
                case "Heavy freezing rain":
                    writer.WriteNumberValue(67);
                    break;
                case "Slight snow fall":
                    writer.WriteNumberValue(71);
                    break;
                case "Moderate snow fall":
                    writer.WriteNumberValue(73);
                    break;
                case "Heavy snow fall":
                    writer.WriteNumberValue(75);
                    break;
                case "Snow grains":
                    writer.WriteNumberValue(77);
                    break;
                case "Slight rain showers":
                    writer.WriteNumberValue(80);
                    break;
                case "Moderate rain showers":
                    writer.WriteNumberValue(81);
                    break;
                case "Violent rain showers":
                    writer.WriteNumberValue(82);
                    break;
                case "Slight snow showers":
                    writer.WriteNumberValue(85);
                    break;
                case "Heavy snow showers":
                    writer.WriteNumberValue(86);
                    break;
                case "Thunderstorm":
                    writer.WriteNumberValue(95);
                    break;
                case "Thunderstorm with light hail":
                    writer.WriteNumberValue(96);
                    break;
                case "Thunderstorm with heavy hail":
                    writer.WriteNumberValue(99);
                    break;
            }
        }
    }
}
