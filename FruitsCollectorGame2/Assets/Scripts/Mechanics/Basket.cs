using UI;
using UnityEngine;

namespace Mechanics
{
    public class Basket : MonoBehaviour
    {
        // [Header("Move Stuff")] [SerializeField]
        // private float speed;

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

        // private void Update()
        // {
        //     const float dil = 20f;
        //
        //     if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //     {
        //         transform.position += Vector3.left * speed / dil;
        //     }
        //
        //     if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //     {
        //         transform.position += Vector3.right * speed / dil;
        //     }
        // }

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