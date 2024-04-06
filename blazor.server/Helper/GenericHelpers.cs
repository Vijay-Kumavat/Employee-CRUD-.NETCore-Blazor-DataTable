using blazor.dapper;

namespace blazor.api.Helpers
{
    public class GenericHelpers 
    {
        public IDapperRepository DapperRepository { get; set; }

        public GenericHelpers(
            IDapperRepository DapperRepository = null,
            string Connection = null)
        {
            this.DapperRepository = DapperRepository;
        }

        public int CalculateTotalPages(
            dynamic total,
            int? pageSize)
        {
            var pages = Convert.ToDecimal(total) / pageSize;
            var response = pages < 1 ? 1 : Convert.ToInt32(Math.Ceiling(pages));

            return response;
        }
    }
}