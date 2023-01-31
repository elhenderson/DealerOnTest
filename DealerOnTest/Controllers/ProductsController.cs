using DealerOnTest.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOnTest.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> GetProductsTotal([FromBody] object request)
        {

            var model = new GetReceipt.GetReceiptRequest()
            {
                Products = JsonConvert.DeserializeObject<List<Product>>(request.ToString())
            };

            var receipt = await mediator.Send(model);
            return Ok(receipt);
        }
    }
}
