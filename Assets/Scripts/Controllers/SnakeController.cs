using UnityEngine;

namespace Snake
{
    public class SnakeController: GameController, IController
    {
        [SerializeField] private float _speed;
        [SerializeField] private TailController _tail;
        [SerializeField] private Transform _spawner;

        protected override void Updating()
        {
            MoveTo(Vector3.forward);
        }

        protected virtual void MoveTo(Vector3 target)
        {
            transform.Translate(target * Time.deltaTime * _speed);
        }

        public virtual void SetTarget(Vector3 target) { }
        public virtual void SetMousePos(Vector3 pos) { }

        private void OnTriggerEnter(Collider collider)
        {
            var eat = collider.GetComponent<EatModel>();
            if (eat != null)
            {
                Object.Instantiate(_tail);
                Destroy(eat.gameObject);

            }
        }
    }
}
