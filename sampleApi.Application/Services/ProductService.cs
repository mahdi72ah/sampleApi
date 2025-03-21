using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sampleApi.Application.Interfaces;
using sampleApi.Core;
using sampleApi.Core.Entities;
using sampleApi.Core.IReposirories;
using sampleApi.Infrastructure.Dtos;
using sampleApi.Infrastructure.UnitOfWorks;

namespace sampleApi.Application.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SampleApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products= await _dbContext.Product.ToListAsync();
            var result = _mapper.Map<List<ProductDto>>(products);
            return result;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product= await _dbContext.Product.FindAsync(id);
            var model = _mapper.Map<ProductDto>(product);
            return model;
        }

        public async Task<ProductDto> Add(ProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            await _productRepository.InsertAsync(product);
            await _productRepository.InsertAsync(product);
            await _unitOfWork.SaveChangeAsync();
            model.Id = product.Id;
            return model;
        }
    }
}
