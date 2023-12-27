using MicroservicesWithCQRSDesignPattern.Interfaces;
using MicroservicesWithCQRSDesignPattern.Quries.CommandModel;
using MicroservicesWithCQRSDesignPattern.Model;
using MicroservicesWithCQRSDesignPattern.Quries.QueryModel;

namespace MicroservicesWithCQRSDesignPattern.Handlers
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand command)
        {
            // Fetch the product to update from the repository
            var productToUpdate = await _repository.GetByIdAsync(command.Id);

            if(productToUpdate != null)
            {
                // Update the product properties
                productToUpdate.Name = command.Name;
                // Update other properties

                // Save changes to the repository
                await _repository.UpdateAsync(productToUpdate);
            }
            else
            {
                throw new Exception("Product not found"); // Handle product not found scenario
            }
        }
    }
}
