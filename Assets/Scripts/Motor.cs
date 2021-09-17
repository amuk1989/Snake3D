using UnityEngine;

namespace Snake
{
    public class Motor
    {
        private Transform _transform;
        public Motor(Transform transform)
        {
            _transform = transform;
        }
        public void MoveTo(Vector3 target, float speed)
        {
            _transform.Translate(target * Time.deltaTime * speed, Space.Self);
        }
    }
}
