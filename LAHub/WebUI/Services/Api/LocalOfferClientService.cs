﻿using Application.Commands.GetServices;
using Application.Commands.TestCommand;
using Application.Common.Models;
using Application.Models;
using SFA.DAS.HashingService;
using System.Text;
using System.Text.Json;

namespace WebUI.Services.Api
{
    public interface ILocalOfferClientService
    {
        Task<PaginatedList<ServiceItem>> GetLocalOffers(double latitude, double logtitude, double meters);
        Task<PaginatedList<TestItem>> GetTestCommand(double latitude, double logtitude, double meters);
    }

    public class LocalOfferClientService : ApiService, ILocalOfferClientService
    {
        public LocalOfferClientService(HttpClient client, IHashingService hashingService)
            : base(client, hashingService)
        {
            
        }

        public async Task<PaginatedList<ServiceItem>> GetLocalOffers(double latitude, double logtitude, double meters)
        {
            GetServicesByDistanceCommand command = new(latitude, logtitude, meters);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_client.BaseAddress + "api/GetServicesByDistance"),
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
            };

            using var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
            return await JsonSerializer.DeserializeAsync<PaginatedList<ServiceItem>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.
            
        }

        public async Task<PaginatedList<TestItem>> GetTestCommand(double latitude, double logtitude, double meters)
        {
            GetServicesByDistanceCommand command = new(latitude, logtitude, meters);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_client.BaseAddress + "api/GetTestCommand"),
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"),
            };

            using var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

#pragma warning disable CS8603 // Possible null reference return.
            return await JsonSerializer.DeserializeAsync<PaginatedList<TestItem>>(await response.Content.ReadAsStreamAsync(), options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
#pragma warning restore CS8603 // Possible null reference return.

        }
    }
}
