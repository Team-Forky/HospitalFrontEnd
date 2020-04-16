using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalProjectFrontEnd.Models
{
    public class Patient
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("checkIn")]
        public DateTime CheckIn { get; set; }
    }

    public enum Status
    {
        stable = 0,
        unstable = 1,
        critical = 2,
        deceased = 3
    }

}
