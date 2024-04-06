using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace blazor.models.Requests.Base
{
    public class BaseUpdateStatusRequest
    {
        [Required(ErrorMessage = "bad_response_Id_required")]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "bad_response_active_required")]
        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}