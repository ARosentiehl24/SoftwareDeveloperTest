using Domain.Employee;
using Infrastructure.Employee.Contract;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Employee
{
    public class EmployeeDAO : IEmployeeDAO
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public EmployeeDAO(IConfiguration configuration,IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            string baseUrl = _configuration.GetSection("BaseUrl").Value;

            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{baseUrl}/employee/{id}");
            responseMessage.EnsureSuccessStatusCode();

            string data = await responseMessage.Content.ReadAsStringAsync();

            EmployeeResponseDTO? result = JsonConvert.DeserializeObject<EmployeeResponseDTO>(data);

            return result!.Data!;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            string baseUrl = _configuration.GetSection("BaseUrl").Value;

            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{baseUrl}/employees");
            responseMessage.EnsureSuccessStatusCode();

            string data = await responseMessage.Content.ReadAsStringAsync();

            EmployeesResponseDTO? result = JsonConvert.DeserializeObject<EmployeesResponseDTO>(data);

            return result!.Data!;
        }
    }
}
