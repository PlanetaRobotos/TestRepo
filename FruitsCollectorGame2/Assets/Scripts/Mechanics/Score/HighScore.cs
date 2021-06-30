using System;
using System.Linq;
using UnityEngine;

namespace Mechanics
{
    /// <summary>
    /// Top-5 best results
    /// </summary>
    public class HighScore : MonoBehaviour
    {
        public const int HighScoreCount = 5;

        private void Awake()
        {
            // Debug.Log("IsFirstGame: " + PlayerPrefs.GetInt("IsFirstGame"));

            if (PlayerPrefs.GetInt("IsFirstGame") != 0) return;

            PlayerPrefs.SetInt("Music", 0);
            PlayerPrefs.SetInt("BgNumber", 0);
            PlayerPrefs.SetInt("IsFirstGame", 1);
        }

        /// <summary>
        /// Adding Score in prefs
        /// </summary>
        /// <param name="number">from 0 to 4</param>
        /// <param name="value"></param>
        private static void AddScore(int number, int value) => PlayerPrefs.SetInt($"Number{number}", value);

        public static int CheckNewScore(int value)
        {
            for (int i = 0; i < HighScoreCount; i++)
            {
                if (value > PlayerPrefs.GetInt($"Number{i}") && !IsContains(value))
                {
                    int[] highScores = new int[HighScoreCount - i];

                    for (int j = 0; j < HighScoreCount - i; j++)
                    {
                        // Debug.Log("j = " + j);

                        highScores[j] = PlayerPrefs.GetInt($"Number{i + j}");
                    }

                    int val = 0;
                    for (int k = i + 1; k < HighScoreCount; k++)
                    {
                        AddScore(k, highScores[val]);
                        val++;
                    }

                    AddScore(i, value);

                    return i;
                }
            }

            return -1;
        }

        private static bool IsContains(int value)
        {
            for (int i = 0; i < HighScoreCount; i++)
                if (value == PlayerPrefs.GetInt($"Number{i}"))
                    return true;

            return false;
        }
    }
}