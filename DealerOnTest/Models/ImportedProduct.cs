
namespace DealerOnTest.Models
{
    public class ImportedProduct : TaxDecorator
    {
        private IProduct product;
        public ImportedProduct(IProduct product) : base(product)
        {
            this.product = product;
        }
        public override double GetPrice(out double taxAmount)
        {
            if (product.GetIsImported())
            {
                return CalculateTaxes(.05, out taxAmount);
            }

            return product.GetPrice(out taxAmount);
        }
    }
}
