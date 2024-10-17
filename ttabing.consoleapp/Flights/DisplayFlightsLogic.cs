// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Flights
{
    public class DisplayFlightsLogic : IDisplayFlightsLogic
    {
        public void Display(IEnumerable<IFlight> data)
        {
            foreach (var flight in data)
            {
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureAirport}, arrival: {flight.ArrivalAirport}, day: {flight.Day}");
            }
        }
    }
}