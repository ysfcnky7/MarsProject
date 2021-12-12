using MarsProject.Repository.Abstract;
using MarsProject.Repository.Concrete;
using MarsProject.Service;
using MarsProject.Service.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value for an MxN matrix (Example M N): ");
            var maxPointsArray = Console.ReadLine().Trim().Split(' ');
            if (maxPointsArray.Length != 2)
            {
                Console.WriteLine("Enter 2 numbers with a space between them.");
            }
            else
            {
                for (int i = 0; i < maxPointsArray.Length; i++)
                {
                    if (!int.TryParse(maxPointsArray[i], out int value))
                    {
                        Console.WriteLine("Please enter a number type value.");
                        return;
                    }
                }
            }

            Console.WriteLine("Enter the value current location:");
            var currentLocation = Console.ReadLine().Split(' ');

            Console.WriteLine("Enter the movement:");
            var directions = Console.ReadLine();

            var services = new ServiceCollection();
            services.AddSingleton<IMarsRoverService, MarsRoverService>();
            services.AddSingleton<IInvokeProcess, ExecuteAction>();
            var _serviceProvider = services.BuildServiceProvider(true);
            var _marsRoverService = _serviceProvider.GetService<IMarsRoverService>();
            var _invoker = _serviceProvider.GetService<IInvokeProcess>();
            var coordinates = _marsRoverService.MoveSync(maxPointsArray, currentLocation, directions, _invoker);
            if (coordinates != null)
                Console.WriteLine(coordinates.XCoordinate + " " + coordinates.YCoordinate + " " + coordinates.Directions);
            else
                Console.WriteLine("Incorrect Operation!");
            Console.ReadKey();
        }
    }
}
