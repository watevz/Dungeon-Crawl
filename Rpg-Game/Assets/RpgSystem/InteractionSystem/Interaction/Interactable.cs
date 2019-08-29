using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Interactable : MonoBehaviour
    {

        Transform player;

        protected bool hasInteracted = false;

        public float interactionRadius = 3f;
        public Transform interactionZone;

        public void Interact(Transform interactingObject)
        {
             if (!hasInteracted)
            {
                float distance = Vector3.Distance(interactingObject.position, interactionZone.position);
                if (distance <= interactionRadius)
                {
                    CompleteInteract(interactingObject);
                }
            }

        }

        // Update is called once per frame
        // void Update()
        // {

        //     if (!hasInteracted)
        //     {
        //         float distance = Vector3.Distance(player.position, interactionZone.position);
        //         if (distance <= interactionRadius)
        //         {
        //             Debug.Log("player can interact with", this.transform);
        //         }
        //     }

        // }

        protected virtual void CompleteInteract(Transform interactingObject){
            Debug.Log("interacted");
        }

        void OnDrawGizmosSelected()
        {
            if (interactionZone == null)
                interactionZone = transform;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(interactionZone.position, interactionRadius);
        }
    }
}
