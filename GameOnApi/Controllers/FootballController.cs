﻿using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Football;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/football")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly IFootballManager _manager;

        public FootballController(IFootballManager manager)
        {
            _manager = manager;
        }

        // GET api/football/epl/schedule
        [HttpGet("epl/schedule")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetEplSchedule()
        {
            var schedule = await _manager.GetEplSchedule();

            return Ok(schedule);
        }

        // GET api/football/epl/teams
        [HttpGet("epl/teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public async Task<IActionResult> GetEplTeams()
        {
            var teams = await _manager.GetEplTeams();

            return Ok(teams);
        }

        // GET api/football/champions-league/schedule
        [HttpGet("champions-league/schedule")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetChampionsLeagueSchedule()
        {
            var schedule = await _manager.GetChampionsLeagueSchedule();

            return Ok(schedule);
        }

        // GET api/football/champions-league/teams
        [HttpGet("champions-league/teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public async Task<IActionResult> GetChampionsLeagueTeams()
        {
            var teams = await _manager.GetChampionsLeagueTeams();

            return Ok(teams);
        }

        // GET api/football/europa-league/schedule
        [HttpGet("europa-league/schedule")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetEuropaLeagueSchedule()
        {
            var schedule = await _manager.GetEuropaLeagueSchedule();

            return Ok(schedule);
        }

        // GET api/football/europa-league/teams
        [HttpGet("europa-league/teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public async Task<IActionResult> GetEuropaLeagueTeams()
        {
            var teams = await _manager.GetEuropaLeagueTeams();

            return Ok(teams);
        }
    }
}
