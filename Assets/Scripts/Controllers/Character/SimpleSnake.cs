using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SimpleSnake : SnakeController
    {
        public override void Eat(GameController loot)
        {
            switch (loot)
            {
                case FoodModel food:
                    base.Eat(food);
                    break;
                case DiamondModel diamond:
                    base.Eat(diamond);
                    break;
                case CheckPointController checkPoint:
                    base.ChangeColor(checkPoint.Color);
                    break;
                case BombModel bomb:
                    base.Dead();
                    break;
                default:
                    break;

            }
        }
    }
}
