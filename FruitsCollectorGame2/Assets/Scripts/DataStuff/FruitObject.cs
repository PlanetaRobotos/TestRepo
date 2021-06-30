using UnityEngine;

namespace DataStuff
{
    [CreateAssetMenu(fileName = "New Fruit", menuName = "Data/Fruit", order = 0)]
    public class FruitObject : ScriptableObject
    {
        public Sprite fruitSprite;
        public int scoreAmount = 1;
    }
}