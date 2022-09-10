using UnityEngine;

namespace Obstacles.Scripts
{
    public class Scorer : MonoBehaviour
    {
        private int _hits = 0;
        
        private void OnCollisionEnter(Collision collision)
        {
            _hits++;

            Debug.Log(_hits);
        }
    }
}