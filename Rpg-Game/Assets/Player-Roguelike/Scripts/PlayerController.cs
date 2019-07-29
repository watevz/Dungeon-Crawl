using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(PlayerMovement))]

public class PlayerController : MonoBehaviour {

    public LayerMask groundLayer;
    private PlayerMovement motor;
    private int floorMask;
    //private CharacterAnimator animator;

    // public Interactable focus;

    private void Start()
    {
        motor = GetComponent<PlayerMovement>();
        //animator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        MouseActivity();
        //animator.StateCheck(focus);
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
        if (Physics.Raycast(ray, out hit, groundLayer))
        {
            // move to position
            motor.Move(hit.point);
            // stop focusing any objects
            //RemoveFocus();
        }
    }

    private void RightMouseClick()
    {
        //set focus to right clicked object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // if (Physics.Raycast(ray, out hit))
        // {
        //     Interactable interactable = hit.collider.GetComponent<Interactable>();
        //     if (interactable != null)
        //     {
        //         SetFocus(interactable);
        //     }
        // }
    }

    // private void SetFocus(Interactable targetInteractable)
    // {
    //     if(focus != targetInteractable)
    //     {
    //         if( focus != null)
    //         {
    //             focus.DeFocused();
    //         }
            
    //         focus = targetInteractable;
    //         motor.FollowTarget(focus);
            
    //     }

    //     targetInteractable.OnFocused(transform);
    //     animator.StateCheck(focus);
    // }

    // private void RemoveFocus()
    // {
    //     if (focus != null)
    //     {
    //         focus.DeFocused();
    //     }

    //     focus = null;
    //     motor.StopFollowingTarget();
    //     animator.StateCheck(focus);
    // }
}
