// See https://aka.ms/new-console-template or more information
namespace ttabing.consoleapp.Orders
{
    public interface IOrderAssignmentLogic
    {
        IReadOnlySet<IOrderAssignment> Assignments { get; }
        void AssignOrder(IOrder order);
    }
}
