using UI;
using UnityEngine;

namespace Mechanics
{
    /// <summary>
    /// Player logic
    /// </summary>
    public class Basket : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;

        private AudioSource _audioSource;
        private FruitsManager _fruitManager;

        private void Start()
        {
            _fruitManager = FindObjectOfType<FruitsManager>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Awake()
        {
            GameManager.CurrentHealth = maxHealth;
            GameManager.CurrentScore = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("fruit"))
            {
                if (GameManager.IsGame)
                {
                    _audioSource.Play();
                    GameManager.CurrentScore += other.GetComponent<Fruit>().ScoreAmount;
                    PlayerUI.SetScore();
                }

                _fruitManager.AddToPool(other.gameObject);
            }
        }
    }
}