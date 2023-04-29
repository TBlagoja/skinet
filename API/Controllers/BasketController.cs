using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketsRepository _basketsRepository;

        public BasketController(IBasketsRepository basketsRepository)
        {
            this._basketsRepository = basketsRepository;
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

            return Ok(updatedBasket); 
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketsRepository.DeleteBasketAsync(id);
        }
    }
}
