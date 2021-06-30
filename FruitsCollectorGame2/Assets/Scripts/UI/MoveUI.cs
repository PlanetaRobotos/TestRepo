using System;
using Mechanics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    /// <summary>
    /// Moving player script
    /// </summary>
    public class MoveUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private string direction;

        [Header("Move Stuff")] [SerializeField]
        private float speed;

        private Transform _basketTransform;
        private Board _board;
        private bool _isDown;
        private const float Dil = 20f;
        private float _width;

        private void Start()
        {
            _board = FindObjectOfType<Board>();
            _basketTransform = FindObjectOfType<Basket>().transform;

            _width = _basketTransform.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void FixedUpdate()
        {
            if (!_isDown) return;

            if (direction == "left" && _basketTransform.position.x > -CameraBorder.Border + _width * 0.4f ||
                direction != "left" && _basketTransform.position.x < CameraBorder.Border - _width * 0.4f)
            {
                Move(direction);
            }
        }

        private void Move(string dir = "left") => 
            _basketTransform.Translate((dir == "left" ? Vector3.left : Vector3.right) * (speed * Time.deltaTime));

        public void OnPointerDown(PointerEventData eventData) => _isDown = true;
        public void OnPointerUp(PointerEventData eventData) => _isDown = false;
    }
}