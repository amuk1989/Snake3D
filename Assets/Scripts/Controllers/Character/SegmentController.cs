using UnityEngine;

namespace Snake
{
    public class SegmentController: GameController
    {
        private float _distanceToMouse = 0;
        private float _speed;
        private Vector3 _vectorDist = Vector3.zero;
        private Motor _motor;

        #region properties
        public Color Color
        {
            get
            {
                var render = GetComponent<Renderer>();
                return render.material.color;
            }
            set
            {
                var render = GetComponent<Renderer>();
                render.material.color = value;
            }
        }

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        #endregion

        protected override void Init()
        {
            _motor = new Motor(transform);
            base.Init();
        }

        public void SetTarget(Vector3 target)
        {
            if (target != Vector3.zero)
            {
                _distanceToMouse = transform.position.z - target.z;
                _vectorDist.Set(_distanceToMouse, 0, 0);
                _motor.MoveTo(_vectorDist.normalized, _speed);
            }
        }

        public virtual void ChangeColor(Color color)
        {
            Color = color;
        }
    }
}
