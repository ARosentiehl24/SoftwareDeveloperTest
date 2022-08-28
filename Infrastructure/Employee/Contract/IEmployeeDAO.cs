using Domain.Employee;

namespace Infrastructure.Employee.Contract
{
    public interface IEmployeeDAO
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();

        Task<EmployeeDTO> GetEmployeeById(int id);
    }
}
