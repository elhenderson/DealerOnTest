namespace DealerOnTest.Models
{
    public interface IProduct
    {
        public double GetPrice();
        public double GetPrice(out double salesTax);
        public bool GetIsImported();
        public bool GetIsTaxExempt();
        public double GetQuantity();
    }
}