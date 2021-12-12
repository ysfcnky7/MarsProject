using MarsProject.Data.Constants.Enums;
using MarsProject.Data.Entities;
using System;
using System.Collections.Generic;

namespace MarsProject.Repository.Concrete
{
    public class MoveForward : Abstract.ICommand
    {
        private List<int> maxList = new List<int>();
        public MoveForward(List<int> maxList)
        {
            this.maxList = maxList;
        }
        public CoordinatesDTO Run(CoordinatesDTO coordinates)
        {
            switch (coordinates.Directions)
            {
                case Directions.North:
                    if (coordinates.YCoordinate >= maxList[1])
                        coordinates = CantMove();
                    else
                        coordinates.YCoordinate += 1;
                    break;

                case Directions.East:
                    if (coordinates.XCoordinate >= maxList[0])
                        coordinates = CantMove();
                    else
                        coordinates.XCoordinate += 1;
                    break;

                case Directions.South:
                    if (coordinates.YCoordinate != 0)
                        coordinates.YCoordinate -= 1;
                    else
                        coordinates = CantMove();
                    break;

                case Directions.West:
                    if (coordinates.XCoordinate != 0)
                        coordinates.XCoordinate -= 1;
                    else
                        coordinates = CantMove();
                    break;
            }
            return coordinates;
        }

        private CoordinatesDTO CantMove()
        {
            Console.WriteLine("Can't go forward");
            return null;
        }
    }

}
