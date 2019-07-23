using UnityEngine;
using System.Collections;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {

        public float speed = 10;
        private Vector3 movement;  
        private Rigidbody playerRigidbody;

        void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        public void Move (float x, float z)
        {
            movement.Set (x, 0f, z);
            movement = movement.normalized * speed * Time.deltaTime;
            playerRigidbody.MovePosition (transform.position + movement);
        }
    }   
}

