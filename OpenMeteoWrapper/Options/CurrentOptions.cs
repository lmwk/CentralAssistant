using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteoWrapper.Options
{
    public class CurrentOptions : IEnumerable, ICollection<CurrentOptionsParameter>
    {
        public static CurrentOptions All { get { return new CurrentOptions((CurrentOptionsParameter[])Enum.GetValues(typeof(CurrentOptionsParameter))); } }

        public List<CurrentOptionsParameter> Parameter { get { return new List<CurrentOptionsParameter>(_parameter); } }

        public int Count => _parameter.Count;

        public bool IsReadOnly => false;

        private readonly List<CurrentOptionsParameter> _parameter = new List<CurrentOptionsParameter>();

        public CurrentOptions()
        {

        }

        public CurrentOptions(CurrentOptionsParameter parameter)
        {
            Add(parameter);
        }

        public CurrentOptions(CurrentOptionsParameter[] parameter)
        {
            Add(parameter);
        }

        public CurrentOptionsParameter this[int index]
        {
            get { return _parameter[index]; }
            set
            {
                _parameter[index] = value;
            }
        }

        public void Add(CurrentOptionsParameter param)
        {
            if (_parameter.Contains(param)) return;

            _parameter.Add(param);
        }

        public void Add(CurrentOptionsParameter[] param)
        {
            foreach (CurrentOptionsParameter paramToAdd in param)
            {
                Add(paramToAdd);
            }
        }

        public void Clear()
        {
            _parameter.Clear();
        }

        public bool Contains(CurrentOptionsParameter item)
        {
            return _parameter.Contains(item);
        }

        public bool Remove(CurrentOptionsParameter item)
        {
            return _parameter.Remove(item);
        }

        public void CopyTo(CurrentOptionsParameter[] array, int arrayIndex)
        {
            _parameter.CopyTo(array, arrayIndex);
        }

        public IEnumerator<CurrentOptionsParameter> GetEnumerator()
        {
            return _parameter.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public enum CurrentOptionsParameter
    {
        temperature_2m,
        relativehumidity_2m,
        apparent_temperature,
        is_day, precipitation,
        rain,
        showers,
        snowfall,
        weathercode,
        cloudcover,
        pressure_msl,
        surface_pressure,
        windspeed_10m,
        winddirection_10m,
        windgusts_10m
    }
}
