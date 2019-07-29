using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public float moveSpeed = 6f;
    public float angSpeed = 720;
    public float accelerationSpeed = 10;

    public Transform target;
   

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        agent.angularSpeed = angSpeed;
        agent.acceleration = accelerationSpeed;
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void Move(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }

    // public void FollowTarget(Interactable targetToFollow)
    // {
    //     target = targetToFollow.interactionZone;
    //     agent.stoppingDistance = targetToFollow.interactionRadius * .8f;
    //     agent.updateRotation = false;
    // }

    public void StopFollowingTarget()
    {
        target = null;
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }
}
