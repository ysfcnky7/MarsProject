using MarsProject.Data.Entities;

namespace MarsProject.Repository.Abstract
{
    public interface IInvokeProcess
    {
        CoordinatesDTO Start(ICommand command, CoordinatesDTO coordinates);
    }
}
