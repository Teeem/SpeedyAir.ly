// See https://aka.ms/new-console-template for more information
namespace ttabing.consoleapp.Orders
{
    public interface IDisplayOrderAssignmentLogic
    {
        void Display(IEnumerable<IOrderAssignment> data);

    }
}