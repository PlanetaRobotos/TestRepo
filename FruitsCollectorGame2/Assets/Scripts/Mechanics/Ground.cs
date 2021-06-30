using System;
using UI;
using UnityEngine;

namespace Mechanics
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private AudioClip gameOverClip;

        private AudioSource _audio;
        private FruitsManager _fruitManager;


        private void Start()
        {
            _fruitManager = FindObjectOfType<FruitsManager>();
            _audio = GetComponent<AudioSource>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("fruit") && GameManager.IsGame)
            {
                _fruitManager.AddToPool(other.gameObject);

                GameManager.CurrentHealth = Mathf.Clamp(--GameManager.CurrentHealth, 0, 3);
                // Debug.Log("GameManager.CurrentHealth = " + GameManager.CurrentHealth);
                PlayerUI.SetHealth();
                if (GameManager.CurrentHealth <= 0)
                {
                    _audio.PlayOneShot(gameOverClip);
                    int index = HighScore.CheckNewScore(GameManager.CurrentScore);
                    PlayerUI.SetCurrentHigScore();
                    if (index != -1)
                        PlayerUI.SetHighScore(index);

                    gameOverPanel.SetActive(true);
                    GameManager.IsGame = false;
                }

                if (GameManager.IsGame)
                    _audio.Play();
            }
        }
    }
}