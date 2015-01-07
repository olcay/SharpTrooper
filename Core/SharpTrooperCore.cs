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


        /// <summary>
        /// get a specific resource by url
        /// </summary>
        public T GetSingleByUrl<T>(string url) where T : SharpEntity
        {
            string json = Request(url, HttpMethod.GET);
            T swapiResponse = JsonConvert.DeserializeObject<T>(json);
            return swapiResponse;
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
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            SharpEntityResults<People> result = GetMultiple<People>("/people/", parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

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
        public SharpEntityResults<Film> GetAllFilm(string pageNumber = "1")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            SharpEntityResults<Film> result = GetMultiple<Film>("/films/", parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

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
        public SharpEntityResults<Planet> GetAllPlanet(string pageNumber = "1")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            SharpEntityResults<Planet> result = GetMultiple<Planet>("/planets/", parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

            return result;
        }

        // Specie
        /// <summary>
        /// get a specific planet resource
        /// </summary>
        public Specie GetSpecie(string id)
        {
            return GetSingle<Specie>("/species/" + id);
        }

        /// <summary>
        /// get all the planet resources
        /// </summary>
        public SharpEntityResults<Specie> GetAllSpecie(string pageNumber = "1")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            SharpEntityResults<Specie> result = GetMultiple<Specie>("/species/", parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

            return result;
        }

        // Starship
        /// <summary>
        /// get a specific planet resource
        /// </summary>
        public Starship GetStarship(string id)
        {
            return GetSingle<Starship>("/starships/" + id);
        }

        /// <summary>
        /// get all the planet resources
        /// </summary>
        public SharpEntityResults<Starship> GetAllStarship(string pageNumber = "1")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            SharpEntityResults<Starship> result = GetMultiple<Starship>("/starships/", parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

            return result;
        }

        // Vehicle
        /// <summary>
        /// get a specific planet resource
        /// </summary>
        public Vehicle GetVehicle(string id)
        {
            return GetSingle<Vehicle>("/vehicles/" + id);
        }

        /// <summary>
        /// get all the planet resources
        /// </summary>
        public SharpEntityResults<Vehicle> GetAllVehicle(string pageNumber = "1")
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            SharpEntityResults<Vehicle> result = GetMultiple<Vehicle>("/vehicles/", parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

            return result;
        }
    }
}
