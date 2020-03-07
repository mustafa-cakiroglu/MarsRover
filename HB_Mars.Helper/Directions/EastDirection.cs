using System;
using HB_Mars.Helper.Enums;
using HB_Mars.Helper.Helper;

namespace HB_Mars.Helper.Directions
{
    public class EastDirection : CardinalDirectionBase
    {
        public override string SetDirection(TurnPositionEnum turnPosition)
        {
            if (turnPosition == TurnPositionEnum.Right)

                return ((Enum)CardinalDirectionEnum.South).GetDisplayName();
            else
                return ((Enum)CardinalDirectionEnum.Nort).GetDisplayName();
        }
    }
}
