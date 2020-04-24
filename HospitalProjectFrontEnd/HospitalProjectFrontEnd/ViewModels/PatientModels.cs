using HospitalProjectFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.ViewModels
{
    public class PatientModels
    {
        public Patient Patient { get; set; }
        public List<Resource> AllResources { get; set; }
    }
}
