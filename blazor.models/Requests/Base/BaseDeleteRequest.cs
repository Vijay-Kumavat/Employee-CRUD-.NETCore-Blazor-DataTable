using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace blazor.models.Requests.Base
{
    public class BaseDeleteRequest
    {
        [Required(ErrorMessage = "bad_response_Id_required")]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public bool Deleted { get; set; } = true;
    }
}