using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake
{
    public class WorldController: GameController
    {
        [SerializeField] private ParticleSystem _checkPoint;
        [SerializeField] private WorldBlockController _lastBlock;
        [SerializeField] private float _distanceForSpawn;
        [SerializeField] private float _distanceCheckPoint = 20.0f;

        protected override void Init()
        {
            base.Init();
        }

        protected override void Updating()
        {
            if (_lastBlock.transform.position.x - _character.transform.position.x < _distanceForSpawn)
            {
                BlockSpawn(_lastBlock.transform.localPosition + Vector3.right * 10);
            }
            base.Updating();
        }

        private void BlockSpawn(Vector3 position)
        {
            Debug.Log(_character.Distance);
            _lastBlock = Instantiate(_lastBlock, position, transform.rotation, transform);
            _lastBlock.name = $"block {_character.Distance}";
            if (_character.Distance > _distanceCheckPoint)
            {
                Instantiate(_checkPoint, position, transform.rotation, transform);
                _character.ChangeColor();
            }
        }
    }
}
