using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class GameContext
    {
        private static GameContext _instance;
        private GameObject _player;
        private List<IController> _controllers = new List<IController>();
        private List<IModel> _models = new List<IModel>();

        public GameObject player { get => _player; }
        public List<IController> Controllers { get => _controllers; }
        public List<IModel> Models { get => _models; }

        private GameContext()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _controllers.AddRange(GetObjects<SnakeController>());
            _models.AddRange(GetObjects<WorldBlockModel>());
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
