using System;

namespace KillerRobots.Services
{
	public class LocationAPI
	{
		private readonly HttpClient _httpClient;

		public LocationAPI(HttpClient client)
		{
			_httpClient = client;
		}

		public async Task<string> GetLocation(string userquerry)
        {
			HttpResponseMessage webrequest = await _httpClient.GetAsync
				("https://nominatim.openstreetmap.org/reverse?format=json&lat=-32&lon=151.2082848");
            return await webrequest.Content.ReadAsStringAsync();
        }
	}
}

