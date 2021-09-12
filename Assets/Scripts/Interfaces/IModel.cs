using UnityEngine;

namespace Snake
{
    public interface IModel
    {
        public Transform GetTransform { get;}
        public void SetTransform(Vector3 playerPos);
    }
}
