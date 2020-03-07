using System;
using HB_Mars.Helper.Enums;
using HB_Mars.Helper.Helper;

namespace HB_Mars.Helper.Directions
{
    public class SouthDirection : CardinalDirectionBase
    {
        public override string SetDirection(TurnPositionEnum turnPosition)
        {
            if (turnPosition == TurnPositionEnum.Right)

                return ((Enum)CardinalDirectionEnum.West).GetDisplayName();
            else
                return ((Enum)CardinalDirectionEnum.East).GetDisplayName();
        }
    }
}
