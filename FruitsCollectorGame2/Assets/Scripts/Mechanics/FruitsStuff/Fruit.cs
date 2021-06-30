using System.Collections;
using UnityEngine;

namespace Mechanics
{
    public class Fruit : MonoBehaviour
    {
        public int ScoreAmount { get; set; }

        [SerializeField] private float delayBeforeDeactivate;

        private FruitsManager _fruitManager;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(delayBeforeDeactivate);
            _fruitManager = FindObjectOfType<FruitsManager>();
            _fruitManager.AddToPool(gameObject);
        }
    }
}