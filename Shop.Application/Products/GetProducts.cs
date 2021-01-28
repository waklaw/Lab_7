using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.ProductsAdmin
{
    public class GetProducts //AdminView
    {
        private ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() => _ctx.Products.ToList().Select(x => new ProductViewModel
            
            {
                Id = x.Id,
                Name = x.Name,
                Author = x.Author,
                Genre = x.Genre,
                Value = $"{x.Value.ToString("N2")}UAH"
        });
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public string Value { get; set; }
        }
    }
    
}
