using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Service
{
    public class SProduct
    {
        public readonly IProduct repository = new IProduct();

        public List<Product> GetProducts()
        {
            return repository.ListProducts();
        }
        public List<Product> SearchProducts(string name)
        {
            return repository.ListProducts()
                .Where(p => p.ProductName
                .ToLower()
                .Contains(name.ToLower()))
                .ToList();
        }

    }
}
