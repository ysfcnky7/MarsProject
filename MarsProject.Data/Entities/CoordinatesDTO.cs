using MarsProject.Data.Constants.Enums;

namespace MarsProject.Data.Entities
{
    public class CoordinatesDTO
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Directions Directions { get; set; }
    }
}
