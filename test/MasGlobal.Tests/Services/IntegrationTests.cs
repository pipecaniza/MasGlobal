using MasGlobal.Core.Models;
using MasGlobal.Core.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MasGlobal.Tests.Services
{
    public class IntegrationTests
    {
        private static ApiConfiguration _configuration = new ApiConfiguration() {
            RequestUri = "http://masglobaltestapi.azurewebsites.net/api/Employees",
            MediaType = "application/json"
        };

        private static IOptions<ApiConfiguration> GetOptions()
        {
            return Options.Create(_configuration);
        }

        [Fact]
        public async Task GetAllEmployees()
        {
            IEmployeeService service = new EmployeeService(GetOptions());
            var result = await service.GetAllAsync();

            Assert.NotEmpty(result);
        }
    }
}
