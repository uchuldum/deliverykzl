using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dolce_Vita.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; } // Цена заказа

        public int DishID { get; set; }
        [ForeignKey("DishID")]
        public Dish Dish { get; set; }
    }
}
