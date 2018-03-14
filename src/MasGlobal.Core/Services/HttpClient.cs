using MasGlobal.Core.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MasGlobal.Core.Services
{
    public static class HttpClient
    {
        public static async Task<string> GetStringAsync(ApiConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            using (var client = new System.Net.Http.HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue(configuration.MediaType));

                return await client.GetStringAsync(configuration.RequestUri);                
            }
        }
    }
}
