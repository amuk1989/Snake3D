using UnityEngine;

namespace Snake
{
    public class SnakeController: GameController, IController, ISnakeState
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _plasticity = 0.2f;
        [SerializeField] private TailController _tail;
        [SerializeField] private HeadController _head;

        private Motor _motor;
        private SegmentController _lastSegment;
        private float _distance;
        private float _step;
        private int _diamondCount = 0;
        private ISnakeState _snakeState;

        public float Distance => _distance;

        protected override void Init()
        {
            _motor = new Motor(transform);
            _snakeState = new SimpleSnake();
            _head.Speed = _speed;
            _lastSegment = _head;
            _step = transform.position.x;
            base.Init();
        }

        protected override void Updating()
        {
            _motor.MoveTo(Vector3.forward, _speed);
            _distance += Mathf.Abs(_step - transform.position.x);
            _step = _step = transform.position.x;
        }

        public virtual void Eat(GameController loot)
        {
            _snakeState.Eat(loot);
            /*switch (loot)
            {
                case FoodModel food:
                    Eat(food);
                    break;
                case DiamondModel diamond:
                    Eat(diamond);
                    break;
                case CheckPointController checkPoint:
                    ChangeColor(checkPoint.Color);
                    break;
                case BombModel bomb:
                    Dead();
                    break;
                default:
                    break;

            }*/
        }

        public void SetMousePos(Vector3 pos)
        {
            _head.SetTarget(pos);
        }

        protected void Eat(FoodModel food)
        {
            if (food.Color == _head.Color)
            {
                Destroy(food.gameObject);
                AddTailBlock();
            }
            else Dead();
        }

        private void AddTailBlock()
        {
            var tail = Instantiate(_tail, _lastSegment.transform.parent.transform);
            tail.Plasticity = _plasticity;
            tail.Speed = _speed;
            tail.NextSegment = _lastSegment;
            tail.Color = _lastSegment.Color;
            _lastSegment = tail;
        }

        protected void Eat(DiamondModel diamond)
        {
            Destroy(diamond.gameObject);
            _diamondCount++;
            if (_diamondCount == 2)
            {
                Debug.Log(_diamondCount);
                _diamondCount = 0;
            }
        }

        protected void ChangeColor(Color color)
        {
            _lastSegment.ChangeColor(color);
        }

        protected void Dead()
        {
            Debug.Log("dead");
        }
    }
}
