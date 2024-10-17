// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Flights
{
    public interface IFlightManager
    {
        IReadOnlyList<IFlight> Flights { get; }

        void AddFlight(IFlight flight);

        void DisplayFlights();
    }
}