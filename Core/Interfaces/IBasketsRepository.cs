using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketsRepository
    {
        Task<CostumerBasket> GetBasketAsync(string id);
        Task<CostumerBasket> UpdateBasketAsync(CostumerBasket basket);
        Task<bool> DeleteBasketAsync(string id);
    }
}
