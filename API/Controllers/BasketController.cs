using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketsRepository _basketsRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketsRepository basketsRepository,
                                           IMapper mapper)
        {
            this._basketsRepository = basketsRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetBasketById(string id)
        {
            var basket = await _basketsRepository.GetBasketAsync(id);

            return Ok(basket ?? new CostumerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CostumerBasket>> UpdateBasket(CostumerBasket basket)
        {

            var updatedBasket = await _basketsRepository.UpdateBasketAsync(basket);

            return Ok(updatedBasket ?? new CostumerBasket()); 
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketsRepository.DeleteBasketAsync(id);
        }
    }
}
