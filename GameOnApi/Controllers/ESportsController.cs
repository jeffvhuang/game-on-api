﻿using com.gameon.domain.Interfaces;
using com.gameon.domain.Models.ViewModels.Esports;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class EsportsController : ControllerBase
    {
        private readonly IEsportsManager _manager;

        public EsportsController(IEsportsManager manager)
        {
            _manager = manager;
        }

        // GET api/esports/tournaments
        [HttpGet("esports/tournaments")]
        [ProducesResponseType(typeof(List<EsportsTournamentVM>), 200)]
        public async Task<IActionResult> GetEsportsTournaments([FromQuery] string timeFrame)
        {
            List<EsportsTournamentVM> tournaments = await _manager.GetTournamentsAsync(timeFrame: timeFrame);

            return Ok(tournaments);
        }

        // GET api/esports/matches
        [HttpGet("esports/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetEsportsMatches([FromQuery] string timeFrame)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches = await _manager.GetMatchesAsync(timeFrame: timeFrame);

            return Ok(matches);
        }

        // GET api/dota/tournaments
        [HttpGet("dota/tournaments")]
        [ProducesResponseType(typeof(List<EsportsTournamentVM>), 200)]
        public async Task<IActionResult> GetDotaTournaments([FromQuery] string seriesId = null)
        {
            var tournaments = await _manager.GetTournamentsAsync("Dota2", seriesId: seriesId);
            return Ok(tournaments);
        }

        // GET api/dota/teams
        [HttpGet("dota/teams")]
        [ProducesResponseType(typeof(List<EsportsTeamVM>), 200)]
        public async Task<IActionResult> GetDotaTeams()
        {
            var teams = await _manager.GetTeamsAsync("Dota2");

            return Ok(teams);
        }

        // GET api/dota/series
        [HttpGet("dota/series")]
        [ProducesResponseType(typeof(List<SeriesVM>), 200)]
        public async Task<IActionResult> GetDotaSeries([FromQuery] string rangeBegin = null, [FromQuery] string rangeEnd = null)
        {
            var ranges = new List<string>();
            if (rangeBegin != null) ranges.Add(rangeBegin);
            if (rangeEnd != null) ranges.Add(rangeEnd);

            var series = await _manager.GetSeriesAsync("Dota2", ranges);

            return Ok(series);
        }

        // GET api/dota/matches
        [HttpGet("dota/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetDotaMatches([FromQuery] int? tournamentId)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches;
            if (tournamentId.HasValue) matches = await _manager.GetMatchesAsync("Dota2", tournamentId);
            else matches = await _manager.GetMatchesAsync("Dota2");

            return Ok(matches);
        }

        // GET api/lol/tournaments?seriesId=2337
        [HttpGet("lol/tournaments")]
        [ProducesResponseType(typeof(List<EsportsTournamentVM>), 200)]
        public async Task<IActionResult> GetLolTournaments([FromQuery] string seriesId = null)
        {
            var tournaments = await _manager.GetTournamentsAsync("LoL", seriesId: seriesId);

            return Ok(tournaments);
        }

        // GET api/lol/teams
        [HttpGet("lol/teams")]
        [ProducesResponseType(typeof(List<EsportsTeamVM>), 200)]
        public async Task<IActionResult> GetLolTeams()
        {
            var teams = await _manager.GetTeamsAsync("LoL");

            return Ok(teams);
        }

        // GET api/lol/series
        [HttpGet("lol/series")]
        [ProducesResponseType(typeof(List<SeriesVM>), 200)]
        public async Task<IActionResult> GetLolSeries([FromQuery] string rangeBegin = null, [FromQuery] string rangeEnd = null)
        {
            var ranges = new List<string>();
            if (rangeBegin != null) ranges.Add(rangeBegin);
            if (rangeEnd != null) ranges.Add(rangeEnd);

            var series = await _manager.GetSeriesAsync("LoL", ranges);

            return Ok(series);
        }

        // GET api/lol/matches
        [HttpGet("lol/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetLolMatches([FromQuery] int? tournamentId)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches;
            if (tournamentId.HasValue) matches = await _manager.GetMatchesAsync("LoL", tournamentId);
            else matches = await _manager.GetMatchesAsync("LoL");

            return Ok(matches);
        }

        // GET api/overwatch/tournaments
        [HttpGet("overwatch/tournaments")]
        [ProducesResponseType(typeof(List<EsportsTournamentVM>), 200)]
        public async Task<IActionResult> GetOverwatchTournaments([FromQuery] string seriesId = null)
        {
            var tournaments = await _manager.GetTournamentsAsync("Overwatch", seriesId: seriesId);

            return Ok(tournaments);
        }

        // GET api/overwatch/teams
        [HttpGet("overwatch/teams")]
        [ProducesResponseType(typeof(List<EsportsTeamVM>), 200)]
        public async Task<IActionResult> GetOverwatchTeams()
        {
            var teams = await _manager.GetTeamsAsync("Overwatch");

            return Ok(teams);
        }

        // GET api/overwatch/series
        [HttpGet("overwatch/series")]
        [ProducesResponseType(typeof(List<SeriesVM>), 200)]
        public async Task<IActionResult> GetOverwatchSeries([FromQuery] string rangeBegin = null, [FromQuery] string rangeEnd = null)
        {
            var ranges = new List<string>();
            if (rangeBegin != null) ranges.Add(rangeBegin);
            if (rangeEnd != null) ranges.Add(rangeEnd);

            var series = await _manager.GetSeriesAsync("Overwatch", ranges);

            return Ok(series);
        }

        // GET api/overwatch/matches
        [HttpGet("overwatch/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetOverwatchMatches([FromQuery] int? tournamentId)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches;
            if (tournamentId.HasValue) matches = await _manager.GetMatchesAsync("Overwatch", tournamentId);
            else matches = await _manager.GetMatchesAsync("Overwatch");

            return Ok(matches);
        }

        // GET api/csgo/tournaments
        [HttpGet("csgo/tournaments")]
        [ProducesResponseType(typeof(List<EsportsTournamentVM>), 200)]
        public async Task<IActionResult> GetCsgoTournaments([FromQuery] string seriesId = null)
        {
            var tournaments = await _manager.GetTournamentsAsync("CS:GO", seriesId: seriesId);

            return Ok(tournaments);
        }

        // GET api/csgo/teams
        [HttpGet("csgo/teams")]
        [ProducesResponseType(typeof(List<EsportsTeamVM>), 200)]
        public async Task<IActionResult> GetCsgoTeams()
        {
            var teams = await _manager.GetTeamsAsync("CS:GO");

            return Ok(teams);
        }

        // GET api/csgo/series
        [HttpGet("csgo/series")]
        [ProducesResponseType(typeof(List<SeriesVM>), 200)]
        public async Task<IActionResult> GetCsgoSeries([FromQuery] string rangeBegin = null, [FromQuery] string rangeEnd = null)
        {
            var ranges = new List<string>();
            if (rangeBegin != null) ranges.Add(rangeBegin);
            if (rangeEnd != null) ranges.Add(rangeEnd);

            var series = await _manager.GetSeriesAsync("CS:GO", ranges);

            return Ok(series);
        }

        // GET api/csgo/matches
        [HttpGet("csgo/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetCsgoMatches([FromQuery] int? tournamentId)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches;
            if (tournamentId.HasValue) matches = await _manager.GetMatchesAsync("CS:GO", tournamentId);
            else matches = await _manager.GetMatchesAsync("CS:GO");

            return Ok(matches);
        }
    }
}
