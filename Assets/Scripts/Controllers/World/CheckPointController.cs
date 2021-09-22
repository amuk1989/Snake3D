using UnityEngine;
using System.Collections.Generic;

namespace Snake
{
    public class CheckPointController : WorldBlockController
    {
        public List<CheckPoint> PointMaterials;

        private System.Random _random = new System.Random();
        private Renderer _renderer;
        private Color _color;

        public Color Color
        {
            get
            {
                return _color;
            }
        }

        protected override void Init()
        {
            base.Init();
            var randomIndex = _random.Next(0, PointMaterials.Count);
            _renderer = GetComponent<Renderer>();
            _renderer.material = PointMaterials[randomIndex].material;
            _color = PointMaterials[randomIndex].color;
        }

        public void SetMaterial(int index)
        {
            _renderer.material = PointMaterials[index].material;
            _color = PointMaterials[index].color;
        }
    }
}
