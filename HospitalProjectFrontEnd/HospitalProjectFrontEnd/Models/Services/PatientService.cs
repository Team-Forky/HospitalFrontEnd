using HospitalProjectFrontEnd.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Models.Services
{
    public class PatientService : IPatientManager
    {
        private static readonly HttpClient client = new HttpClient();
        private string baseURL = @"https://hospitaller-team-forky-api.azurewebsites.net/api"; 
        public async Task<List<Patient>> GetAllPatients()
        {
            string route = "patients";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");
            var result = await JsonSerializer.DeserializeAsync<List<Patient>>(streamTask);
            return result;
        }

        public async Task<Patient> GetPatientById(int patientId)
        {
            string route = "patients";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}/{patientId}");
            var result = await JsonSerializer.DeserializeAsync<Patient>(streamTask);
            return result;
        }

        public async Task<HttpResponseMessage> AddPatient(Patient patient)
        {
            string route = "patients";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(patient.ToString(), Encoding.Default, "application/json");
            var streamTask = await client.PostAsync($"{baseURL}/{route}", stringContent);
            return streamTask;
        }

        public Patient CreatePatient(string name, string birthday)
        {
            Patient patient = new Patient()
            {
                Name = name,
                Birthday = birthday
            };
            return patient;
        }

        public Task<List<Patient>> GetPatientsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
