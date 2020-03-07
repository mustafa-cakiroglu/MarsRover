using HB_Mars.Helper.Enums;

namespace HB_Mars.Helper.Directions
{
    //Dependency Inversion
    public class CardinalDirection
    {

        private CardinalDirectionBase _nortDirection = new NortDirection();
        private CardinalDirectionBase _westDirection = new WestDirection();
        private CardinalDirectionBase _southDirection = new SouthDirection();
        private CardinalDirectionBase _eastDirection = new EastDirection();

        public string SetDirection(CardinalDirectionEnum cardinalDirection, TurnPositionEnum turnPositionEnum)
        {

            switch (cardinalDirection)
            {
                case CardinalDirectionEnum.Nort:
                    return _nortDirection.SetDirection(turnPositionEnum);
                case CardinalDirectionEnum.East:
                    return _eastDirection.SetDirection(turnPositionEnum);
                case CardinalDirectionEnum.South:
                    return _southDirection.SetDirection(turnPositionEnum);
                case CardinalDirectionEnum.West:
                    return _westDirection.SetDirection(turnPositionEnum);
            }
            return nameof(cardinalDirection);
        }
    }
}
