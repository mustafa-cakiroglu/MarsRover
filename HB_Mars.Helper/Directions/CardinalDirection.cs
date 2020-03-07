using HB_Mars.Helper.Enums;
using HB_Mars.Helper.Models;

namespace HB_Mars.Helper.Directions
{
    //Dependency Inversion
    public class CardinalDirection
    {

        private CardinalDirectionStrategyContext _cardinalDirectionStrategyContext;

        //Strategy Design
        public string SetDirection(CardinalDirectionEnum cardinalDirection, TurnPositionEnum turnPositionEnum)
        {

            switch (cardinalDirection)
            {
                case CardinalDirectionEnum.Nort:
                    _cardinalDirectionStrategyContext = new CardinalDirectionStrategyContext(new NortDirection());
                    return _cardinalDirectionStrategyContext.ContextInterface(turnPositionEnum);

                case CardinalDirectionEnum.East:
                    _cardinalDirectionStrategyContext = new CardinalDirectionStrategyContext(new EastDirection());
                    return _cardinalDirectionStrategyContext.ContextInterface(turnPositionEnum);

                case CardinalDirectionEnum.South:
                    _cardinalDirectionStrategyContext = new CardinalDirectionStrategyContext(new SouthDirection());
                    return _cardinalDirectionStrategyContext.ContextInterface(turnPositionEnum);

                case CardinalDirectionEnum.West:
                    _cardinalDirectionStrategyContext = new CardinalDirectionStrategyContext(new WestDirection());
                    return _cardinalDirectionStrategyContext.ContextInterface(turnPositionEnum);

            }
            return nameof(cardinalDirection);
        }
    }
}
