using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectBoost.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;

        private void OnMove(InputValue value)
        {
            var vector = value.Get<Vector2>();
            _playerMovement.SetValue(vector);
        }
        
        private void OnMoveUp(InputValue value)
        {
            if (value.isPressed)
            {
                _playerMovement.MoveUp();
            }
        }
    }
}