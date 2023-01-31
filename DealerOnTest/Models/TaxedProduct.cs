
namespace DealerOnTest.Models
{
    public class TaxedProduct : TaxDecorator
    {
        private IProduct product;
        public TaxedProduct(IProduct product) : base(product)
        {
            this.product = product;
        }

        public override double GetPrice(out double taxAmount)
        {
            if (!product.GetIsTaxExempt())
            {
                return CalculateTaxes(.10, out taxAmount);
            }

            return product.GetPrice(out taxAmount);
        }
    }
}
