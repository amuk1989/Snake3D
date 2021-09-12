using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake
{
    public class WorldController: GameController
    {
        private GameContext _gameContext;
        private GameObject _player;

        protected override void Init()
        {
            _gameContext = GameContext.GetInstance();
            _player = _gameContext.player;
            base.Init();
        }

        protected override void Updating()
        {
            _gameContext.Models.ForEach(
                model => model.SetTransform(_player.transform.position)
                );
            base.Updating();
        }
    }
}
