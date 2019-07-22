using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapGen
{
    public class WallCleanUp : MonoBehaviour
    {
        private float timer = 6f;
        private bool wallBordersRoom = false;

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        void FixedUpdate()
        {
            if(timer <= 0 && !wallBordersRoom){
                Destroy(gameObject);
            }
            else
            {
                timer--;
            }
            
        }

        /// <summary>
        /// OnTriggerEnter is called when the Collider other enters the trigger.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Floor"))
            {
                wallBordersRoom = true;
                Destroy(this);
            }

        }
    }
    
}


