using UnityEngine;

namespace Snake
{
    public class WorldBlockController: GameController
    {
        [SerializeField] float _distanceForDestroy = 10.0f;

        protected override void Init()
        {
            base.Init();
        }

        protected override void Updating()
        {
            if (_character.transform.position.x - transform.position.x > _distanceForDestroy)
            {
                Destroy(gameObject);
            }
            base.Updating();
        }
    }
}
