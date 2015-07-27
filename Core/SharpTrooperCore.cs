using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using SharpTrooper.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;

namespace SharpTrooper.Core
{
    public class SharpTrooperCore
    {
        private enum HttpMethod
        {
            GET,
            POST
        }

        private string apiUrl = "http://swapi.co/api";
        private string _proxyName = null;

        public SharpTrooperCore()
        {
        }

        public SharpTrooperCore(string proxyName)
        {
            _proxyName = proxyName;
        }

        #region Private

        private string Request(string url, HttpMethod httpMethod)
        {
            return Request(url, httpMethod, null, false);
        }

        private string Request(string url, HttpMethod httpMethod, string data, bool isProxyEnabled)
        {
            string result = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = httpMethod.ToString();

            if (!String.IsNullOrEmpty(_proxyName))
            {
                httpWebRequest.Proxy = new WebProxy(_proxyName, 80);
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
            }

            if (data != null)
            {
                byte[] bytes = UTF8Encoding.UTF8.GetBytes(data.ToString());
                httpWebRequest.ContentLength = bytes.Length;
                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Dispose();
            }

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
            result = reader.ReadToEnd();
            reader.Dispose();

            return result;
        }

        private string SerializeDictionary(Dictionary<string, string> dictionary)
        {
            StringBuilder parameters = new StringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            {
                parameters.Append(keyValuePair.Key + "=" + keyValuePair.Value + "&");
            }
            return parameters.Remove(parameters.Length - 1, 1).ToString();
        }


        

        private T GetSingle<T>(string endpoint, Dictionary<string, string> parameters = null) where T : SharpEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "?" + SerializeDictionary(parameters);
            }

            return GetSingleByUrl<T>(url: string.Format("{0}{1}{2}", apiUrl, endpoint, serializedParameters));
        }

        private SharpEntityResults<T> GetMultiple<T>(string endpoint) where T : SharpEntity
        {
            return GetMultiple<T>(endpoint, null);
        }

        private SharpEntityResults<T> GetMultiple<T>(string endpoint, Dictionary<string, string> parameters) where T : SharpEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "?" + SerializeDictionary(parameters);
            }

            string json = Request(string.Format("{0}{1}{2}", apiUrl, endpoint, serializedParameters), HttpMethod.GET);
            SharpEntityResults<T> swapiResponse = JsonConvert.DeserializeObject<SharpEntityResults<T>>(json);
            return swapiResponse;
        }

        private NameValueCollection GetQueryParameters(string dataWithQuery)
        {
            NameValueCollection result = new NameValueCollection();
            string[] parts = dataWithQuery.Split('?');
            if (parts.Length > 0)
            {
                string QueryParameter = parts.Length > 1 ? parts[1] : parts[0];
                if (!string.IsNullOrEmpty(QueryParameter))
                {
                    string[] p = QueryParameter.Split('&');
                    foreach (string s in p)
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result.Add(temp[0], temp[1]);
                        }
                        else
                        {
                            result.Add(s, string.Empty);
                        }
                    }
                }
            }
            return result;
        }

        private SharpEntityResults<T> GetAllPaginated<T>(string entityName, string pageNumber = "1") where T : SharpEntity
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            SharpEntityResults<T> result = GetMultiple<T>(entityName, parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

            return result;
        }

        #endregion

        #region Public

        /// <summary>
        /// get a specific resource by url
        /// </summary>
        public T GetSingleByUrl<T>(string url) where T : SharpEntity
        {
            string json = Request(url, HttpMethod.GET);
            T swapiResponse = JsonConvert.DeserializeObject<T>(json);
            return swapiResponse;
        }

        // People
        /// <summary>
        /// get a specific people resource
        /// </summary>
        public People GetPeople(string id)
        {
            return GetSingle<People>("/people/" + id);
        }

        /// <summary>
        /// get all the people resources
        /// </summary>
        public SharpEntityResults<People> GetAllPeople(string pageNumber = "1")
        {
            SharpEntityResults<People> result = GetAllPaginated<People>("/people/", pageNumber);

            return result;
        }

        // Film
        /// <summary>
        /// get a specific film resource
        /// </summary>
        public Film GetFilm(string id)
        {
            return GetSingle<Film>("/films/" + id);
        }

        /// <summary>
        /// get all the film resources
        /// </summary>
        public SharpEntityResults<Film> GetAllFilms(string pageNumber = "1")
        {
            SharpEntityResults<Film> result = GetAllPaginated<Film>("/films/", pageNumber);

            return result;
        }

        // Planet
        /// <summary>
        /// get a specific planet resource
        /// </summary>
        public Planet GetPlanet(string id)
        {
            return GetSingle<Planet>("/planets/" + id);
        }

        /// <summary>
        /// get all the planet resources
        /// </summary>
        public SharpEntityResults<Planet> GetAllPlanets(string pageNumber = "1")
        {
            SharpEntityResults<Planet> result = GetAllPaginated<Planet>("/planets/", pageNumber);

            return result;
        }

        // Specie
        /// <summary>
        /// get a specific specie resource
        /// </summary>
        public Specie GetSpecie(string id)
        {
            return GetSingle<Specie>("/species/" + id);
        }

        /// <summary>
        /// get all the specie resources
        /// </summary>
        public SharpEntityResults<Specie> GetAllSpecies(string pageNumber = "1")
        {
            SharpEntityResults<Specie> result = GetAllPaginated<Specie>("/species/", pageNumber);

            return result;
        }

        // Starship
        /// <summary>
        /// get a specific starship resource
        /// </summary>
        public Starship GetStarship(string id)
        {
            return GetSingle<Starship>("/starships/" + id);
        }

        /// <summary>
        /// get all the starship resources
        /// </summary>
        public SharpEntityResults<Starship> GetAllStarships(string pageNumber = "1")
        {
            SharpEntityResults<Starship> result = GetAllPaginated<Starship>("/starships/", pageNumber);

            return result;
        }

        // Vehicle
        /// <summary>
        /// get a specific vehicle resource
        /// </summary>
        public Vehicle GetVehicle(string id)
        {
            return GetSingle<Vehicle>("/vehicles/" + id);
        }

        /// <summary>
        /// get all the vehicle resources
        /// </summary>
        public SharpEntityResults<Vehicle> GetAllVehicles(string pageNumber = "1")
        {
            SharpEntityResults<Vehicle> result = GetAllPaginated<Vehicle>("/vehicles/", pageNumber);

            return result;
        }

        #endregion
    }
}
