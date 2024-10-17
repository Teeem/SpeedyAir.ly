// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Flights
{
    public class Flight : IFlight
    {
        public int FlightNumber { get; init; }

        public string DepartureAirport { get; init; }

        public string ArrivalAirport { get; init; }

        public int Capacity { get; init; }

        public int Day { get; init; }

        public Flight(int flightNumber, int capacity, int day, string departureAirport, string arrivalAirport)
        {
            FlightNumber = flightNumber;
            Capacity = capacity;
            Day = day;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
        }
    }
}