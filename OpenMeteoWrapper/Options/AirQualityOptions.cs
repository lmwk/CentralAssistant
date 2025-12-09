using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteoWrapper.Options
{
    public class AirQualityOptions
    {
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public HourlyOptions Hourly { get { return _hourly; } set {if (value != null) _hourly = value; } }

        public string Domains { get; set; }

        public string TimeFormat { get; set; }

        public string Timezone { get; set; }

        public int Past_Days { get; set; }

        public string Start_Date { get; set; }

        public string End_Date { get; set; }

        private HourlyOptions _hourly = new HourlyOptions();

        public class HourlyOptions : IEnumerable<HourlyOptionsParameter>, ICollection<HourlyOptionsParameter>
        {
            public static HourlyOptions All { get { return new HourlyOptions((HourlyOptionsParameter[])Enum.GetValues(typeof(HourlyOptionsParameter))); } }

            public List<AirQualityOptions.HourlyOptionsParameter> Parameter { get { return new List<HourlyOptionsParameter>(_parameter); } }

            public int Count => _parameter.Count;

            public bool IsReadOnly => false;

            private readonly List<HourlyOptionsParameter> _parameter = new List<HourlyOptionsParameter>();

            public HourlyOptions(HourlyOptionsParameter parameter)
            {
                Add(parameter);
            }

            public HourlyOptions(HourlyOptionsParameter[] parameter)
            {
                Add(parameter);
            }

            public HourlyOptions()
            {

            }

            public HourlyOptionsParameter this[int index]
            {
                get { return _parameter[index]; }
                set
                {
                    _parameter[index] = value;
                }
            }

            public void Add(HourlyOptionsParameter param)
            {
                if (this._parameter.Contains(param)) return;

                _parameter.Add(param);
            }

            public void Add(HourlyOptionsParameter[] param)
            {
                foreach (HourlyOptionsParameter paramToAdd in param)
                {
                    Add(paramToAdd);
                }
            }

            public IEnumerator<HourlyOptionsParameter> GetEnumerator()
            {
                return _parameter.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public void Clear()
            {
                _parameter.Clear();
            }

            public bool Contains(HourlyOptionsParameter item)
            {
                return _parameter.Contains(item);
            }

            public void CopyTo(HourlyOptionsParameter[] array, int arrayIndex)
            {
                _parameter.CopyTo(array, arrayIndex);
            }

            public bool Remove(HourlyOptionsParameter item)
            {
                return _parameter.Remove(item);
            }
        }
        public enum HourlyOptionsParameter
        {
            pm10,
            pm2_5,
            carbon_monoxide,
            nitrogen_dioxide,
            sulphur_dioxide,
            ozone,
            aerosol_optical_depth,
            dust,
            uv_index,
            uv_index_clear_sky,
            alder_pollen,
            birch_pollen,
            grass_pollen,
            mugwort_pollen,
            olive_pollen,
            ragweed_pollen,
            european_aqi,
            european_aqi_pm2_5,
            european_aqi_pm10,
            european_aqi_no2,
            european_aqi_o3,
            european_aqi_so2,
            us_aqi,
            us_aqi_pm2_5,
            us_aqi_pm10,
            us_aqi_no2,
            us_aqi_o3,
            us_aqi_so2,
            us_aqi_co
        }
    }
}
