using UnityEngine;

namespace Mechanics
{
    /// <summary>
    /// Find distance by side of screen
    /// </summary>
    public class Board : MonoBehaviour
    {
        [SerializeField] private float minPosition;
        [SerializeField] private float maxPosition;

        public float MINPosition => minPosition;
        public float MAXPosition => maxPosition;
    }
}