namespace CarDealer.Services.Interfaces
{
    using Models.Sales;
    using System.Collections.Generic;

    public interface ISalesServices
    {
        IEnumerable<SalesListModel> All();

        IEnumerable<SalesDetailModel> Details(int id);
    }
}
