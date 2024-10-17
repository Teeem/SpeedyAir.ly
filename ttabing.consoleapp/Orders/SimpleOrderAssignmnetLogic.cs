// See https://aka.ms/new-console-template or more information

using ttabing.consoleapp.Flights;

namespace ttabing.consoleapp.Orders
{
    public class SimpleOrderAssignmnetLogic : IOrderAssignmentLogic
    {
        private readonly HashSet<IOrderAssignment> _flightByOrder;

        private readonly Dictionary<string, IOrderedEnumerable<IFlight>> _flightsByDestination;

        private readonly Dictionary<int, int> _cargoCapacityByFlight;

        public IReadOnlySet<IOrderAssignment> Assignments => _flightByOrder;

        public SimpleOrderAssignmnetLogic(IFlightManager flightManager)
        {
            _flightByOrder = new HashSet<IOrderAssignment>();
            _cargoCapacityByFlight = new Dictionary<int, int>();

            //create a dictionary for the flights by destination, then the flights for the given destination is sorted by the flight day.
            _flightsByDestination = flightManager.Flights
               .GroupBy(sf => sf.ArrivalAirport, sf => sf)
               .ToDictionary(sf => sf.Key, sf => sf.ToList().OrderBy(sf => sf.Day));
        }

        public void AssignOrder(IOrder order)
        {
            //Here are the following possibilities.
            //CASE A: There are no flights that fly to the destination.
            //CASE B: There is a flight that flies to the destination but they are all full.
            //CASE C: There is a flight that flies to the destination and has space.

            if (!_flightsByDestination.TryGetValue(order.TargetAirport, out var flights))
            {
                //CASE A: There are no flights that fly to the destination.
                _flightByOrder.Add(new OrderAssignment(order, null));
                return;
            }


            foreach (IFlight flight in flights)
            {
                if (!_cargoCapacityByFlight.TryGetValue(flight.FlightNumber, out int cargoCount))
                {
                    cargoCount = 0;
                }

                //Do we have space on the plane with available capacity?
                if (cargoCount < flight.Capacity)
                {
                    //CASE C: There is a flight that flies to the destination and has space.
                    _cargoCapacityByFlight[flight.FlightNumber] = cargoCount + 1;
                    _flightByOrder.Add(new OrderAssignment(order, flight));
                    return;
                }

            }

            //CASE B: There is a flight that flies to the destination but they are all full. We also handle the edge case where the list of flights is empty.
            _flightByOrder.Add(new OrderAssignment(order, null));
        }
    }

}