// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Flights
{
    public interface IDisplayFlightsLogic
    {
        void Display(IEnumerable<IFlight> flightData);

    }
}