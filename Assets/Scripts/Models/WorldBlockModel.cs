using UnityEngine;

namespace Snake
{
    public class WorldBlockModel: MonoBehaviour, IModel
    {
        public Transform GetTransform => transform;

        public void SetTransform(Vector3 playerPos)
        {
            if ((playerPos.x - transform.position.x) > 10)
            {
                transform.position += Vector3.right * 30;
            }
        }
    }
}
