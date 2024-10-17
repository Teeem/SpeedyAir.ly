// See https://aka.ms/new-console-template for more information

namespace ttabing.consoleapp.Orders
{
    public class DisplayOrderAssignmentLogic : IDisplayOrderAssignmentLogic
    {
        public void Display(IEnumerable<IOrderAssignment> data)
        {
            foreach (var orderAssignment in data)
            {
                if (orderAssignment.Flight == null)
                {
                    Console.WriteLine($"order: {orderAssignment.Order.Id}, flightNumber: not scheduled");
                    continue;
                }

                Console.WriteLine($"order: {orderAssignment.Order.Id}, flightNumber: {orderAssignment.Flight.FlightNumber}, departure: {orderAssignment.Flight.DepartureAirport}, arrival: {orderAssignment.Flight.ArrivalAirport}, day: {orderAssignment.Flight.Day}");
            }
        }
    }
}
