using HB_Mars.Helper.Directions;
using HB_Mars.Helper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB_Mars.Helper.Rover
{
    public static class Pointer
    {
        public static ResponseModel GetCurrentPosition(int topPositionX, int topPositionY, Position currentPosition, int secondRoverX, int secondRoverY)
        {
            var response = new ResponseModel();
            try
            {
                var lastPosition = new Position();
                lastPosition.Face = currentPosition.Face;

                if (currentPosition.Face == "N")
                {
                    lastPosition.xCoordinate = currentPosition.xCoordinate;
                    lastPosition.yCoordinate = currentPosition.yCoordinate + 1;
                }
                else if (currentPosition.Face == "E")
                {
                    lastPosition.xCoordinate = currentPosition.xCoordinate + 1;
                    lastPosition.yCoordinate = currentPosition.yCoordinate;
                }
                else if (currentPosition.Face == "S")
                {
                    lastPosition.xCoordinate = currentPosition.xCoordinate;
                    lastPosition.yCoordinate = currentPosition.yCoordinate - 1;
                }
                else if (currentPosition.Face == "W")
                {
                    lastPosition.xCoordinate = currentPosition.xCoordinate - 1;
                    lastPosition.yCoordinate = currentPosition.yCoordinate;
                }
                else
                {
                    lastPosition = currentPosition;
                }
                if (lastPosition.xCoordinate > topPositionX || lastPosition.yCoordinate > topPositionY)
                {
                    throw new Exception("OUT OF BOUND");
                }
                if (lastPosition.xCoordinate == secondRoverX && lastPosition.yCoordinate == secondRoverY)
                {
                    throw new Exception("2 ROVERS CRASHED");
                }
                response.Position = lastPosition;
                return response;
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Exception = ex;
                return response;
            }
        }
    }
}
