using Business.Employee;
using Business.Employee.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessExtension
    {
        public static void AddEmployeeBusiness(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeBusiness, EmployeeBusiness>();
        }
    }
}
