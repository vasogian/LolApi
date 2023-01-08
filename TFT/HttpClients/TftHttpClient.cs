using LolApi.Models;

namespace TFT.Services
{
    public class TftHttpClient
    {
        private readonly HttpClient _httpClient;
        public TftHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LeagueEntryDTO>> GetSummonerEntry(string summonerId)
        {
            var httpResponse = await _httpClient.GetAsync($"/tft/league/v1/entries/by-summoner/{summonerId}");
            if(httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync <List<LeagueEntryDTO>>();
            }
            return new List<LeagueEntryDTO>();
        }
    }
}
