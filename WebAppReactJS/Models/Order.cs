using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReactJS.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public List<Item> Items { get; set; }

        public decimal TotalPrice { get { return this.Items.Sum(p => p.Price); } }

        public DateTime Date { get; set; }

        public string DateString { get { return this.Date.ToString("dd/MM/yyyy HH:mm"); } }

        public string CustomerEmail { get; set; }

        public string CustomerAddress { get; set; }

        public OrderState State { get; set; }

        public string StateString { get { return this.State.ToString(); } }

        public Order()
        {
            this.Items = new List<Models.Item>();
        }

        public void Add(Item item)
        {
            item.Price = item.Product.Price;            
            this.Items.Add(item);
        }
    }

    public class Item
    {
        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public Product Product { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
            
          

        public Item()
        {
            
        }
        
    }

    public enum OrderState
    {
        Cart,
        Delivery,
        Payment,
        Confirm,
        Complete
    }
}