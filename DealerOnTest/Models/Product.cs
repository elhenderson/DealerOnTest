
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace DealerOnTest.Models
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double UnitPrice { get; set; }
        public bool IsImported { get; set; }
        public bool IsTaxExempt { get; set; }
        public int Quantity { get; set; }

        [JsonConstructor]
        public Product(string name, double price, double unitPrice, bool isImported, bool isTaxExempt, int quantity)
        {
            Name = name;
            Price = price;
            UnitPrice = unitPrice;
            IsImported = isImported;
            IsTaxExempt = isTaxExempt;
            Quantity = quantity;

            try
            {
                var productValidator = new ProductValidator();
                productValidator.ValidateAndThrow(this);
            }
            catch
            {
                throw;
            }
        }

        public Product(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            UnitPrice = product.UnitPrice;
            IsImported = product.IsImported;
            IsTaxExempt = product.IsTaxExempt;
            Quantity = product.Quantity;
        }

        public class ProductValidator : AbstractValidator<Product>
        {
            public ProductValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Price).NotNull();
                RuleFor(x => x.UnitPrice).NotNull();
                RuleFor(x => x.IsImported).NotNull();
                RuleFor(x => x.IsTaxExempt).NotNull();
                RuleFor(x => x.Quantity).NotEmpty();
            }
        }

        public double GetPrice()
        {
            return this.Price;
        }
        public double GetPrice(out double salesTax)
        {
            salesTax = 0;
            return this.GetPrice();
        }

        public bool GetIsImported()
        {
            return this.IsImported;
        }

        public bool GetIsTaxExempt()
        {
            return this.IsTaxExempt;
        }

        public double GetQuantity()
        {
            return this.Quantity;
        }
    }
}
