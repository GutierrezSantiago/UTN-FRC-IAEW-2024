using OrderManager.Models;

namespace OrderManager.GraphQL
{
    public class Query
    {
        public List<Order> GetOrders() => Data.Data.Orders;
    }
}