﻿using AutoMapper;
using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Esports;
using com.gameon.domain.Interfaces;
using com.gameon.domain.Models.ViewModels.Esports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class EsportsManager : IEsportsManager
    {
        private readonly IEsportsApiService _service;
        private readonly IMapper _mapper;
        public EsportsManager(IEsportsApiService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<EsportsTournamentVM>> GetTournamentsAsync(string game = null, string timeFrame = null, string seriesId = null)
        {
            List<EsportsTournament> tournaments = await _service.GetTournamentsAsync(game, timeFrame, seriesId);

            var tournamentVMs = new List<EsportsTournamentVM>();
            foreach (var t in tournaments)
                tournamentVMs.Add(_mapper.Map<EsportsTournamentVM>(t));
            
            return tournamentVMs;
        }

        public async Task<List<EsportsTeamVM>> GetTeamsAsync(string game)
        {
            var teams = await _service.GetTeamsAsync(game);

            var teamVMs = new List<EsportsTeamVM>();
            foreach (var t in teams)
                teamVMs.Add(_mapper.Map<EsportsTeamVM>(t));

            return teamVMs;
        }

        // Ranges in format yyyy-mm-dd
        public async Task<List<SeriesVM>> GetSeriesAsync(string game, List<string> range = null)
        {
            var rangeDatetimes = (range != null && range.Count > 0) ? GetRangeAsDateTimes(range) : null;
            var series = await _service.GetSeriesAsync(game, rangeDatetimes);

            var seriesVM = new List<SeriesVM>();
            // Due to api sort by descending starts with null dates, must not return the beginning few objects
            if (series.Count > 0)
            {
                var indexFirst = series.FindIndex(x => !(x.BeginAt == null && x.EndAt == null));
                for (int i = indexFirst; i < series.Count; i++)
                    seriesVM.Add(_mapper.Map<SeriesVM>(series[i]));
            }

            return seriesVM;
        }

        // Get matches for specified game or all, game and tournament and either with a specified timeframe (eg. "upcoming")
        public async Task<List<MatchVM>> GetMatchesAsync(string game = null, int? tournamentId = null, string timeFrame = null)
        {
            // Determine whether to get most recent matches for the game or for a specific tournament
            List<Match> matches;

            if (game == null) matches = await _service.GetMatchesAsync(timeFrame: timeFrame);
            else if (tournamentId.HasValue) matches = await _service.GetTournamentMatchesAsync(game, tournamentId.Value, timeFrame);
            else matches = await _service.GetMatchesAsync(game, timeFrame: timeFrame);

            // Convert to view model
            var matchVM = new List<MatchVM>();
            foreach (var t in matches) matchVM.Add(_mapper.Map<MatchVM>(t));

            return matchVM;
        }

        private List<DateTime> GetRangeAsDateTimes(List<string> range)
        {
            var rangeDatetime = new List<DateTime>();

            try
            {
                foreach (var date in range)
                {
                    var year = int.Parse(date.Substring(0, 4));
                    var month = int.Parse(date.Substring(5, 2));
                    var day = int.Parse(date.Substring(8, 2));
                    var dt = new DateTime(year, month, day);
                    rangeDatetime.Add(dt);
                }
                return rangeDatetime;
            }
            catch
            {
                throw new Exception("Range dates should be in format yyyy-mm-dd");
            }
        }
    }
}
