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
        private Text _message;
        private Text _score;
        private Text _diamonds;

        protected int Score
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_score.text);
                }
                catch
                {
                    return 0;
                }

            }
            set
            {
                try
                {
                    _score.text = value.ToString();
                }
                catch
                {
                }
            }
        }
        protected int DimondsCount
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_diamonds.text);
                }
                catch
                {
                    return 0;
                }

            }
            set
            {
                try
                {
                    _diamonds.text = value.ToString();
                }
                catch
                {
                }
            }
        }

        public void Start()
        {
            Init();
        }

        public void Update()
        {
            Updating();
        }

        protected virtual void Init()
        {
            _character = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeController>();
            _message = GameObject.Find("Message").GetComponent<Text>();
            _score = GameObject.Find("Score").GetComponent<Text>();
            _diamonds = GameObject.Find("Diamonds").GetComponent<Text>();
        }

        protected virtual void Updating()
        {

        }

        protected void Reload(string mes)
        {
            _message.text = mes;
            StartCoroutine(RealoadScene());
        }

        protected void ShowMessage(string message)
        {
            _message.text = message;
        }

        private IEnumerator RealoadScene()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
            StopAllCoroutines();
        }
    }
}
