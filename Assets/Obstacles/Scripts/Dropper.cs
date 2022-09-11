using UnityEngine;

namespace Obstacles.Scripts
{
    public class Dropper : MonoBehaviour
    {
        [SerializeField] private float _timeValue;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MeshRenderer _meshRenderer;

        private void Start()
        {
            _meshRenderer.enabled = false;
        }

        private void Update()
        {
            if (Time.time > _timeValue)
            {  
                _meshRenderer.enabled = true;
                _rigidbody.useGravity = true;
            }
        }
    }
}