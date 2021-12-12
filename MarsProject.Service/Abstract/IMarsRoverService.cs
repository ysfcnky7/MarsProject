using MarsProject.Data.Entities;
using MarsProject.Repository.Abstract;

namespace MarsProject.Service.Abstract
{
    public interface IMarsRoverService
    {
        CoordinatesDTO MoveSync(string[] maxPointsArray, string[] currentLocation, string directions, IInvokeProcess _invoker);
    }
}
