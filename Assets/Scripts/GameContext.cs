using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class GameContext
    {
        private List<IController> _controllers = new List<IController>();

        public List<IController> Controllers { get => _controllers; }

        public GameContext()
        {
            _controllers.AddRange(GetObjects<SnakeController>());
        }

        private T[] GetObjects<T>() where T : Object
        {
            return Object.FindObjectsOfType<T>();
        }
    }
}
