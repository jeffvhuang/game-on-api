﻿using com.gameon.data.Database.Interfaces;
using com.gameon.data.Database.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace com.gameon.data.Database.Repositories
{
    public class DotaRepository : MongoBaseRepository<Dota>, IDotaRepository
    {
        public DotaRepository(IConfiguration config) : base(config) { }

        public List<Dota> GetAll()
        {
            return GetAllBy(doc => true)
                .SortByDescending(doc => doc.StartDate)
                .ThenByDescending(doc => doc.EndDate)
                .ToList();
        }
    }
}
