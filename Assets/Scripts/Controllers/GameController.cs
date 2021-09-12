using UnityEngine;

namespace Snake
{
    public class GameController : MonoBehaviour
    {
        public void Start()
        {
            Init();
        }

        public void Update()
        {
            Updating();
        }

        protected virtual void Init()
        {

        }

        protected virtual void Updating()
        {

        }
    }
}
