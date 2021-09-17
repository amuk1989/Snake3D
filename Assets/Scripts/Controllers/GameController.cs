using UnityEngine;

namespace Snake
{
    public class GameController : MonoBehaviour
    {
        protected SnakeController _character;

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
            _character = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeController>();
        }

        protected virtual void Updating()
        {

        }
    }
}
