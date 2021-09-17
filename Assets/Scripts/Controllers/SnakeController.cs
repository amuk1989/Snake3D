using UnityEngine;

namespace Snake
{
    public class SnakeController: GameController
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _plasticity = 0.2f;
        [SerializeField] private TailController _tail;
        [SerializeField] private HeadController _head;

        private Motor _motor;
        private SegmentController _lastSegment;

        protected override void Init()
        {
            _head.Snake = gameObject.GetComponent<SnakeController>();
            _motor = new Motor(transform);
            _head.Speed = _speed;
            _lastSegment = _head;
            base.Init();
        }

        protected override void Updating()
        {
            _motor.MoveTo(Vector3.forward, _speed);
        }

        public void Eat(FoodModel food)
        {
            Destroy(food.gameObject);
            var tail = Instantiate(_tail, _lastSegment.transform.parent.transform);
            tail.Plasticity = _plasticity;
            tail.Speed = _speed;
            tail.NextSegment = _lastSegment;
            _lastSegment = tail;
        }
    }
}
