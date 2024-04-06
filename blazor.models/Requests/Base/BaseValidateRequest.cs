using System;
using System.Text.Json.Serialization;

namespace blazor.models.Requests.Base
{
    public class BaseValidateRequest
    {
        [JsonIgnore]
        public Guid? UserId { get; set; }

        [JsonIgnore]
        public string UniqueId { get; set; }
    }
}