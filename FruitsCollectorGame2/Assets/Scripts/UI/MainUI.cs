using Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// All main logic for ui (buttons...)
    /// </summary>
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private GameObject startPanel;
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private GameObject[] backGrounds;

        private AudioSource[] _audioSources;

        // private int _currentBg;

        private void Start()
        {
            _audioSources = FindObjectsOfType<AudioSource>();

            if (!startPanel.activeSelf)
                startPanel.SetActive(true);

            ChangeBg(false);
            ChangeMusic(false);
        }

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void StartGame()
        {
            GameManager.IsGame = true;
            // Debug.Log("GameManager.IsGame = " + GameManager.IsGame);
        }

        /// <summary>
        /// Mute and unmute music and sounds
        /// </summary>
        /// <param name="change"></param>
        public void ChangeMusic(bool change)
        {
            if (change)
                PlayerPrefs.SetInt("Music", PlayerPrefs.GetInt("Music") == 1 ? 0 : 1);
            bool isOn = PlayerPrefs.GetInt("Music") == 1;

            musicToggle.isOn = isOn;
            foreach (var audioSource in _audioSources)
                audioSource.mute = isOn;
        }

        /// <summary>
        /// Set in button to changing Bg in game
        /// </summary>
        /// <param name="change"></param>
        public void ChangeBg(bool change)
        {
            if (change)
            {
                int i = PlayerPrefs.GetInt("BgNumber") + 1;
                if (i >= backGrounds.Length)
                    i = 0;
                PlayerPrefs.SetInt("BgNumber", i);
            }

            int value = PlayerPrefs.GetInt("BgNumber");

            foreach (var backGround in backGrounds)
                backGround.SetActive(false);

            backGrounds[value].SetActive(true);
        }

        public void Quit() => Application.Quit();
    }
}