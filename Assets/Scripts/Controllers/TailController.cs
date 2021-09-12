using System;
using System.Collections;
using UnityEngine;

namespace Snake
{
    public class TailController : SegmentController
    {
        [SerializeField] public SegmentController _nextSegment;

        private Coroutine _moveCoroutine;
        protected override void Init()
        {
            base.Init();
        }
        protected override void Updating()
        {
            var dist = Mathf.Abs(_nextSegment.transform.position.z - transform.position.z);

            if (dist >= 0.1f)
            {
                _moveCoroutine = StartCoroutine(MoveCoroutine());
            }
            if (
                dist <= 0.01f
                &&
                _moveCoroutine != null
                )
            {
                StopAllCoroutines();
            }
        }
        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                SetTarget(_nextSegment.transform.position);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
