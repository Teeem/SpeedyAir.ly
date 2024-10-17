// See https://aka.ms/new-console-template or more information
using ttabing.consoleapp.Flights;

namespace ttabing.consoleapp.Orders
{
    public interface IOrderAssignment
    {
        IOrder Order { get; init; }

        IFlight? Flight { get; init; }
    }
}

