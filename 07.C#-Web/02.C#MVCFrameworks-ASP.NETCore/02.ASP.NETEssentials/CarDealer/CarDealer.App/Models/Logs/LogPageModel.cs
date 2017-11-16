namespace CarDealer.App.Models.Logs
{
    using System.Collections.Generic;
    using Services.Models.Logs;

    public class LogPageModel
    {
        public IEnumerable<LogModel> LogModels { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
