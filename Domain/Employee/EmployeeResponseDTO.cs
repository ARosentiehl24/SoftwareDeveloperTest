using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employee
{
    public class EmployeeResponseDTO
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("data")]
        public EmployeeDTO? Data { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
