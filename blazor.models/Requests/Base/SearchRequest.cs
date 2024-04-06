using Newtonsoft.Json;

namespace blazor.models.Requests.Base
{
    public class SearchRequest : DateRangeFilterRequest
    {
        [JsonProperty(PropertyName = "keyword")]
        public string Keyword { get; set; }
    }

    public class DateRangeFilterRequest
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "fromDate")]
        public string FromDate { get; set; }

        [JsonProperty(PropertyName = "toDate")]
        public string ToDate { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int? PageSize { get; set; }

        [JsonProperty(PropertyName = "pageNo")]
        public int? PageNo { get; set; }

        [JsonProperty(PropertyName = "orderBy")]
        public string OrderBy { get; set; }
    }
}