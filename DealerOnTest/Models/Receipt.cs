
namespace DealerOnTest.Models
{
    public class Receipt
    {
        public List<Product> Products { get; set; }
        public double SalesTax { get; set; }
        public double Total { get; set; }

        public Receipt(List<Product> products, double salesTax, double total)
        {
            Products = products;
            SalesTax = salesTax;
            Total = total;
        }
    }
}
