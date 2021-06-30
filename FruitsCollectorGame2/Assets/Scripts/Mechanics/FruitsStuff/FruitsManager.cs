using System.Collections;
using System.Collections.Generic;
using DataStuff;
using UnityEngine;

namespace Mechanics
{
    public class FruitsManager : MonoBehaviour
    {
        [SerializeField] private List<FruitObject> fruits;
        [SerializeField] private GameObject fruitPrefab;

        [SerializeField] private Transform offset;
        [SerializeField] private float xOffset;
        [SerializeField] private float delay;

        [SerializeField] private float delayBetweenSpeedUps;
        [SerializeField] private int poolLenght;    
        
        [SerializeField] private Transform fruitsContainer;
        
        private float _timer;
        private Queue<GameObject> _fruitGO;

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => GameManager.IsGame);

            _fruitGO = new Queue<GameObject>();

            for (int i = 0; i < poolLenght; i++)
            {
                int randFruit = Random.Range(0, fruits.Count);
                float randXPosition = Random.Range(-xOffset, xOffset);
                float randGravityScale = Random.Range(0.8f, 1.5f);
                GameObject newFruit = Instantiate(fruitPrefab,
                    new Vector2(randXPosition, offset.position.y), Quaternion.identity);

                newFruit.transform.SetParent(fruitsContainer);
                newFruit.GetComponent<SpriteRenderer>().sprite = fruits[randFruit].fruitSprite;
                newFruit.GetComponent<Fruit>().ScoreAmount = fruits[randFruit].scoreAmount;
                newFruit.GetComponent<Rigidbody2D>().gravityScale = randGravityScale;
                newFruit.SetActive(false);
                
                _fruitGO.Enqueue(newFruit);
            }

            while (GameManager.IsGame)
            {
                // int range = Random.Range(0, poolLenght);
                // _fruitGO[range].SetActive(true);

                _fruitGO.Dequeue().SetActive(true);
                
                yield return new WaitForSeconds(delay);
            }
        }

        private void FixedUpdate()
        {
            if(!GameManager.IsGame) return;
            
            _timer += Time.deltaTime;

            if (_timer >= delayBetweenSpeedUps)
            {
                delay *= 0.8f;
                _timer = 0;
            }
        }

        public void AddToPool(GameObject obj)
        {
            obj.SetActive(false);
            _fruitGO.Enqueue(obj);
        }
    }
}