using UnityEngine;
using UnityEngine.EventSystems;


namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour {

        public LayerMask groundLayer;
        private PlayerMovement motor;
        private Rigidbody playerRigidbody;
        float camRayLength = 100f;
        //private CharacterAnimator animator;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            motor = GetComponent<PlayerMovement>();
            //animator = GetComponent<CharacterAnimator>();
        }

        private void FixedUpdate()
        {
            MouseActivity();
            KeyActivity();
            //animator.StateCheck(focus);
        }

        private void MouseActivity()
        {
            Turning();
            if (Input.GetMouseButton(0))
            {
                LeftMouseClick();
            }
            if (Input.GetMouseButton(1))
            {
                RightMouseClick();
            }
        }

        private void LeftMouseClick()
        {

        }

        private void RightMouseClick()
        {

        }

        private void KeyActivity()
        {
            // Store the input axes.
            float x = Input.GetAxisRaw ("Horizontal");
            float z = Input.GetAxisRaw ("Vertical");

            motor.Move(x,z);
        }

        private void Turning ()
        {
            Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit floorHit;

            if(Physics.Raycast (camRay, out floorHit, camRayLength, groundLayer))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0f;
                Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
                playerRigidbody.MoveRotation (newRotation);
            }
        }

    }
}

