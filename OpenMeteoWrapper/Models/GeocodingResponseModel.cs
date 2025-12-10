using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteoWrapper.Models
{
    /// <summary>
    /// Geocoding API response
    /// </summary>
    public class GeocodingResponseModel
    {
        /// <summary>
        /// Array of found locations
        /// </summary>
        [JsonPropertyName("results")]
        public LocationDataModel[]? Locations { get; set; }

        /// <summary>
        /// Generation time of the response in milliseconds.
        /// </summary>
        [JsonPropertyName("generationtime_ms")]
        public float GenerationTime { get; set; }
    }
}
