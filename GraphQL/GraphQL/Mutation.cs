using HotChocolate;
using HotChocolate.Subscriptions;
using OrderManager.Data;
using OrderManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.GraphQL
{
    public class Mutation
    {
        public async Task<Order> CreateOrder(OrderInput orderInput, [Service] ITopicEventSender ITopicEventSender)
        {
            var order = new Order
            {
                Id = Data.Data.Order.Count + 1,
                Customer = new Customer
                {
                    Id = orderInput.Customer.Id,
                    FullName = orderInput.Customer.FullName
                },
                Products = new List<Product>()
            };

            foreach (var productInput in orderInput.Products)
            {
                order.Products.Add(new Product{
                    Id = productInput.Id,
                    Name = productInput.Name
                });
            }

            Data.Data.Orders.Add(order);
            await ITopicEventSender.SendAsync(nameof(Subscription.OnOrderCreated), order);

            return order;
        }

        public class OrderInput
        {
            public CustomerInput Customer { get; set; }
            public List<ProductInput> Products { get; set }
        }

        public class CustomerInput
        {
            public int Id { get; set; }
            public string FullName{ get; set; }
        }

        public class ProductInput
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}