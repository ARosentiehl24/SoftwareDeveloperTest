using Domain.Employee;

namespace Business.Employee.Contract
{
    public interface IEmployeeBusiness
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();

        Task<EmployeeDTO> GetEmployeeById(int id);

        long GetEmployeeAnualSalary(EmployeeDTO employee);
    }
}
