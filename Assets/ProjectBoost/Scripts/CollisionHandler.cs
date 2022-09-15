using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectBoost.Scripts
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private float _dalay;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _success;
        [SerializeField] private AudioClip _crash;
        [SerializeField] private ParticleSystem _successParticles;
        [SerializeField] private ParticleSystem _crushParticles;
        [SerializeField] private ParticleSystem _moveUpParticles;

        private bool _isTransitioning;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (_isTransitioning)
            {
                return;
            }
            
            switch (collision.gameObject.tag)
            {
                case "Friend":
                    Debug.Log("this is friend");
                    break;
                case "Finish":
                    StartSuccessSequence();
                    _moveUpParticles.gameObject.SetActive(false);
                    break;
                default:
                    StartCrashSequence();
                    _moveUpParticles.gameObject.SetActive(false);
                    break;
            }
        }

        private void StartSuccessSequence()
        {
            _isTransitioning = true;
            _successParticles.Play();
            _audioSource.Stop();
            _audioSource.PlayOneShot(_success);
            _playerMovement.enabled = false;
            Invoke(nameof(LoadNextLevel), _dalay);
        }

        private void StartCrashSequence()
        {
            _isTransitioning = true;
            _crushParticles.Play();
            _audioSource.Stop();
            _audioSource.PlayOneShot(_crash);
            _playerMovement.enabled = false;
            Invoke(nameof(ReloadLevel), _dalay);
        }

        private void ReloadLevel()
        {
            var scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene);
        }

        private void LoadNextLevel()
        {
            var scene = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = scene + 1;

            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}