// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Orders
{
    public class Order : IOrder
    {
        public string TargetAirport { get; init; }

        public string Id { get; init; }


        public Order(string targetAirport, string id)
        {
            TargetAirport = targetAirport;
            Id = id;
        }
    }
}