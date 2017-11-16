namespace CarDealer.Services.Models.Sales
{
    public class SalesListModel : SalesModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public bool IsYoungDriver { get; set; }

        public double DiscountPrice => this.Price * this.Discount
            + (this.IsYoungDriver ? 0.5 : 0);
    }
}
