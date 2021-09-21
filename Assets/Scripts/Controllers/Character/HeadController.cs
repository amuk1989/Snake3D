using UnityEngine;

namespace Snake
{
    public class HeadController: SegmentController
    {
        protected Vector3 _target = Vector3.zero;

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
            var controller = collider.GetComponent<GameController>();
            switch (controller)
            {
                case FoodModel food:
                    _character.Eat(food);
                    break;
                case DiamondModel diamond:
                    _character.Eat(diamond);
                    break;
                case CheckPointController checkPoint:
                    _character.ChangeColor(checkPoint.Color);
                    break;
                case BombModel bomb:
                    _character.Dead();
                    break;
                default:
                    break;
            }
        }
    }
}
