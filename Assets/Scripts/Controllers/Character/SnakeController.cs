using UnityEngine;
using System.Collections;

namespace Snake
{
    public class SnakeController : GameController, IController
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _plasticity = 0.2f;
        [SerializeField] private TailController _tail;
        [SerializeField] private HeadController _head;

        private Motor _motor;
        private SegmentController _lastSegment;
        private SuperSnake _superSnake;
        private SimpleSnake _simpleSnake;
        private SnakeState _snakeState;
        private float _distance;
        private float _step;
        private int _diamondCount = 0;

        public float Distance => _distance;
        public float Speed
        {
            set
            {
                _head.Speed = value;
            }
            get
            {
                return _head.Speed;
            }
        }

        public SnakeState SnakeState 
        {
            get
            {
                return _snakeState;
            }
            private set
            {
                _snakeState = value;
            } 
        }

        protected override void Init()
        {
            _motor = new Motor(transform);
            _superSnake = new SuperSnake(GetComponent<SnakeController>());
            _simpleSnake = new SimpleSnake(GetComponent<SnakeController>());
            SnakeState = _simpleSnake;
            _head.Speed = _speed;
            _lastSegment = _head;
            _step = transform.position.x;
            base.Init();
        }

        protected override void Updating()
        {
            
            _motor.MoveTo(Vector3.forward, Speed);
            _distance += Mathf.Abs(_step - transform.position.x);
            _step = transform.position.x;
        }

        public void SetMousePos(Vector3 pos)
        {
            _head.SetTarget(SnakeState.GetTarget(pos));
        }

        public void Eat(FoodModel food)
        {
            if (food.Color == _head.Color)
            {
                Destroy(food.gameObject);
                AddTailBlock();
            }
            else Dead();
        }

        public void AddTailBlock()
        {
            var tail = Instantiate(_tail, _lastSegment.transform.parent.transform);
            tail.Plasticity = _plasticity;
            tail.Speed = _speed;
            tail.NextSegment = _lastSegment;
            tail.Color = _lastSegment.Color;
            _lastSegment = tail;
        }

        public void Eat(DiamondModel diamond)
        {
            Destroy(diamond.gameObject);
            _diamondCount++;
            if (_diamondCount == 3)
            {
                SnakeState = _superSnake;
                StartCoroutine(SuperCoroutine());
                _diamondCount = 0;
            }
        }

        public void ChangeColor(Color color)
        {
            _lastSegment.ChangeColor(color);
        }

        public void Dead()
        {
            Debug.Log("dead");
        }

        private IEnumerator SuperCoroutine()
        {
            var timer = 0.0f;
            Speed = _superSnake.Speed;
            while(timer < 10f)
            {
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            SnakeState = _simpleSnake;
            Speed = _speed;
            StopAllCoroutines();
        }
    }
}
