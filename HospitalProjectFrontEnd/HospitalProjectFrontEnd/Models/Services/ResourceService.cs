using HospitalProjectFrontEnd.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Models.Services
{
    public class ResourceService : IResourceManager
    {
        private static readonly HttpClient client = new HttpClient();
        private string baseURL = @"https://hospitaller-team-forky-api.azurewebsites.net/api";
        public async Task<List<Resource>> GetAllResources()
        {
            string route = "resources";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");
            var result = await JsonSerializer.DeserializeAsync<List<Resource>>(streamTask);
            List<Resource> sortedResourcesByName = result.OrderBy(resource => resource.Name).ToList();
            return sortedResourcesByName;
        }

        public async Task<Resource> GetResourceById(int resourceId)
        {
            string route = "resources";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}/{resourceId}");
            var result = await JsonSerializer.DeserializeAsync<Resource>(streamTask);
            return result;
        }
    }
}
