using Business.Employee;
using Business.Employee.Contract;
using Domain.Employee;
using Infrastructure.Employee;
using Infrastructure.Employee.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTest
{
    public class Tests
    {
        private readonly IEmployeeBusiness? _employeeBusiness;

        public Tests()
        {
            ServiceCollection services = new();

            services.AddHttpClient();
            services.AddTransient<IConfiguration>(options =>
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("appsettings.json");
                return configurationBuilder.Build();
            });
            services.AddTransient<IEmployeeBusiness, EmployeeBusiness>();
            services.AddTransient<IEmployeeDAO, EmployeeDAO>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            _employeeBusiness = serviceProvider.GetService<IEmployeeBusiness>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEmployeeById()
        {
            var fakeUserId = 1;

            EmployeeDTO result = _employeeBusiness!.GetEmployeeById(fakeUserId).Result;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetEmployees()
        {
            IEnumerable<EmployeeDTO> result = _employeeBusiness!.GetEmployees().Result;

            Assert.That(result, Is.Not.Null);
        }
    }
}