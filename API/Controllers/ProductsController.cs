using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
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
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProductsAsync(
            [FromQuery]ProductSpecParams specParams)
        {
            var spec = new ProdductsWithTypesAndBrandsSpecification(specParams);

            var countSpec = new ProductsWithFiltersForCountSpecification(specParams);

            var totalItems = await _genericProductRepository.CountAsync(countSpec);

            var products = await _genericProductRepository.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(specParams.PageIndex, specParams.PageSize,
                totalItems, data)); 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProdductsWithTypesAndBrandsSpecification(id);

            var product = await _genericProductRepository.GetEntityWitchSpec(spec);

            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }

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
