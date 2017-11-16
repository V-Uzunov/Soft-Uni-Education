namespace CarDealer.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Logs;

    public class LogServices : ILogServices
    {
        private readonly CarDealerDbContext db;
        private const int PageSize = 5;
        public LogServices(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LogModel> All(int page = 1, int pageSize = 5)
        =>this.db
                .Logs
                .OrderByDescending(c => c.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(l => new LogModel
                {
                    User = l.User,
                    ModifiedTable = l.ModifiedTable,
                    Operation = l.Operation,
                    Time = l.Time
                })
                .ToList();

        public void AddLog(string user, string operation, string modifiedTable, DateTime time)
        {
            var log = new Log
            {
                User = user,
                ModifiedTable = modifiedTable,
                Operation = operation,
                Time = time
            };

            this.db.Logs.Add(log);
            this.db.SaveChanges();
        }

        public void Clear()
            => this.db
                .Database
                .ExecuteSqlCommand("TRUNCATE TABLE[Logs]");

        public int Total() => this.db.Logs.Count();
    }
}
