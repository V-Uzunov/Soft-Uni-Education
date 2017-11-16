namespace CarDealer.Services.Models
{
    using System.Collections.Generic;
    using Parts;

    public class CarsWithPartsModel : CarByMake
    {
        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
