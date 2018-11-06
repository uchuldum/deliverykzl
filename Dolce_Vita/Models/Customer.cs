using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dolce_Vita.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } // Имя клиента     
        public string Phone { get; set; } // Телефонный номер клиента
        public string Adress { get; set; } // Адрес клиента
        public string Properties { get; set; } //Свойства блюда(состав/описание) 

        public int OrdersID { get; set; }
        [ForeignKey("OrdersID")] //Ссылка на заказ
        public Order Orders { get; set; }
    }
}
