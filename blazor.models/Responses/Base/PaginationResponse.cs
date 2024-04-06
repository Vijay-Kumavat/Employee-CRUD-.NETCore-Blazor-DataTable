using System.Text.Json.Serialization;

namespace blazor.models.Responses.Base
{
    public class PaginationResponse
    {
        [JsonIgnore]
        public int Total { get; set; }

        [JsonIgnore]
        public int OffSet { get; set; }
    }
}