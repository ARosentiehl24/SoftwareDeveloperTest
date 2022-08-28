using Infrastructure.Employee.Contract;
using Infrastructure.Employee;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace Infrastructure
{
    public static class InfrastructureExtension
    {
        public static void AddEmployeeInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddTransient<IEmployeeDAO, EmployeeDAO>();
        }
    }
}
