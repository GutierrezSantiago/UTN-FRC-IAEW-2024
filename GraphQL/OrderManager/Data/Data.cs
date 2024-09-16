using OrderManager.Models;
using System.Collections.Generic;

namespace OrderManager.Data
{
    public static class Data
    {
        public static List<Order> Orders { get; set; } = new List<Order> 
        {
            new Order{
                Id = 1,
            
                Customer = new Customer { Id = 1, FullName = "Juan Pérez"},
                Products = new List<Product>
                {
                    new Product{ Id = 1, Name = "Producto A"},
                    new Product{ Id = 2, Name = "Producto B"}
                }
            }    
        };
    }
}