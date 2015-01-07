using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTrooper.Entities
{
    /// <summary>
    /// A planet.
    /// </summary>
    public class Planet : SharpEntity
    {
        /// <summary>
        /// An array of People URL Resources that live on this planet.
        /// </summary>
        public List<string> residents
        {
            get;
            set;
        }

        /// <summary>
        /// An array of Film URL Resources that this planet has appeared in.
        /// </summary>
        public List<string> films
        {
            get;
            set;
        }

        /// <summary>
        /// The number of standard hours it takes for this planet to complete a single rotation on it's axis.
        /// </summary>
        public string rotation_period
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
        /// A number denoting the gravity of this planet. Where 1 is normal.
        /// </summary>
        public string gravity
        {
            get;
            set;
        }

        /// <summary>
        /// the terrain of this planet. Comma-seperated if diverse.
        /// </summary>
        public string terrain
        {
            get;
            set;
        }

        /// <summary>
        /// The climate of this planet. Comma-seperated if diverse.
        /// </summary>
        public string climate
        {
            get;
            set;
        }

        /// <summary>
        /// The diameter of this planet in kilometers.
        /// </summary>
        public string diameter
        {
            get;
            set;
        }

        /// <summary>
        /// The ISO 8601 date format of the time that this resource was created.
        /// </summary>
        public string created
        {
            get;
            set;
        }

        /// <summary>
        /// The name of this planet.
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// The percentage of the planet surface that is naturally occuring water or bodies of water.
        /// </summary>
        public string surface_water
        {
            get;
            set;
        }

        /// <summary>
        /// The average population of sentient beings inhabiting this planet.
        /// </summary>
        public string population
        {
            get;
            set;
        }

        /// <summary>
        /// The number of standard days it takes for this planet to complete a single orbit of it's local star.
        /// </summary>
        public string orbital_period
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
    }
}