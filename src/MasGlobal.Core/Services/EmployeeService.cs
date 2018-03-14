using MasGlobal.Core.DTOs;
using MasGlobal.Core.Helpers;
using MasGlobal.Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        protected readonly ApiConfiguration _configuration;

        public EmployeeService(IOptions<ApiConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var result = await HttpClient.GetStringAsync(_configuration);
            var employees = JsonConvert.DeserializeObject<List<Employee>>(result);
            return employees.ConvertListToDTO();
        }
    }
}
