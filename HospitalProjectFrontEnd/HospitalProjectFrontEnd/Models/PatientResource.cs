using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Models
{
    public class PatientResource
    {
        [JsonPropertyName("patientID")]
        public int PatientID { get; set; }

        [JsonPropertyName("resourcesID")]
        public int ResourceID { get; set; }
    }
}
