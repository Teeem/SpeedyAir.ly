// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Orders
{
    public interface IOrder
    {
        string TargetAirport { get; }

        string Id { get; }

    }
}