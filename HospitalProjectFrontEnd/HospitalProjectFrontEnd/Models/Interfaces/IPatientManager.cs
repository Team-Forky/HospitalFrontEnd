using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Models.Interfaces
{
    public interface IPatientManager
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        Task<List<Patient>> GetPatientsByName(string name);

        Task<Patient> AddPatient(Patient patient);
        Patient CreatePatient(string name, string birthday);
    }
}
