using UnityEngine;
using UnityEngine.EventSystems;
using Interaction;
using RPGAnimations;
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerManager))]

public class PlayerController : MonoBehaviour {

    public LayerMask groundLayer;
    private PlayerMovement motor;
    private PlayerManager playerManager;
    private int floorMask;
    private CharacterAnimator animator;


    private void Start()
    {
        playerManager = PlayerManager.instance;
        motor = GetComponent<PlayerMovement>();
        animator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        MouseActivity();
        animator.StateCheck(playerManager.playerState.focus);
    }

    private void MouseActivity()
    {
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                playerManager.SetFocus(interactable);
                motor.FollowTarget(playerManager.playerState.focus);
            }
        }
    }

    private void RightMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, groundLayer))
        {
            // move to position
            playerManager.RemoveFocus();
            motor.StopFollowingTarget();
            motor.Move(hit.point);
        }
    }

}
