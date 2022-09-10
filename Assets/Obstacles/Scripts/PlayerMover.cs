using UnityEngine;

namespace Obstacles.Scripts
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector2 _direction;

        private void FixedUpdate()
        {
            MovePlayer();
        }

        public void SetValue(Vector2 value)
        {
            _direction = value;
        }
        
        private void MovePlayer()
        {
            var xValue = _direction.x * _speed * Time.deltaTime;
            var zValue = _direction.y * _speed * Time.deltaTime;
            transform.Translate(xValue, 0, zValue);
        }
    }
}