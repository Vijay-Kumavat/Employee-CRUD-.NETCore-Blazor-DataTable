using blazor.models.Requests;
using blazor.models.Requests.Base;
using blazor.models.Responses;

namespace BlazorApp.Helper
{
    public interface IEmployeeHelpers
    {
        Task<List<EmployeesResponse>> GetEmployeesList();

        Task InsertUpdateEmployee(EmployeesResponse employee);

        Task DeleteEmployee(int id);
    }
}
