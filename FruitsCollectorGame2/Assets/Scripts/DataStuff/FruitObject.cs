using UnityEngine;

namespace DataStuff
{
    /// <summary>
    /// Settings for fruit objects
    /// </summary>
    [CreateAssetMenu(fileName = "New Fruit", menuName = "Data/Fruit", order = 0)]
    public class FruitObject : ScriptableObject
    {
        public Sprite fruitSprite;
        public int scoreAmount = 1;
    }
}