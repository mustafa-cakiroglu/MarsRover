using System;
using HB_Mars.Helper.Models;

namespace HB_Mars.Main
{
    static class Program
    {
        static void Main(string[] args)
        {
            var roverRequest = new RoverRequest();
            var secondRoverRequest = new RoverRequest();
            Console.WriteLine("Enter the top position : ");
            string[] topPosition = Console.ReadLine().Split(' ');

            Console.WriteLine("Enter the first rover's current position : ");
            string[] currentPositionFirstRover = Console.ReadLine().Split(' ');

            Console.WriteLine("Enter the first rover's directions: ");
            roverRequest.Direction = Console.ReadLine();

            Console.WriteLine("Enter the second rover's current position : ");
            string[] currentPositionSecondRover = Console.ReadLine().Split(' ');

            Console.WriteLine("Enter the second rover's directions: ");
            secondRoverRequest.Direction = Console.ReadLine();

            roverRequest.TopPositionX = Convert.ToInt32(topPosition[0]);
            roverRequest.TopPositionY = Convert.ToInt32(topPosition[1]);
            roverRequest.CurrentX = Convert.ToInt32(currentPositionFirstRover[0]);
            roverRequest.CurrentY = Convert.ToInt32(currentPositionFirstRover[1]);
            roverRequest.CurrentFacing = currentPositionFirstRover[2].Trim();

            secondRoverRequest.TopPositionX = Convert.ToInt32(topPosition[0]);
            secondRoverRequest.TopPositionY = Convert.ToInt32(topPosition[1]);
            secondRoverRequest.CurrentX = Convert.ToInt32(currentPositionSecondRover[0]);
            secondRoverRequest.CurrentY = Convert.ToInt32(currentPositionSecondRover[1]);
            secondRoverRequest.CurrentFacing = currentPositionSecondRover[2].Trim();

            Run(roverRequest, secondRoverRequest);
            Console.ReadLine();
        }
        public static void Run(RoverRequest roverRequest, RoverRequest secondRoverRequest)
        {

            var roverMovement = new RoverMovement();
            var positionFirstRover = roverMovement.RoverMove(roverRequest);
            if (positionFirstRover.IsError)
            {
                Console.WriteLine(positionFirstRover.Exception.Message);
            }
            else
            {
                Console.WriteLine(positionFirstRover.Position.xCoordinate + " " + positionFirstRover.Position.yCoordinate + " " + positionFirstRover.Position.Face);
                secondRoverRequest.SecondRoverX = positionFirstRover.Position.xCoordinate;
                secondRoverRequest.SecondRoverY = positionFirstRover.Position.yCoordinate;
                var positionSecondRover = roverMovement.RoverMove(secondRoverRequest);
                Console.WriteLine(positionSecondRover.Position.xCoordinate + " " + positionSecondRover.Position.yCoordinate + " " + positionSecondRover.Position.Face);
            }
        }
    }
}