using UnityEngine;

namespace Snake
{
    public class FoodModel : GameModel, IModel
    {
        private Renderer _renderer;
        private System.Random _random = new System.Random();

        public Color Color
        {
            get
            {
                var render = GetComponentInChildren<Renderer>();
                return render.material.color;
            }
            set
            {
                var render = GetComponentInChildren<Renderer>();
                render.material.color = value;
            }
        }

        protected override void Init()
        {
            base.Init();
            var renderer = GetComponent<Renderer>();

        }
    }
}
