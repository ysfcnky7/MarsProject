using MarsProject.Data.Constants.Enums;
using MarsProject.Data.Entities;

namespace MarsProject.Repository.Concrete
{
    public class MoveRight : Abstract.ICommand
    {
        public CoordinatesDTO Run(CoordinatesDTO coordinates)
        {
            switch (coordinates.Directions)
            {
                case Directions.North:
                    coordinates.Directions = Directions.East;
                    break;

                case Directions.East:
                    coordinates.Directions = Directions.South;
                    break;

                case Directions.South:
                    coordinates.Directions = Directions.West;
                    break;

                case Directions.West:
                    coordinates.Directions = Directions.North;
                    break;
            }
            return coordinates;
        }
    }

}
