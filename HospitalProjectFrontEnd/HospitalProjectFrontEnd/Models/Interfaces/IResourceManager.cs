using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Models.Interfaces
{
    public interface IResourceManager
    {
        //Task<List<Patient>> GetPatientsByName(string name);

        //Task<HttpResponseMessage> AddPatient(Patient patient);
        //Patient CreatePatient(string name, string birthday, int status);
        //Task RemovePatientById(int patientId);
        //Task UpdatePatientById(int patientId, Patient patient);

        Task<List<Resource>> GetAllResources();
        Task<Resource> GetResourceById(int id);

    }
}
