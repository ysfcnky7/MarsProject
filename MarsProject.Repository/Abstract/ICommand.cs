using MarsProject.Data.Entities;

namespace MarsProject.Repository.Abstract
{
    public interface ICommand
    {
        public CoordinatesDTO Run(CoordinatesDTO coordinates);
    }
}
