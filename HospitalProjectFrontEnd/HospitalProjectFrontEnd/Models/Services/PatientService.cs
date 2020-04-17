using HospitalProjectFrontEnd.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        //private string baseURL = @"https://localhost:44325/api";
        public async Task<List<Patient>> GetAllPatients()
        {
            string route = "patients";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");
            var result = await JsonSerializer.DeserializeAsync<List<Patient>>(streamTask);
            List<Patient> sortedPatientsByStatusDescending = result.OrderByDescending(patient => patient.Status).ToList();
            return sortedPatientsByStatusDescending;
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
            var data = JsonSerializer.Serialize(patient);

            string route = "patients";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var streamTask = await client.PostAsync($"{baseURL}/{route}", stringContent);
            return streamTask;
        }

        public Patient CreatePatient(string name, string birthday, int status)
        {
            Patient patient = new Patient()
            {
                Name = name,
                Birthday = birthday,
                Status = status,
                CheckIn = DateTime.Now
            };
            return patient;
        }

        public async Task RemovePatientById(int patientId)
        {
            string route = "patients";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            await client.DeleteAsync($"{baseURL}/{route}/{patientId}");
            //var result = await JsonSerializer.DeserializeAsync<Patient>(streamTask);
        }

        public async Task UpdatePatientById(int patientId, Patient patient)
        {
            string route = "patients";
            var data = JsonSerializer.Serialize(patient);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            await client.PutAsync($"{baseURL}/{route}/{patientId}", stringContent);
        }

        public Task<List<Patient>> GetPatientsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
