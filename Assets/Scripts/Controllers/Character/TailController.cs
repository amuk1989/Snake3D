using System;
using System.Collections;
using UnityEngine;

namespace Snake
{
    public class TailController : SegmentController
    {
        private float _plasticity = 0.2f;
        private SegmentController _nextSegment;
        private Coroutine _moveCoroutine;

        public SegmentController NextSegment
        {
            set
            {
                transform.localPosition = value.transform.localPosition - Vector3.right * 0.5f;
                _nextSegment = value;
            }
        }

        public float Plasticity
        {
            set
            {
                _plasticity = value;
            }
        }

        protected override void Init()
        {
            base.Init();
        }

        protected override void Updating()
        {
            var dist = Mathf.Abs(_nextSegment.transform.position.z - transform.position.z);

            if (dist >= _plasticity)
            {
                _moveCoroutine = StartCoroutine(MoveCoroutine());
            }
            if (dist <= 0.01f && _moveCoroutine != null)
            {
                StopAllCoroutines();
            }
        }

        public void Activate(SegmentController lastSegment)
        {
            transform.localPosition = lastSegment.transform.localPosition - Vector3.right * 0.5f;
            _nextSegment = lastSegment;
        }

        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                SetTarget(_nextSegment.transform.localPosition);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
