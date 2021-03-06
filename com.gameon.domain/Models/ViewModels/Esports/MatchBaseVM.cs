﻿using com.gameon.data.ThirdPartyApis.Models.Esports;
using System;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class MatchBaseVM
    {
        public int? WinnerId { get; set; }
        public int TournamentId { get; set; }
        public string Status { get; set; }
        public string Slug { get; set; }
        public int NumberOfGames { get; set; }
        public string Name { get; set; }
        public string MatchType { get; set; }
        public LiveVM Live { get; set; }
        public int Id { get; set; }
        public bool Forfeit { get; set; }
        public DateTime? EndAt { get; set; }
        public bool Draw { get; set; }
        public DateTime? BeginAt { get; set; }

        public MatchBaseVM() { }
    }
}
