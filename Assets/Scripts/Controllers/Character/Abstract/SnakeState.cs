using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class SnakeState : ISnakeState
    {
        public abstract float Speed { get;}

        protected SnakeController _snake;
        protected float _speed;
        public abstract void Eat(GameController Eat);
        public abstract Vector3 GetTarget(Vector3 mousePos);
    }
}
