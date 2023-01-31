using DealerOnTest.Models;
using DealerOnTest.Utilities;
using Newtonsoft.Json;

namespace DealerOnCodeTest.Tests
{
    public class Tests
    {
        [Fact]
        public void ThreeTaxFree_OneTax()
        {
            var input = new List<Product>()
            {
                new Product("Book", price: 12.49, unitPrice: 12.49, isImported: false, isTaxExempt: true, 1),
                new Product("Book", price: 12.49, unitPrice: 12.49, isImported: false, isTaxExempt: true, 1),
                new Product("Music CD", price: 14.99, unitPrice: 14.99, isImported: false, isTaxExempt: false, 1),
                new Product("Chocolate bar", price: 0.85, unitPrice: 0.85, isImported: false, isTaxExempt: true, 1)
            };

            var actual = Calculations.CalculateTotal(input);

            var expectedProducts = new List<Product>()
            {
                new Product("Book", price: 24.98, unitPrice: 12.49, isImported: false, isTaxExempt: true, 2),
                new Product("Music CD", price: 16.49, unitPrice: 14.99, isImported: false, isTaxExempt: false, 1),
                new Product("Chocolate bar", price: 0.85, unitPrice: 0.85, isImported: false, isTaxExempt: true, 1)
            };
            Assert.Equal(
                JsonConvert.SerializeObject(new Receipt(expectedProducts, 1.50, 42.32)),
                JsonConvert.SerializeObject(actual)
            );
        }

        [Fact]
        public void TwoImport_OneTax()
        {
            var input = new List<Product>()
            {
                new Product("Imported box of chocolates", price: 10.00, unitPrice: 10.00, isImported: true, isTaxExempt: true, 1),
                new Product("Imported bottle of perfume", price: 47.50, unitPrice: 47.50, isImported: true, isTaxExempt: false, 1)
            };


            var actual = Calculations.CalculateTotal(input);


            var expectedProducts = new List<Product>()
            {
                new Product("Imported box of chocolates", price: 10.50, unitPrice: 10.00, isImported: true, isTaxExempt: true, 1),
                new Product("Imported bottle of perfume", price: 54.65, unitPrice: 47.50, isImported: true, isTaxExempt: false, 1)
            };
            Assert.Equal(
                JsonConvert.SerializeObject(new Receipt(expectedProducts, 7.65, 65.15)),
                JsonConvert.SerializeObject(actual)
            );
        }

        [Fact]
        public void ThreeImports_TwoTax()
        {
            var input = new List<Product>()
            {
                new Product("Imported bottle of perfume", price: 27.99, unitPrice: 27.99, isImported: true, isTaxExempt: false, 1),
                new Product("Bottle of perfume", price: 18.99, unitPrice: 18.99, isImported: false, isTaxExempt: false, 1),
                new Product("Packet of headache pills", price: 9.75, unitPrice: 9.75, isImported: false, isTaxExempt: true, 1),
                new Product("Imported box of chocolates", price: 11.25, unitPrice: 11.25, isImported: true, isTaxExempt: true, 1),
                new Product("Imported box of chocolates", price: 11.25, unitPrice: 11.25, isImported: true, isTaxExempt: true, 1)
            };

            var actual = Calculations.CalculateTotal(input);

            var expectedProducts = new List<Product>()
            {
                new Product("Imported bottle of perfume", price: 32.19, unitPrice: 27.99, isImported: true, isTaxExempt: false, 1),
                new Product("Bottle of perfume", price: 20.89, unitPrice: 18.99, isImported: false, isTaxExempt: false, 1),
                new Product("Packet of headache pills", price: 9.75, unitPrice: 9.75, isImported: false, isTaxExempt: true, 1),
                new Product("Imported box of chocolates", price: 23.70, unitPrice: 11.25, isImported: true, isTaxExempt: true, 2)
            };
            Assert.Equal(
                JsonConvert.SerializeObject(new Receipt(expectedProducts, 7.30, 86.53)),
                JsonConvert.SerializeObject(actual)
            );
        }
    }
}