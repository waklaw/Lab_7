using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class UpdateProduct
    {
        private ApplicationDbContext _context;
        public UpdateProduct(ApplicationDbContext context ) {
            _context = context;
        }

        public async Task<Response> Do(Request request) {
            var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);

            product.Name = request.Name;
            product.Author = request.Author;
            product.Genre = request.Genre;
            product.Description = request.Description;
            product.Value = request.Value;


            await _context.SaveChangesAsync();
            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Author = product.Author,
                Genre = product.Genre,
                Description = product.Description,
                Value = product.Value
            };
        }
        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }

}
