using UnityEngine;
using System.Collections.Generic;

namespace Snake
{
    public class BlockController: WorldBlockController
    {
        [SerializeField] private List<GameModel> _loots;
        [SerializeField] private CheckPointController _checkPoint;

        private System.Random _random = new System.Random();
        private readonly float _width = 10f;
        private readonly float _height = 7f;

        protected override void Init()
        {
            Spawner(3, 3);
            base.Init();
        }

        protected override void Updating()
        {
            base.Updating();
        }

        public void CreateCheckPoint()
        {
            var checkPoint = Instantiate(_checkPoint, transform);
        }

        private void Spawner(int colCount, int rowCount)
        {
            for (var i = 1; i <= colCount; i++)
            {
                for (var j = 1; j <= rowCount; j++)
                {
                    var randIndex = _random.Next(0, _loots.Count + 1);
                    if (randIndex < _loots.Count)
                    {
                        CreateLoot(_loots[randIndex], colCount, rowCount, i, j);
                    }
                }
            }
        }

        private void CreateLoot(GameModel model, int colCount, int rowCount, int i, int j)
        {
            var loot = Instantiate(model, transform);
            Vector3 pos = GetPos(colCount, rowCount, i, j);
            loot.transform.localPosition = pos;
            loot.name = $"loot_{loot.name}_{transform.name}";
            if (loot is FoodModel)
            {
                var food = (FoodModel)loot;
                var randomIndex = _random.Next(0, _checkPoint.PointMaterials.Count);
                food.Color = _checkPoint.PointMaterials[randomIndex].color;
            }
        }

        private Vector3 GetPos(int colCount, int rowCount, int i, int j)
        {
            return new Vector3(
                j * (_width / (rowCount + 1)) - _width / 2,
                0,
                i * (_height / (colCount + 1)) - _height / 2
                );
        }
    }
}
