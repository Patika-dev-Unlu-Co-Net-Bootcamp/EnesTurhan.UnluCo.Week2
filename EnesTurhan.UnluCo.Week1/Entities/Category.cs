using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnesTurhan.UnluCo.Week1.Entities
{
    public class Category { 
     

        public Category(string name)
        {


            Id = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Category Ismi boş geçilemez");
            }

            Name = name;

        }
        [Required]
        public string Id { get; private set; }


        [Required]
        public string Name { get; private set; }

        private HashSet<Product> products = new HashSet<Product>();

        public IReadOnlySet<Product> Products => products;

    
        //public void AddProduct(string name, short stock, decimal price, bool promotion)
        //{

        //    bool sameNameExists = products.Any(x => x.Name == name.Trim());

        //    if (sameNameExists)
        //    {
        //        throw new Exception("Aynı isimde ürün sistemde mevcut");
        //    }

        //    var product = new Product(default,name: name, price,stock);
        //    product.SetUnitPrice(price);
        //    product.SetUnitsInStock(stock);
        //   // product.SetCategory(this);


        //}


        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Kategori ismi girmeniz gerekir");
            }

            Name = name.Trim();
        }
    }
    }
