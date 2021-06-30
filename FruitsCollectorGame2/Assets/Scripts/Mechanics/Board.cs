using UnityEngine;

namespace Mechanics
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private float minPosition;
        [SerializeField] private float maxPosition;

        public float MINPosition => minPosition;
        public float MAXPosition => maxPosition;
    }
}