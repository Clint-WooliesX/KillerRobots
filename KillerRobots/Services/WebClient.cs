using System;

namespace KillerRobots.Services
{
	public class LocationAPI
	{
		private readonly HttpClient _httpClient;

		public LocationAPI(HttpClient client)
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
	}
}

