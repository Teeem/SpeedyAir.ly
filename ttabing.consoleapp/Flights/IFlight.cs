// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Flights
{
    public interface IFlight
    {
        int FlightNumber { get; }

        string DepartureAirport { get; }

        string ArrivalAirport { get; }

        int Capacity { get; }

        int Day { get; }
    }
}