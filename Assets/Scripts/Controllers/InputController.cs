using System.Collections;
using UnityEngine;

namespace Snake
{
    public class InputController: GameController
    {
        private GameContext _gameContext;
        private Coroutine MouseDownCoroutine;

        protected override void Init()
        {
            _gameContext = GameContext.GetInstance();
            base.Init();
        }

        protected override void Updating()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseDownCoroutine = StartCoroutine(MouseCoroutine());
            }

            if (Input.GetMouseButtonUp(0))
            {
                StopCoroutine(MouseDownCoroutine);
            }
        }

        private IEnumerator MouseCoroutine()
        {
            while (true)
            {
                yield return null;
                _gameContext.Controllers.ForEach(
                    controller => controller.SetMousePos(GetVector(Input.mousePosition))
                    );
            }
        }

        private Vector3 GetVector(Vector3 mousePosOnScreen)
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(mousePosOnScreen);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

            if (Physics.Raycast(ray, out hit, 100))
            {
                return hit.point;
            }
            return Vector3.zero;
        }
    }
}
