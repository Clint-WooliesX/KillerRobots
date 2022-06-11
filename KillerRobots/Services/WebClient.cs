using System;

namespace KillerRobots.Services
{
	public class WebRequests
	{
		private readonly HttpClient _httpClient;

		public WebRequests(HttpClient client)
		{
			_httpClient = client;
			_httpClient.DefaultRequestHeaders.Add("User-Agent", "C# app");
		}

		public enum POI { water, hospital, police }

		public async Task<string> GetLocation(string UserQuery, int NumberOfResults, POI searchType)
        {
			string nominatimAPIurl = $"https://nominatim.openstreetmap.org/search?format=json&countrycodes=Au&addressdetails=1&q={searchType}%20near%20";
			string userquery = UserQuery;
			string numberofresults = "&limit=" + NumberOfResults;
			string fullURL = nominatimAPIurl + userquery + numberofresults;
			HttpResponseMessage webrequest = await _httpClient.GetAsync
				(fullURL);
            return await webrequest.Content.ReadAsStringAsync();
        }

		public async Task<string> IPgeolocation()
        {
			HttpResponseMessage webrequest = await _httpClient.GetAsync
				("http://ip-api.com/json/");
			return await webrequest.Content.ReadAsStringAsync();
		}
	}
}

