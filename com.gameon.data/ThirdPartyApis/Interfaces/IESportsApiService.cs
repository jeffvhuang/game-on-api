﻿using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IEsportsApiService
    {
        Task<List<Tournament>> GetTournaments(string game = null, string timeFrame = null);
        Task<List<Team>> GetTeams(string game);
        Task<List<Series>> GetSeries(string game);
        Task<List<Match>> GetMatches(string game = null, string timeFrame = null);
        Task<List<Match>> GetTournamentMatches(string game, int tournamentId, string timeFrame = null);
    }
}
