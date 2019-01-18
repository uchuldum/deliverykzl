using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dolce_Vita.Models;
namespace Dolce_Vita.Domain.Entities
{
    public class CartRow
    {
        public Dish Dish;
        public int Quantity;

    }
    public class Cart
    {
        public List<CartRow> Rows = new List<CartRow>();

        public void AddDish(Dish dish, int quantity)
        {
            CartRow Row = Rows
                .Where(d => d.Dish.Id == dish.Id)
                .FirstOrDefault();
            if (Row == null)
            {
                Rows.Add(new CartRow {Dish = dish, Quantity = quantity });
            }
            else
            {
                Row.Quantity += quantity;
            }
        }
        public decimal CalculateTotalValue()
        {
            return Rows.Sum(r => r.Dish.Price * r.Quantity);
        }
        public void Clear()
        {
            Rows.Clear();
        }
        public IEnumerable<CartRow> GetRows
        {
            get { return Rows; }
        }



    }
}
