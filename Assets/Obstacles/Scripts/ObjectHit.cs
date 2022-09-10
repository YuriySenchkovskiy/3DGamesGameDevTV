using UnityEngine;

namespace Obstacles.Scripts
{
    public class ObjectHit : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}