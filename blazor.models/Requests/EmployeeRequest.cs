using Newtonsoft.Json;

namespace blazor.models.Requests
{
    public class EmployeeRequest
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
