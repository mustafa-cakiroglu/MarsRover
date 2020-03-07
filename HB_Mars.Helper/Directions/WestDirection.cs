using System;
using HB_Mars.Helper.Enums;
using HB_Mars.Helper.Helper;

namespace HB_Mars.Helper.Directions
{
    public class WestDirection : CardinalDirectionBase
    {
        public override string SetDirection(TurnPositionEnum turnPosition)
        {
            if (turnPosition == TurnPositionEnum.Right)

                return ((Enum)CardinalDirectionEnum.Nort).GetDisplayName();
            else
                return ((Enum)CardinalDirectionEnum.South).GetDisplayName();
        }
    }
}
