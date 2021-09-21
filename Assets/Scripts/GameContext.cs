using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class GameContext
    {
        private static GameContext _instance;
        private List<IController> _controllers = new List<IController>();

        public List<IController> Controllers { get => _controllers; }

        private GameContext()
        {
            _controllers.AddRange(GetObjects<SegmentController>());
        }

        public static GameContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameContext();
            }
            return _instance;
        }

        private T[] GetObjects<T>() where T : Object
        {
            return Object.FindObjectsOfType<T>();
        }
    }
}
