namespace CarDealer.Services.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ICarServices
    {
        void Create(string model, string make, long travelledDistance);

        ICollection<CarByMake> AllCarsByMakes(string make);

        ICollection<CarByMake> All(int page = 1, int pageSize = 10);

        ICollection<CarsWithPartsModel> CarWithParts(string id);

        int Total();
    }
}
