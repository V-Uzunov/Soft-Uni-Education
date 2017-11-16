namespace _04.ShopHierarchy
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int SalesmanId { get; set; }
        public Salesman Salesman { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
