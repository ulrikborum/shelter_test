using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    using System;
    using System.Security.Principal;

    public class Shelter : IEntity
    {
        private int _id;
        private string _name;
        private string _geolocation;
        private string _place;
        private int _maxCapacity;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Id must be greater than 0.");
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value;
            }
        }

        public string Geolocation
        {
            get { return _geolocation; }
            set { _geolocation = value; }
        }

        public string Place
        {
            get { return _place; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Place cannot be empty.");
                _place = value;
            }
        }

        public int MaxCapacity
        {
            get { return _maxCapacity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("MaxCapacity cannot be negative.");
                _maxCapacity = value;
            }
        }

        public Shelter() { }

        public Shelter(int id, string name, string geolocation, string place, int maxCapacity)
        {
            Id = id;
            Name = name;
            Geolocation = geolocation;
            Place = place;
            MaxCapacity = maxCapacity;
        }
    }
}
