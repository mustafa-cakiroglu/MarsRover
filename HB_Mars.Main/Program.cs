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
            roverRequest.SecondDirection = Console.ReadLine();


            roverRequest.TopPositionX = Convert.ToInt32(topPosition[0]);
            roverRequest.TopPositionY = Convert.ToInt32(topPosition[1]);

            roverRequest.CurrentX = Convert.ToInt32(currentPositionFirstRover[0]);
            roverRequest.CurrentY = Convert.ToInt32(currentPositionFirstRover[1]);
            roverRequest.CurrentFacing = currentPositionFirstRover[2].Trim();

            roverRequest.SecondRoverX = Convert.ToInt32(currentPositionSecondRover[0]);
            roverRequest.SecondRoverY = Convert.ToInt32(currentPositionSecondRover[1]);
            roverRequest.SecondFacing = currentPositionSecondRover[2].Trim();

            Run(roverRequest);
            Console.ReadLine();
        }
        public static void Run(RoverRequest roverRequest)
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
                var secondRoverRequest = new RoverRequest();
                secondRoverRequest.TopPositionX = roverRequest.TopPositionX;
                secondRoverRequest.TopPositionY = roverRequest.TopPositionY;
                secondRoverRequest.CurrentX = roverRequest.SecondRoverX;
                secondRoverRequest.CurrentY = roverRequest.SecondRoverY;
                secondRoverRequest.CurrentFacing = roverRequest.SecondFacing;
                secondRoverRequest.Direction = roverRequest.SecondDirection;
                secondRoverRequest.SecondRoverX = positionFirstRover.Position.xCoordinate;
                secondRoverRequest.SecondRoverY = positionFirstRover.Position.yCoordinate;

                var positionSecondRover = roverMovement.RoverMove(secondRoverRequest);
                Console.WriteLine(positionSecondRover.Position.xCoordinate + " " + positionSecondRover.Position.yCoordinate + " " + positionSecondRover.Position.Face);
            }
        }
    }
}