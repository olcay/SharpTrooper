using System.Collections.Generic;

namespace SharpTrooper.Entities
{
    /// <summary>
    /// A person within the Star Wars universe
    /// </summary>
    public class People : SharpEntity
    {
        /// <summary>
        /// An array of vehicle resources that this person has piloted
        /// </summary>
        public List<string> vehicles
        {
            get;
            set;
        }

        /// <summary>
        /// The gender of this person (if known).
        /// </summary>
        public string gender
        {
            get;
            set;
        }

        /// <summary>
        /// The url of this resource
        /// </summary>
        public string url
        {
            get;
            set;
        }

        /// <summary>
        /// The height of this person in meters.
        /// </summary>
        public string height
        {
            get;
            set;
        }

        /// <summary>
        /// The hair color of this person.
        /// </summary>
        public string hair_color
        {
            get;
            set;
        }

        /// <summary>
        /// The skin color of this person.
        /// </summary>
        public string skin_color
        {
            get;
            set;
        }

        /// <summary>
        /// An array of starship resources that this person has piloted
        /// </summary>
        public List<string> starships
        {
            get;
            set;
        }

        /// <summary>
        /// The name of this person.
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// An array of urls of film resources that this person has been in.
        /// </summary>
        public List<string> films
        {
            get;
            set;
        }

        /// <summary>
        /// The birth year of this person. BBY (Before the Battle of Yavin) or ABY (After the Battle of Yavin).
        /// </summary>
        public string birth_year
        {
            get;
            set;
        }

        /// <summary>
        /// The url of the planet resource that this person was born on.
        /// </summary>
        public string homeworld
        {
            get;
            set;
        }

        /// <summary>
        /// The url of the species resource that this person is.
        /// </summary>
        public List<string> species
        {
            get;
            set;
        }

        /// <summary>
        /// The eye color of this person.
        /// </summary>
        public string eye_color
        {
            get;
            set;
        }

        /// <summary>
        /// The mass of this person in kilograms.
        /// </summary>
        public string mass
        {
            get;
            set;
        }
    }
}