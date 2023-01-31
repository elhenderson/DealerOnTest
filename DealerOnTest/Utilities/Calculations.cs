using DealerOnTest.Models;

namespace DealerOnTest.Utilities
{
    public class Calculations
    {
        public static Receipt CalculateTotal(List<Product> products)
        {
            double salesTaxes = 0;
            double total = 0;
            var calculatedItems = new List<Product>();
            
            products.ForEach(p =>
            {
                IProduct product = new Product(p);
                TaxDecorator taxDecorator = new TaxedProduct(product);
                taxDecorator = new ImportedProduct(taxDecorator);
                var productPrice = taxDecorator.GetPrice(out double taxAmount);
                total += productPrice;
                salesTaxes += taxAmount;

                if (IsDuplicateProduct(p, calculatedItems))
                {
                    var duplicateProduct = calculatedItems.Where(ci => ci.Name == p.Name).First();
                    duplicateProduct.Quantity++;
                    duplicateProduct.Price += productPrice;
                }
                else
                {
                    var newItem = new Product(p.Name, productPrice, p.UnitPrice, p.IsImported, p.IsTaxExempt, p.Quantity);
                    calculatedItems.Add(newItem);
                }
            });

            return new Receipt(calculatedItems, Math.Round(salesTaxes, 2), Math.Round(total, 2));
        }

        public static bool IsDuplicateProduct(Product p, List<Product> calculatedItems)
        {
            return calculatedItems.Select(ci => ci.Name).Contains(p.Name);
        }
    }
}
