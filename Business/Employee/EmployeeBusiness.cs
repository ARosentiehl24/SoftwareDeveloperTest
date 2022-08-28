using Business.Employee.Contract;
using Domain.Employee;
using Infrastructure.Employee.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Employee
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeDAO _employeeDAO;

        public EmployeeBusiness(IEmployeeDAO employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }

        public long GetEmployeeAnualSalary(EmployeeDTO employee)
        {
            return employee.EmployeeSalary!.Value * 12;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            return await _employeeDAO.GetEmployeeById(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            return await _employeeDAO.GetEmployees();
        }
    }
}
