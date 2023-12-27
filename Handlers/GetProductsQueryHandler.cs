﻿using MicroservicesWithCQRSDesignPattern.Interfaces;
using MicroservicesWithCQRSDesignPattern.Model;
using MicroservicesWithCQRSDesignPattern.Quries.QueryModel;

namespace MicroservicesWithCQRSDesignPattern.Handlers
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IRepository<Product> _repository; // Inject repository or database context

        public GetProductsQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductsQuery query)
        {
            var products = await _repository.GetAllAsync(); // Implement repository method
                                                                    // Map products to ProductViewModel
            return products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
                // Map other properties
            });
        }
    }
}
