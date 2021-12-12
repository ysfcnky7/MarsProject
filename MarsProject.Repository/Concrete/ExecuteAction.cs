using MarsProject.Data.Entities;

namespace MarsProject.Repository.Concrete
{
    public class ExecuteAction : Abstract.IInvokeProcess
    {
        public CoordinatesDTO Start(Abstract.ICommand command, CoordinatesDTO coordinates)
        {
            return command.Run(coordinates);
        }
    }
}
