using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Interactable : MonoBehaviour
    {

        bool isFocus;
        Transform player;

        bool hasInteracted = false;

        public float interactionRadius = 3f;
        public Transform interactionZone;

        public virtual void Interact()
        {
            Debug.Log("interacted");

        }


        // Update is called once per frame
        void Update()
        {

            if (isFocus && !hasInteracted)
            {
                float distance = Vector3.Distance(player.position, interactionZone.position);
                if (distance <= interactionRadius)
                {
                    Interact();
                    hasInteracted = true;
                }
            }

        }

        public void OnFocused(Transform playerTransform)
        {
            isFocus = true;
            player = playerTransform;
            hasInteracted = false;
        }

        public void DeFocused()
        {
            isFocus = false;
            player = null;
            hasInteracted = false;

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
