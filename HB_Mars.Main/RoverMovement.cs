using System.Linq;
using HB_Mars.Helper.Directions;
using HB_Mars.Helper.Enums;
using HB_Mars.Helper.Helper;
using HB_Mars.Helper.Models;
using HB_Mars.Helper.Rover;

namespace HB_Mars.Main
{
    public class RoverMovement
    {
        private CardinalDirection _directionEnum = new CardinalDirection();

        public ResponseModel RoverMove(RoverRequest roverRequest)
        {
            ValidateModel(roverRequest);
            var position = new Position();
            position.xCoordinate = roverRequest.CurrentX;
            position.yCoordinate = roverRequest.CurrentY;
            position.Face = roverRequest.CurrentFacing;

            return LastStateOfRover(roverRequest, position);
        }

        private ResponseModel LastStateOfRover(RoverRequest roverRequest, Position position)
        {
            var response = new ResponseModel();
            string existFacing = roverRequest.CurrentFacing;
            var directionArray = roverRequest.Direction.ToCharArray();
            foreach (var direct in directionArray)
            {
                if (direct.ToString() == "L" || direct.ToString() == "R")
                {
                    var cardinalDirectionEnumId = EnumExtensions.GetValues<CardinalDirectionEnum>().FirstOrDefault(x => x.Label == existFacing)?.Id;
                    var turnPositionEnumId = EnumExtensions.GetValues<TurnPositionEnum>().FirstOrDefault(x => x.Label == direct.ToString())?.Id;
                    existFacing = _directionEnum.SetDirection((CardinalDirectionEnum)cardinalDirectionEnumId, (TurnPositionEnum)turnPositionEnumId);
                    position.Face = existFacing;
                }
                if (direct.ToString() == "M")
                {
                    response = Pointer.GetCurrentPosition(roverRequest.TopPositionX, roverRequest.TopPositionY, position, roverRequest.SecondRoverX, roverRequest.SecondRoverY);
                    position = response.Position;
                    if (response.IsError)
                    {
                        break;
                    }
                }
            }
            return response;
        }

        public void ValidateModel(RoverRequest roverRequest)
        {
            Guard.ForLessThanOrEqualToZero(roverRequest.TopPositionX, nameof(roverRequest.TopPositionX));
            Guard.ForLessThanOrEqualToZero(roverRequest.TopPositionY, nameof(roverRequest.TopPositionY));
            Guard.ForLessThanOrEqualToZero(roverRequest.CurrentFacing, nameof(roverRequest.CurrentFacing));
            Guard.ForNullOrWhitespace(roverRequest.Direction, nameof(roverRequest.Direction));
        }
    }
}
