using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteoWrapper.Options
{
    public class GeocodingOptions
    {
        public string Name { get; }

        public string Language { get; }

        public string Format { get; }

        public int Count { get; }

        public GeocodingOptions(string city, string language = "en", int count = 100)
        {
            Name = city;
            Language = language;
            Format = "json";
            Count = count;
        }
    }
}
