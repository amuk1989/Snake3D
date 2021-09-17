using UnityEngine;

namespace Snake
{
    public class HeadController: SegmentController
    {
        protected Vector3 _target = Vector3.zero;
        private SnakeController _snake;

        public SnakeController Snake
        {
            set
            {
                _snake = value;
            }
        }

        protected override void Init()
        {
            base.Init();
        }

        protected override void Updating()
        {
            base.Updating();
        }

        public override void SetMousePos(Vector3 pos)
        {
            SetTarget(pos);
        }

        private void OnTriggerEnter(Collider collider)
        {
            var food = collider.GetComponent<FoodModel>();
            if (food != null)
            {
                _snake.Eat(food);
            }
        }
    }
}
