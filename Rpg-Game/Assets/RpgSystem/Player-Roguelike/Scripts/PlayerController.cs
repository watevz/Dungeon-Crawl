using UnityEngine;
using UnityEngine.EventSystems;
using Interaction;
using RPGAnimations;
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerManager))]

public class PlayerController : MonoBehaviour {

    public LayerMask groundLayer;
    private PlayerMovement motor;
    private int floorMask;
    private PlayerManager playerManager;
    private CharacterCombat combatController;
    private CharacterAnimator animator;


    private void Start()
    {
        playerManager = PlayerManager.instance;
        motor = GetComponent<PlayerMovement>();
        animator = GetComponent<CharacterAnimator>();
        combatController = GetComponent<CharacterCombat>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        MouseActivity();
        animator.StateCheck(playerManager.playerState);
    }

    private void AttemptInteract(Interactable interactable){
        interactable.Interact(this.transform);
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
            GameObject objectClicked = hit.transform.gameObject;
            Interactable interactable = objectClicked.GetComponent<Interactable>();
            if(objectClicked.CompareTag("Enemy")){
                combatController.AttemptAttack(objectClicked);
            }
            else if (interactable != null)
            {
                AttemptInteract(interactable);
                // playerManager.SetFocus(interactable);
                // motor.FollowTarget(playerManager.playerState.focus);
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
            playerManager.SetFocus(null);
            motor.StopFollowingTarget();
            motor.Move(hit.point);
        }
    }

}
