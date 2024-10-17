// See https://aka.ms/new-console-template or more information
namespace ttabing.consoleapp.Orders
{
    public class OrderAssignmentManager : IOrderAssignmentManager
    {

        private readonly IOrderAssignmentLogic _assignmentLogic;
        private readonly IDisplayOrderAssignmentLogic _displayLogic;

        public OrderAssignmentManager(IOrderAssignmentLogic assignmentLogic, IDisplayOrderAssignmentLogic displayLogic)
        {
            _assignmentLogic = assignmentLogic;
            _displayLogic = displayLogic;
        }

        public void DisplayOrderAssignments()
        {
            _displayLogic.Display(_assignmentLogic.Assignments);
        }

        public void AssignOrder(IOrder order)
        {
            _assignmentLogic.AssignOrder(order);
        }
    }

}