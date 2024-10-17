// See https://aka.ms/new-console-template or more information
using ttabing.consoleapp.Flights;

namespace ttabing.consoleapp.Orders
{
    public class OrderAssignment : IOrderAssignment
    {
        public IOrder Order { get; init; }

        public IFlight? Flight { get; init; }

        public OrderAssignment(IOrder order, IFlight? flight)
        {
            Order = order;
            Flight = flight;
        }
    }

}