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

        private void OnTriggerEnter(Collider collider)
        {
            var controller = collider.GetComponent<GameController>();
            if (controller) _character.SnakeState.Eat(controller);
        }
    }
}
