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
        private readonly IQueryHandler<GetProductsQuery, IEnumerable<GetAllProductCommand>> _getProductsQueryHandler;
        private readonly ICommandHandler<UpdateProductCommand> _updateProductCommandHandler;
        private readonly ICommandHandler<DeleteProductCommand> _deleteProductCommandHandler;

        public ProductController(
            ICommandHandler<CreateProductCommand> createProductCommandHandler,
            IQueryHandler<GetProductsQuery, IEnumerable<GetAllProductCommand>> getProductsQueryHandler,
            ICommandHandler<UpdateProductCommand> updateProductCommandHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _getProductsQueryHandler = getProductsQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        [HttpPost(nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return Ok();
        }

        [HttpGet(nameof(GetProducts))]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _getProductsQueryHandler.Handle(new GetProductsQuery());
            return Ok(products);
        }

        [HttpPut(nameof(UpdateProduct))]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            try

            {
                await _updateProductCommandHandler.Handle(command);
                return Ok("Product updated successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating product: {ex.Message}");
            }
        }

        [HttpDelete(nameof(DeleteProduct))]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var command = new DeleteProductCommand { Id = productId };
                await _deleteProductCommandHandler.Handle(command);
                return Ok("Product deleted successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting product: {ex.Message}");
            }
        }


    }
}
