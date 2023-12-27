using MicroservicesWithCQRSDesignPattern.Interfaces;
using MicroservicesWithCQRSDesignPattern.Model;
using MicroservicesWithCQRSDesignPattern.Quries.CommandModel;
using MicroservicesWithCQRSDesignPattern.Quries.QueryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesWithCQRSDesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandHandler<CreateProductCommand> _createProductCommandHandler;
        private readonly IQueryHandler<GetProductsQuery, IEnumerable<ProductViewModel>> _getProductsQueryHandler;

        public ProductController(
            ICommandHandler<CreateProductCommand> createProductCommandHandler,
            IQueryHandler<GetProductsQuery, IEnumerable<ProductViewModel>> getProductsQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _getProductsQueryHandler = getProductsQueryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _getProductsQueryHandler.Handle(new GetProductsQuery());
            return Ok(products);
        }
    }
}
