using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using ttabing.consoleapp.Flights;
using ttabing.consoleapp.Orders;

namespace ttabing.consoleapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlightManager flightManager = CreateFlightManager();

            OrderAssignmentManager orderAssignmentManager = CreateOrderAssignmentManager(flightManager);

            flightManager.DisplayFlights();
            orderAssignmentManager.DisplayOrderAssignments();
        }

        static FlightManager CreateFlightManager()
        {
            Flight flight1 = new Flight(1, 20, 1, "YUL", "YYZ");
            Flight flight2 = new Flight(2, 20, 1, "YUL", "YYC");
            Flight flight3 = new Flight(3, 20, 1, "YUL", "YVR");
            Flight flight4 = new Flight(4, 20, 2, "YUL", "YYC");
            Flight flight5 = new Flight(5, 20, 2, "YUL", "YYZ");
            Flight flight6 = new Flight(6, 20, 2, "YUL", "YVR");


            FlightManager flightManager = new FlightManager(new DisplayFlightsLogic());
            flightManager.AddFlight(flight1);
            flightManager.AddFlight(flight2);
            flightManager.AddFlight(flight3);
            flightManager.AddFlight(flight4);
            flightManager.AddFlight(flight5);
            flightManager.AddFlight(flight6);
            return flightManager;
        }

        static OrderAssignmentManager CreateOrderAssignmentManager(FlightManager flightManager)
        {
            IOrderAssignmentLogic orderAssignmentLogic = new SimpleOrderAssignmnetLogic(flightManager);
            IDisplayOrderAssignmentLogic displayOrderAssignmentLogic = new DisplayOrderAssignmentLogic();
            OrderAssignmentManager orderAssignmentManager = new OrderAssignmentManager(orderAssignmentLogic, displayOrderAssignmentLogic);
            var orders = GetOrdersFromFile();

            foreach (var order in orders)
            {
                orderAssignmentManager.AssignOrder(order);
            }

            return orderAssignmentManager;
        }

        static IEnumerable<IOrder> GetOrdersFromFile()
        {
            //NOTE for time purposes, I ignored error checking and the important concept to never trust data.
            List<IOrder> payload = new List<IOrder>();
            using (FileStream openStream = File.OpenRead("coding-assigment-orders.json"))
            {
                var rawData =
                     JsonSerializer.Deserialize<ExpandoObject>(openStream);
                if( rawData == null)
                {
                    throw new InvalidOperationException("unable to parse coding assignment orders json");
                }

                foreach (var rawRow in rawData)
                {
                    string orderId = rawRow.Key;
                    string? destination = ((JsonElement)rawRow.Value).GetProperty("destination").GetString();
                    IOrder newOrder = new Order(destination ?? "FAILED TO READ DESTINATION", orderId);
                    payload.Add(newOrder);
                }

                return payload;
            }
        }
    }
}




