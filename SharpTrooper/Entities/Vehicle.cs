using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTrooper.Entities
{
    /// <summary>
    /// A vehicle.
    /// </summary>
    public class Vehicle : SharpEntity
    {
        /// <summary>
        /// An array of People URL Resources that this vehicle has been piloted by.
        /// </summary>
        public List<string> pilots
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum length of time that this vehicle can provide consumables for it's entire crew without having to resupply.
        /// </summary>
        public string consumables
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum number of kilograms that this vehicle can transport.
        /// </summary>
        public string cargo_capacity
        {
            get;
            set;
        }

        /// <summary>
        /// The name of this vehicle.
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// The hypermedia URL of this resource.
        /// </summary>
        public string url
        {
            get;
            set;
        }

        /// <summary>
        /// the ISO 8601 date format of the time that this resource was created.
        /// </summary>
        public string created
        {
            get;
            set;
        }

        /// <summary>
        /// the ISO 8601 date format of the time that this resource was edited.
        /// </summary>
        public string edited
        {
            get;
            set;
        }

        /// <summary>
        /// The number of personnel needed to run or pilot this vehicle.
        /// </summary>
        public string crew
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum speed of this vehicle in atmosphere.
        /// </summary>
        public string max_atmosphering_speed
        {
            get;
            set;
        }

        /// <summary>
        /// The number of non-essential people this vehicle can transport.
        /// </summary>
        public string passengers
        {
            get;
            set;
        }

        /// <summary>
        /// The class of this vehicle, such as Wheeled.
        /// </summary>
        public string vehicle_class
        {
            get;
            set;
        }

        /// <summary>
        /// The cost of this vehicle new, in galactic credits.
        /// </summary>
        public string cost_in_credits
        {
            get;
            set;
        }

        /// <summary>
        /// The model or official name of this vehicle. Such as All Terrain Attack Transport.
        /// </summary>
        public string model
        {
            get;
            set;
        }

        /// <summary>
        /// The model or official name of this vehicle. Such as All Terrain Attack Transport.
        /// </summary>
        public List<string> films
        {
            get;
            set;
        }

        /// <summary>
        /// The manufacturer of this vehicle. Comma seperated if more than one.
        /// </summary>
        public string manufacturer
        {
            get;
            set;
        }

        /// <summary>
        /// The length of this vehicle in meters.
        /// </summary>
        public string length
        {
            get;
            set;
        }
    }
}


