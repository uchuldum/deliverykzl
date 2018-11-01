using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dolce_Vita.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } // название блюда     
        public decimal Price { get; set; } //Цена блюда
        public string Properties { get; set; } //Свойства блюда(состав/описание) 

        public int CategoryId { get; set; } // ссылка на связанную модель Categories
        public Category category { get; set; }
    }
}
