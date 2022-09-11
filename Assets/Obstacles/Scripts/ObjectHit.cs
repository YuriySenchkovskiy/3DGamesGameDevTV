using UnityEngine;

namespace Obstacles.Scripts
{
    public class ObjectHit : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GetComponent<MeshRenderer>().material.color = Color.red;
                gameObject.tag = "Hit";
            }
        }
    }
}