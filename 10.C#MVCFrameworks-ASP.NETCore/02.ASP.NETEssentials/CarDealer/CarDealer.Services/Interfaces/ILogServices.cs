namespace CarDealer.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models.Logs;

    public interface ILogServices
    {
        IEnumerable<LogModel> All(int page = 1, int pageSize = 5);

        void AddLog(string user, string operation, string modifiedTable, DateTime time);

        void Clear();
        int Total();
    }
}