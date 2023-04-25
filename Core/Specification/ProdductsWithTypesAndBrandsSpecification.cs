using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProdductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProdductsWithTypesAndBrandsSpecification()
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }

        public ProdductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}
