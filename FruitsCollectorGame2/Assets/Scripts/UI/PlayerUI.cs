using System;
using Mechanics;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// All player ui fiches
    /// </summary>
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Image[] hearts;
        [SerializeField] private Text[] highScores;

        private static PlayerUI _instance;

        private void Awake() =>
            _instance = this;

        private void Start() => 
            SetScore();

        public static void SetScore() => _instance.scoreText.text = $"Score: {GameManager.CurrentScore}";

        public static void SetHealth() => _instance.hearts[GameManager.CurrentHealth].gameObject.SetActive(false);

        public static void SetHighScore(int number) => _instance.highScores[number].text = $"Score {number + 1}: {GameManager.CurrentScore}";

        public static void SetCurrentHigScore()
        {
            for (int i = 0; i < HighScore.HighScoreCount; i++)
            {
                int j = i + 1;
                _instance.highScores[i].text = $"Score {j}: {PlayerPrefs.GetInt($"Number{i}")}";
            }
        }
    }
}