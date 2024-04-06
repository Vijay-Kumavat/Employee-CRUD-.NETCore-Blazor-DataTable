using blazor.models.Constants;
using blazor.models.Responses;

namespace BlazorApp.Helpers
{
    public class EmployeeHelpers : IEmployeeHelpers
    {
        private ICrypto Crypto { get; set; }

        private IDapperRepository DapperRepository { get; set; }

        public EmployeeHelpers(IDapperRepository DapperRepository = null, ICrypto Crypto = null)
        {
            this.DapperRepository = DapperRepository;
            this.Crypto = Crypto;
        }

        public async Task<List<EmployeesResponse>> GetEmployeesList()
        {
            var result = await DapperRepository.GetTableAsync<EmployeesResponse>(SpConsts.Employee.EmployeeList);
            return result.ToList();
        }

        public async Task InsertUpdateEmployee(EmployeesResponse employee)
        {
            await DapperRepository.AddOrUpdateAsync(SpConsts.Employee.InsertOrUpdateEmployee, new
            {
                employee.Id,
                employee.Name,
                employee.Department,
                employee.DOB,
                employee.Gender
            });
        }

        public async Task DeleteEmployee(int id)
        {
            await DapperRepository.AddOrUpdateAsync(
                SpConsts.Employee.DeleteEmployee, new { Id = id });
        }
    }
}
