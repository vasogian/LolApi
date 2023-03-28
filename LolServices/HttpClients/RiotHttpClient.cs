using LolApi.Database.Models;
using LolApi.Models;
using System.Net.Http.Json;

namespace LolApi.HttpClients
{
    public class RiotHttpClient
    {
        private readonly HttpClient _httpClient;
        public RiotHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SummonerDTO> GetSummonerByName(string name)
        {
            var httpResponse = await _httpClient.GetAsync($"/lol/summoner/v4/summoners/by-name/{name}");

            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<SummonerDTO>();
            }
            return new SummonerDTO();
        }
        public async Task<List<ChampionMasteryDto>> GetChampionMasteryPts(string encryptedSummonerId, int count = 3)
        {
            var HttpResponse = await _httpClient.GetAsync($"/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}/top?count={count}");

            if (HttpResponse.IsSuccessStatusCode)
            {
                return await HttpResponse.Content.ReadFromJsonAsync<List<ChampionMasteryDto>>();
            }
            return new List<ChampionMasteryDto>();
        }
        public async Task<List<LeagueEntryDTO>> GetLeagueEntries(string encryptedSummonerId)
        {
            var clientResponse = await _httpClient.GetAsync($"/lol/league/v4/entries/by-summoner/{encryptedSummonerId}");

            if (clientResponse.IsSuccessStatusCode)
            {
                return await clientResponse.Content.ReadFromJsonAsync<List<LeagueEntryDTO>>();
            }
            return new List<LeagueEntryDTO>();
        }
        public async Task<List<PlayerDTO>> GetClashPlayer(string summonerId)
        {

            var httpResponse = await _httpClient.GetAsync($"/lol/clash/v1/players/by-summoner/{summonerId}");

            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<List<PlayerDTO>>();
            }
            return new List<PlayerDTO>();

        }
        public async Task<CurrentGameInfo> GetCurrentGameInfo(string summonerId)
        {
            var httpResponse = await _httpClient.GetAsync($"/lol/spectator/v4/active-games/by-summoner/{summonerId}");

            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<CurrentGameInfo>();
            }
            return new CurrentGameInfo();
        }

        public async Task<List<string>> GetMatchHistory(string puuid, int start = 0, int count = 20)
        {
            var httpResponse = await _httpClient.GetAsync($"https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/{puuid}/ids?start={start}&count={count}");

            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<List<string>>();
            }
            return new List<string>();
        }
        public async Task<List<LeagueEntryDTO>> GetTftEntry(string summonerId)
        {
            var httpResponse = await _httpClient.GetAsync($"/tft/league/v1/entries/by-summoner/{summonerId}");
            if(httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<List<LeagueEntryDTO>>();
            }
            return new List<LeagueEntryDTO>();
        }
        public async Task<LeagueListDTO> GetChallLeague()
        {
            var httpResponse = await _httpClient.GetAsync("/tft/league/v1/challenger");
            if(httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<LeagueListDTO>();
            }
            return new LeagueListDTO();
        }
        public async Task<List<string>> GetTftMatchHistory(string puuid, int count = 20)
        {
            var response = await _httpClient.GetAsync($"https://europe.api.riotgames.com/tft/match/v1/matches/by-puuid/{puuid}/ids?count={count}");
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<string>>();
            }
            return new List<string>();
        }
    }


}

