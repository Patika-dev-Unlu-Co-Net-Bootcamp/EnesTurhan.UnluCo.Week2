using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnesTurhan.UnluCo.Week1.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }


        // parametre




        public Product(int id,string name, decimal unitPrice, short unitsInStock) {

            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
         
        }

        //public Category Category { get; private set; }

   
        //public void SetCategory(Category category)
        //{
    

        //    if (category == null)
        //    {
        //        throw new Exception("Kategori girmek zorunludur");
        //    }

        //    Category = category;

        //}

        //public void SetUnitPrice(decimal unitPrice)
        //{
        //    if (unitPrice < 0)
        //    {
        //        throw new Exception("Ürüne Negatif bir fiyat değeri biçilemez");
        //    }

        //    if (!IsPromotion && unitPrice == 0)
        //    {
        //        throw new Exception("Promosyon olmayan bir ürünün fiyatı 0 olarak sisteme girilemez");
        //    }

        //    UnitPrice = unitPrice;

        //}
        public void SetUnitsInStock(short unitsInStock)
        {
            if (unitsInStock >= 10 && unitsInStock <= 100)
            {
                UnitsInStock = unitsInStock;
            }
            else
            {
                throw new Exception("Stock değeri min 10 max 100 arasında bir değer seçilebilir");
            }
        }
    }
}

