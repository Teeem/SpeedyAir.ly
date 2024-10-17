// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Orders
{
    public interface IOrderAssignmentManager
    {
        void AssignOrder(IOrder order);
        void DisplayOrderAssignments();

    }
}