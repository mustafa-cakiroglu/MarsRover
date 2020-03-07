using System;
using System.Collections.Generic;
using System.Text;
using HB_Mars.Helper.Directions;
using HB_Mars.Helper.Enums;

namespace HB_Mars.Helper.Models
{
   public class CardinalDirectionStrategyContext

    {
        private CardinalDirectionBase _cardinalDirectionBaseStrategy;

        public CardinalDirectionStrategyContext(CardinalDirectionBase ardinalDirectionBaseStrategy)
        {
            this._cardinalDirectionBaseStrategy = ardinalDirectionBaseStrategy;
        }

        public string ContextInterface(TurnPositionEnum turnPositionEnum)
        {
           return _cardinalDirectionBaseStrategy.SetDirection(turnPositionEnum);
        }
    }
}
