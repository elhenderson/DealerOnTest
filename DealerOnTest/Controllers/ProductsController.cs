using DealerOnTest.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static DealerOnTest.Models.Product;

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
            try
            {
                var model = new GetReceipt.GetReceiptRequest()
                {
                    Products = JsonConvert.DeserializeObject<List<Product>>(request.ToString())
                };


                var response = await mediator.Send(model);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); 
            }
        }
    }
}
