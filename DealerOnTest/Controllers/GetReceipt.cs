using DealerOnTest.Models;
using DealerOnTest.Utilities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOnTest.Controllers
{
    public class GetReceipt
    {
        public class GetReceiptRequest : IRequest<GetReceiptResponse>
        {
            public List<Product> Products { get; set; }
        }


        public class GetReceiptResponse
        {
            public Receipt Receipt { get; set; }
        }

        public class GetReceiptHandler : IRequestHandler<GetReceiptRequest, GetReceiptResponse>
        {

            public GetReceiptHandler() { }
            public async Task<GetReceiptResponse> Handle(GetReceiptRequest request, CancellationToken cancellationToken)
            {
                var response = Calculations.CalculateTotal(request.Products);
                return new GetReceiptResponse() { Receipt = response };
            }
        }
    }
}
