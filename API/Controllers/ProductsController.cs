using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _genericProductRepository;
        private readonly IGenericRepository<ProductBrand> _genericBrandRepository;
        private readonly IGenericRepository<ProductType> _genericTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> genericProductRepository,
                                  IGenericRepository<ProductBrand> genericBrandRepository,
                                  IGenericRepository<ProductType> genericTypeRepository,
                                  IMapper mapper)
        {
            this._genericProductRepository = genericProductRepository;
            this._genericBrandRepository = genericBrandRepository;
            this._genericTypeRepository = genericTypeRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProductsAsync()
        {
            var spec = new ProdductsWithTypesAndBrandsSpecification();

            var products = await _genericProductRepository.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products)); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProdductsWithTypesAndBrandsSpecification(id);

            var product = await _genericProductRepository.GetEntityWitchSpec(spec);

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _genericBrandRepository.GetAllAsync();

            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productTypes = await _genericTypeRepository.GetAllAsync();

            return Ok(productTypes);
        }
    }
}
