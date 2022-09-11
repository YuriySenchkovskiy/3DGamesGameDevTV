using UnityEngine;

namespace Obstacles.Scripts
{
    public class Spinner : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;

        private void Update()
        {
            transform.Rotate(0, _rotateSpeed, 0);
        }
    }
}