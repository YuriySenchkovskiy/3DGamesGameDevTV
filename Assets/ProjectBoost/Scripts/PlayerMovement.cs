using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveUpPower;
    [SerializeField] private float _rotationPower;
    [SerializeField] private AudioSource _audio;

    private Vector2 _direction;
    private bool _isAlive;

    private void Awake()
    {
        _isAlive = true;
    }

    private void FixedUpdate()
    {
        Rotate();
        
        if (_rigidbody.velocity.y < -4.2f)
        {
            _audio.Stop();
        }
    }

    public void SetValue(Vector2 direction)
    {
        _direction = direction;
    }

    public void MoveUp()
    {
        if (!_isAlive)
        {
            return;
        }
        
        _rigidbody.AddRelativeForce(Vector3.up * _moveUpPower * Time.deltaTime);
        
        if (!_audio.isPlaying)
        {
            _audio.Play();
        }
    }

    private void Rotate()
    {
        if (_direction.x < 0)
        {
            ApplyRotation(_rotationPower);
        }
        else if (_direction.x > 0)
        {
            ApplyRotation(-_rotationPower);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }
}
