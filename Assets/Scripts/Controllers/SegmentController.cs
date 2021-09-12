using UnityEngine;

namespace Snake
{
    public class SegmentController: SnakeController
    {
        private float _distanceToMouse = 0;
        private Vector3 _vectorDist = Vector3.zero;

        public override void SetTarget(Vector3 target)
        {
            if (target != Vector3.zero)
            {
                _distanceToMouse = transform.position.z - target.z;
                _vectorDist.Set(_distanceToMouse, 0, 0);
                MoveTo(_vectorDist.normalized);
            }
        }
    }
}
