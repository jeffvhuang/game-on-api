﻿using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Nba;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/nba")]
    [ApiController]
    public class NbaController : ControllerBase
    {
        private readonly INbaManager _manager;

        public NbaController(INbaManager manager)
        {
            _manager = manager;
        }

        // GET api/nba/schedule
        [HttpGet("schedule")]
        [ProducesResponseType(typeof(List<GameVM>), 200)]
        public async Task<IActionResult> GetNbaSchedule()
        {
            var schedule = await _manager.GetNbaSchedule();

            return Ok(schedule);
        }

        // GET api/nba/teams
        [HttpGet("nba/teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public async Task<IActionResult> GetNbaTeams()
        {
            var teams = await _manager.GetNbaTeams();

            return Ok(teams);
        }
    }
}
