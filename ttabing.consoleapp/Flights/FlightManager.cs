// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Flights
{
    public class FlightManager : IFlightManager
    {
        private readonly List<IFlight> _flights;
        private readonly IDisplayFlightsLogic _displayFlights;

        public IReadOnlyList<IFlight> Flights => _flights;

        public FlightManager(IDisplayFlightsLogic displayFlightsLogic)
        {
            _flights = new List<IFlight>();
            _displayFlights = displayFlightsLogic;
        }

        public void AddFlight(IFlight flight)
        {
            _flights.Add(flight);
        }

        public void DisplayFlights()
        {
            _displayFlights.Display(Flights);
        }
    }
}