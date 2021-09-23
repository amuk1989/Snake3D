using UnityEngine;

namespace Snake
{
    public class SimpleSnake : SnakeState
    {
        public SimpleSnake(SnakeController snake)
        {
            _snake = snake;
        }

        public override float Speed { get => _snake.Speed; }

        public override void Eat(GameController loot)
        {
            switch (loot)
            {
                case FoodModel food:
                    _snake.Eat(food);
                    break;
                case DiamondModel diamond:
                    _snake.Eat(diamond);
                    break;
                case CheckPointController checkPoint:
                    _snake.ChangeColor(checkPoint.Color);
                    break;
                case BombModel bomb:
                    _snake.Dead();
                    break;
                default:
                    break;

            }
        }

        public override Vector3 GetTarget(Vector3 mousePos)
        {
            return mousePos;
        }
    }
}
