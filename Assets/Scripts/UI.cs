using UnityEngine;
using UnityEngine.UI;
using System;

namespace Snake
{
    public class UI
    {
        private Text _message;
        private Text _score;
        private Text _diamonds;

        public int Score
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
        public int DimondsCount
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

        public UI()
        {
            _message = GetComponent<Text>("Message");
            _score = GetComponent<Text>("Score");
            _diamonds = GetComponent<Text>("Diamonds");
        }

        public void ShowMessage(string mes)
        {
            _message.text = mes;
        }

        private T GetComponent<T>(string name)
        {
            return GameObject.Find(name).GetComponent<T>();
        }
    }
}
