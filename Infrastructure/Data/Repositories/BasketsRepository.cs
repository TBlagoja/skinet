using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class BasketsRepository : IBasketsRepository
    {
        private readonly IDatabase _database;

        public BasketsRepository(IConnectionMultiplexer redis)
        {
            this._database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);  
        }

        public async Task<CostumerBasket> GetBasketAsync(string id)
        {
            var data = await _database.StringGetAsync(id);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CostumerBasket>(data);
        }

        public async Task<CostumerBasket> UpdateBasketAsync(CostumerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id,
                                 JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);

        }
    }
}
