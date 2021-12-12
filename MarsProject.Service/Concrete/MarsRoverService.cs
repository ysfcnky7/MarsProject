using MarsProject.Data.Constants.Enums;
using MarsProject.Data.Entities;
using MarsProject.Helper;
using MarsProject.Repository.Concrete;
using MarsProject.Repository.Abstract;
using System;
using System.Collections.Generic;
using MarsProject.Service.Abstract;

namespace MarsProject.Service
{
    public class MarsRoverService : IMarsRoverService
    {
        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        public CoordinatesDTO MoveSync(string[] maxPointsArray, string[] currentLocation, string directions, IInvokeProcess _invoker)
        {
            var maxLst = new List<int>();
            foreach (var m in maxPointsArray)
            {
                var maxCoordinate = Convert.ToInt32(m);
                maxLst.Add(maxCoordinate);
            }
            var coordinates = new CoordinatesDTO();
            coordinates.XCoordinate = Convert.ToInt32(currentLocation[0]);
            coordinates.YCoordinate = Convert.ToInt32(currentLocation[1]);
            coordinates.Directions = currentLocation[2].ToEnumValue<Directions>();
            ICommand command;

            foreach (var dir in directions)
            {
                switch (dir)
                {
                    case 'L':
                        command = new MoveLeft();
                        break;

                    case 'R':
                        command = new MoveRight();
                        break;

                    case 'M':
                        command = new MoveForward(maxLst);
                        break;

                    default:
                        return null;
                }
                var c = _invoker.Start(command, coordinates);

                if (c == null)
                    return null;

                coordinates.Directions = c.Directions;
                coordinates.XCoordinate = c.XCoordinate;
                coordinates.YCoordinate = c.YCoordinate;
            }
            return coordinates;
        }
    }

}
