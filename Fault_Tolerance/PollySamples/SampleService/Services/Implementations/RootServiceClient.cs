﻿using RootServiceReference;

namespace SampleService.Services.Implementations
{
    public class RootServiceClient : IRootServiceClient
    {

        #region Services

        private readonly ILogger<RootServiceClient> _logger;
        private readonly RootServiceReference.RootServiceClient _httpClient;

        #endregion

        public RootServiceClient(HttpClient httpClient,
            ILogger<RootServiceClient> logger)
        {
            _logger = logger;
            _httpClient = new RootServiceReference.RootServiceClient("http://localhost:5032/",httpClient);
        }

        public RootServiceReference.RootServiceClient Client => _httpClient;

        public async Task<ICollection<RootServiceReference.WeatherForecast>> Get()
        {
            return await _httpClient.GetWeatherForecastAsync();
        }
    }
}
