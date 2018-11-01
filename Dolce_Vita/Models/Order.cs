using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dolce_Vita.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; } // Цена заказа


        public int DishId { get; set; }
        public Dish dish { get; set; }
    }
}
