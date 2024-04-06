using blazor.models.Responses.Base;
using Newtonsoft.Json;
using System;

namespace blazor.models.Responses
{
    public class EmployeesResponse : PaginationResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dob")]
        public DateTime DOB { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }
    }
}
