using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CostumerBasket
    {
        public CostumerBasket()
        {
            
        }
        public CostumerBasket(string id)
        {
            Id = id;
        }
        public string Id{ get; set; }
        public List<BasketItems> Items { get; set; }  = new List<BasketItems>();
    }
}
