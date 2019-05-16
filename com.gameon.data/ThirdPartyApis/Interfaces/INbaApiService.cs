﻿using com.gameon.data.ThirdPartyApis.Models.Nba;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface INbaApiService
    {
        Task<List<Game>> GetNbaSchedule();
        Task<List<Team>> GetNbaTeams();
    }
}
