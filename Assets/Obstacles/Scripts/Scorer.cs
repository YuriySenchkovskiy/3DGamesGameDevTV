using UnityEngine;

namespace Obstacles.Scripts
{
    public class Scorer : MonoBehaviour
    {
        private int _hits = 0;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Untagged"))
            {
                _hits++;
            }
        }
    }
}