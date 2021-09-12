using UnityEngine;

namespace Snake
{
    public class HeadController: SegmentController
    {
        protected Vector3 _target = Vector3.zero;

        protected override void Updating()
        {

        }

        public override void SetMousePos(Vector3 pos)
        {
            SetTarget(pos);
        }


    }
}
