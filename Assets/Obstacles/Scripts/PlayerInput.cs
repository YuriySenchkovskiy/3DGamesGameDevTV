using UnityEngine;
using UnityEngine.InputSystem;

namespace Obstacles.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;

        private void OnMove(InputValue value)
        {
            var vector = value.Get<Vector2>();
            _playerMover.SetValue(vector);
        }
    }
}