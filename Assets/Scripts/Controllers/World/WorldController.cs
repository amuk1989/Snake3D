using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake
{
    public class WorldController: GameController
    {
        #region Serializable
        [SerializeField] private Transform _lastBlock;
        [SerializeField] private BlockController _worldBlock;
        [SerializeField] private float _distanceForSpawn;
        [SerializeField] private float _distanceCheckPoint = 20.0f;
        #endregion

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
            _lastBlock = Instantiate(_worldBlock, position, transform.rotation, transform).transform;
            _lastBlock.name = $"block {_character.Distance}";
            if (_character.Distance > _distanceCheckPoint)
            {
                _lastBlock.gameObject.GetComponent<BlockController>().CreateCheckPoint();
            }
        }
    }
}
