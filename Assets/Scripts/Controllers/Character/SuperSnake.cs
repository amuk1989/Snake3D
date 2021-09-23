using UnityEngine;

namespace Snake
{
    public class SuperSnake : SnakeState
    {
        public SuperSnake(SnakeController snake)
        {
            _snake = snake;
            _speed = snake.Speed * 3;
        }

        public override float Speed
        {
            get => _speed;
        }

        public override void Eat(GameController Eat)
        {
            switch (Eat)
            {
                case GameModel model:
                    Object.Destroy(model.gameObject);
                    _snake.AddTailBlock();
                    break;
                case CheckPointController checkPoint:
                    _snake.ChangeColor(checkPoint.Color);
                    break;
                default:
                    break;
            }
        }

        public override Vector3 GetTarget(Vector3 mousePos)
        {
            return Vector3.right;
        }
    }
}
