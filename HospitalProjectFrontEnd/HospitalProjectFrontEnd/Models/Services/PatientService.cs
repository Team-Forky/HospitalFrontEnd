using HospitalProjectFrontEnd.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Models.Services
{
    public class PatientService : IPatientManager
    {
        public Task<List<Patient>> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetPatientById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> GetPatientsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
