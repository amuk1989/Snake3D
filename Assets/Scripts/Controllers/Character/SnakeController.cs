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
            _head.Speed = _speed;
            _lastSegment = _head;
            _superSnake = new SuperSnake(GetComponent<SnakeController>());
            _simpleSnake = new SimpleSnake(GetComponent<SnakeController>());
            SnakeState = _simpleSnake;
            _step = transform.position.x;
            base.Init();
            UI.Score = 0;
            Debug.Log(_speed);
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
                UI.DimondsCount = 0;
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
            UI.Score++;
        }

        public void Eat(DiamondModel diamond)
        {
            Destroy(diamond.gameObject);
            UI.DimondsCount++;
            if (UI.DimondsCount > 3)
            {
                SnakeState = _superSnake;
                StartCoroutine(SuperCoroutine());
                UI.DimondsCount = 0;
            }
        }

        public void ChangeColor(Color color)
        {
            _lastSegment.ChangeColor(color);
        }

        public void Dead()
        {
            Speed = 0;
            Reload("GameOver");
        }

        private IEnumerator SuperCoroutine()
        {
            var timer = 0.0f;
            while (Speed < _superSnake.Speed)
            {
                Speed += 0.1f;

                yield return new WaitForEndOfFrame();
            }
            UI.ShowMessage("Super Snake!!!");
            while(timer < 5f)
            {
                _head.SetTarget(SnakeState.GetTarget(Vector3.right));
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            UI.ShowMessage("");
            while (Speed > _simpleSnake.Speed)
            {
                Speed -= 0.1f;
                yield return new WaitForEndOfFrame();
            }
            SnakeState = _simpleSnake;
            Speed = _speed;
            StopAllCoroutines();
        }
    }
}
