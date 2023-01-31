
namespace DealerOnTest.Models
{
    public abstract class TaxDecorator : IProduct
    {
        private IProduct product;

        public TaxDecorator(IProduct product)
        {
            this.product = product;
        }

        public virtual double GetPrice(out double taxAmount)
        {
            taxAmount = 0;
            return this.GetPrice();
        }

        public virtual double GetPrice()
        {
            return this.product.GetPrice();
        }

        public virtual bool GetIsImported()
        {
            return this.product.GetIsImported();
        }

        public virtual bool GetIsTaxExempt()
        {
            return this.product.GetIsTaxExempt();
        }

        public virtual double GetQuantity()
        {
            return this.product.GetQuantity();
        }

        public virtual double GetRoundedTax(double value)
        {
            return Math.Ceiling(value / .05) * .05;
        }

        public double CalculateTaxes(double taxPercentage, out double taxAmount)
        {
            var currentPrice = product.GetPrice(out taxAmount);
            double salesTax = this.GetRoundedTax(GetPrice() * taxPercentage);

            taxAmount += salesTax;

            return Math.Round(salesTax + currentPrice, 2);
        }
    }
}
