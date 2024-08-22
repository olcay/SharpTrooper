using Newtonsoft.Json;
using SharpTrooper.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharpTrooper.Core
{
    public class SharpTrooperCore(IHttpClientFactory clientFactory)
    {
        private readonly string apiUrl = "http://swapi.dev/api"; // could be placed into config file

        #region Private

        private async Task<string> RequestAsync(string url)
        {
            var client = clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: request returned: {response.StatusCode}");
            }

            return await response.Content.ReadAsStringAsync();
        }

        private static string SerializeDictionary(Dictionary<string, string> dictionary)
        {
            StringBuilder parameters = new();
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            {
                parameters.Append(keyValuePair.Key + "=" + keyValuePair.Value + "&");
            }
            return parameters.Remove(parameters.Length - 1, 1).ToString();
        }

        private async Task<T> GetSingleAsync<T>(string endpoint, Dictionary<string, string> parameters = null) where T : SharpEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "?" + SerializeDictionary(parameters);
            }

            return await GetSingleByUrlAsync<T>(url: string.Format("{0}{1}{2}", apiUrl, endpoint, serializedParameters));
        }

        private async Task<SharpEntityResults<T>> GetMultipleAsync<T>(string endpoint) where T : SharpEntity
        {
            return await GetMultipleAsync<T>(endpoint, null);
        }

        private async Task<SharpEntityResults<T>> GetMultipleAsync<T>(string endpoint, Dictionary<string, string> parameters) where T : SharpEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "?" + SerializeDictionary(parameters);
            }

            string json = await RequestAsync(string.Format("{0}{1}{2}", apiUrl, endpoint, serializedParameters));
            SharpEntityResults<T> swapiResponse = JsonConvert.DeserializeObject<SharpEntityResults<T>>(json);
            return swapiResponse;
        }

        private NameValueCollection GetQueryParameters(string dataWithQuery)
        {
            NameValueCollection result = [];
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

        private async Task<SharpEntityResults<T>> GetAllPaginatedAsync<T>(string entityName, string pageNumber = "1") where T : SharpEntity
        {
            Dictionary<string, string> parameters = new()
            {
                { "page", pageNumber }
            };

            SharpEntityResults<T> result = await GetMultipleAsync<T>(entityName, parameters);

            result.nextPageNo = string.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = string.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

            return result;
        }

        #endregion

        #region Public

        /// <summary>
        /// get a specific resource by url
        /// </summary>
        public async Task<T> GetSingleByUrlAsync<T>(string url) where T : SharpEntity
        {
            string json = await RequestAsync(url);
            T swapiResponse = JsonConvert.DeserializeObject<T>(json);
            return swapiResponse;
        }

        // People
        /// <summary>
        /// get a specific people resource
        /// </summary>
        public async Task<People> GetPeople(string id)
        {
            return await GetSingleAsync<People>("/people/" + id);
        }

        /// <summary>
        /// get all the people resources
        /// </summary>
        public async Task<SharpEntityResults<People>> GetAllPeopleAsync(string pageNumber = "1")
        {
            SharpEntityResults<People> result = await GetAllPaginatedAsync<People>("/people/", pageNumber);

            return result;
        }

        // Film
        /// <summary>
        /// get a specific film resource
        /// </summary>
        public async Task<Film> GetFilm(string id)
        {
            return await GetSingleAsync<Film>("/films/" + id);
        }

        /// <summary>
        /// get all the film resources
        /// </summary>
        public async Task<SharpEntityResults<Film>> GetAllFilmsAsync(string pageNumber = "1")
        {
            SharpEntityResults<Film> result = await GetAllPaginatedAsync<Film>("/films/", pageNumber);

            return result;
        }

        // Planet
        /// <summary>
        /// get a specific planet resource
        /// </summary>
        public async Task<Planet> GetPlanet(string id)
        {
            return await GetSingleAsync<Planet>("/planets/" + id);
        }

        /// <summary>
        /// get all the planet resources
        /// </summary>
        public async Task<SharpEntityResults<Planet>> GetAllPlanetsAsync(string pageNumber = "1")
        {
            SharpEntityResults<Planet> result = await GetAllPaginatedAsync<Planet>("/planets/", pageNumber);

            return result;
        }

        // Specie
        /// <summary>
        /// get a specific specie resource
        /// </summary>
        public async Task<Specie> GetSpecie(string id)
        {
            return await GetSingleAsync<Specie>("/species/" + id);
        }

        /// <summary>
        /// get all the specie resources
        /// </summary>
        public async Task<SharpEntityResults<Specie>> GetAllSpeciesAsync(string pageNumber = "1")
        {
            SharpEntityResults<Specie> result = await GetAllPaginatedAsync<Specie>("/species/", pageNumber);

            return result;
        }

        // Starship
        /// <summary>
        /// get a specific starship resource
        /// </summary>
        public async Task<Starship> GetStarshipAsync(string id)
        {
            return await GetSingleAsync<Starship>("/starships/" + id);
        }

        /// <summary>
        /// get all the starship resources
        /// </summary>
        public async Task<SharpEntityResults<Starship>> GetAllStarshipsAsync(string pageNumber = "1")
        {
            SharpEntityResults<Starship> result = await GetAllPaginatedAsync<Starship>("/starships/", pageNumber);

            return result;
        }

        // Vehicle
        /// <summary>
        /// get a specific vehicle resource
        /// </summary>
        public async Task<Vehicle> GetVehicleAsync(string id)
        {
            return await GetSingleAsync<Vehicle>("/vehicles/" + id);
        }

        /// <summary>
        /// get all the vehicle resources
        /// </summary>
        public async Task<SharpEntityResults<Vehicle>> GetAllVehiclesAsync(string pageNumber = "1")
        {
            SharpEntityResults<Vehicle> result = await GetAllPaginatedAsync<Vehicle>("/vehicles/", pageNumber);

            return result;
        }

        #endregion
    }
}
