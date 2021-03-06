﻿using Newtonsoft.Json;
using System;

namespace com.gameon.data.ThirdPartyApis.Models.Football
{

    public class Fixture
    {
        [JsonProperty("fixture_id")]
        public int? FixtureId { get; set; }

        [JsonProperty("league_id")]
        public int? LeagueId { get; set; }

        [JsonProperty("event_date")]
        public DateTime? EventDate { get; set; }

        [JsonProperty("event_timestamp")]
        public int? EventTimestamp { get; set; }

        [JsonProperty("firstHalfStart")]
        public int? FirstHalfStart { get; set; }

        [JsonProperty("secondHalfStart")]
        public int? SecondHalfStart { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        // FT = full time, TBD = to be defined, PST = postponed, NS = not started, FH/SH = first/second half
        [JsonProperty("statusShort")]
        public string StatusShort { get; set; }

        [JsonProperty("elapsed")]
        public int? Elapsed { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("referee")]
        public object Referee { get; set; }

        [JsonProperty("homeTeam")]
        public FootballTeamBase HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public FootballTeamBase AwayTeam { get; set; }

        [JsonProperty("goalsHomeTeam")]
        public int? GoalsHomeTeam { get; set; }

        [JsonProperty("goalsAwayTeam")]
        public int? GoalsAwayTeam { get; set; }

        [JsonProperty("score")]
        public Score Score { get; set; }
    }
}
