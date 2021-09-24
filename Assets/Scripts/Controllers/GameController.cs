using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

namespace Snake
{
    public class GameController : MonoBehaviour
    {
        protected SnakeController _character;
        protected UI UI;

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            Updating();
        }

        protected virtual void Init()
        {
            UI = new UI();
            _character = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeController>();
        }

        protected virtual void Updating()
        {

        }

        protected void Reload(string mes)
        {
            UI.ShowMessage(mes);
            StartCoroutine(RealoadScene());
        }

        private IEnumerator RealoadScene()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
            StopAllCoroutines();
        }
    }
}
