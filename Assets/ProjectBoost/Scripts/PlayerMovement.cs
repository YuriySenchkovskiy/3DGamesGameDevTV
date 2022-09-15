using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveUpPower;
    [SerializeField] private float _rotationPower;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _moveClip;
    [SerializeField] private ParticleSystem _moveUpParticles;
    [SerializeField] private ParticleSystem _leftParticles;
    [SerializeField] private ParticleSystem _rightParticles;

    private Vector2 _direction;
   
    private void FixedUpdate()
    {
        Rotate();
        StopSources();
    }

    public void SetValue(Vector2 direction)
    {
        _direction = direction;
    }

    public void MoveUp()
    {
       _rigidbody.AddRelativeForce(Vector3.up * _moveUpPower * Time.deltaTime);
       PlayMoveClip();
       TurnOnParticles(_moveUpParticles);
    }

    private void StopSources()
    {
        if (_rigidbody.velocity.y < -4.2f)
        {
            _audio.Stop();
            _moveUpParticles.Stop();
        }
    }

    private void Rotate()
    {
        if (_direction.x < 0)
        {
            ApplyRotation(_rotationPower);
            TurnOnParticles(_rightParticles);
        }
        else if (_direction.x > 0)
        {
            ApplyRotation(-_rotationPower);
            TurnOnParticles(_leftParticles);
        }
        else
        {
            _rightParticles.Stop();
            _leftParticles.Stop();
        }
    }

    private void PlayMoveClip()
    {
        if (!_audio.isPlaying)
        {
            _audio.PlayOneShot(_moveClip);
        }
    }

    private void TurnOnParticles(ParticleSystem particles)
    {
        if (!particles.isPlaying)
        {
            particles.Play();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }
}
