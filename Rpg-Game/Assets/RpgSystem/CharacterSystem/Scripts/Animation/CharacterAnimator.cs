using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Interaction;

namespace RPGAnimations
{
        public class CharacterAnimator : MonoBehaviour {
        public Animator anim;
        public float defaultSpeed = 4;
        public float combatSpeed = 2;
        NavMeshAgent agent;
        const float locomotionAnimSmoothTime = 0.1f;        
        float forwardAmount;
        float turnAmount;
        float animSpeedMultiplier = 1f;
        
        void Start () {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponentInChildren<Animator>();
        }
        
        // Update is called once per frame
        void Update () {

            Move(agent.velocity);
        }

        public void Move(Vector3 move)
		{

			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			// direction.
			if (move.magnitude > 1f) move.Normalize();
			move = transform.InverseTransformDirection(move);
			turnAmount = Mathf.Atan2(move.x, move.z);
			forwardAmount = move.z;

			// send input and other state parameters to the animator
			UpdateAnimator(move);
		}
        public void StateCheck(Interactable focus)
        {
            // if (focus != null)
            // {
            //     if (focus.tag == "Enemy")
            //     {
            //         EnterCombatState();
            //     }
            // }
            // else
            // {
            //     EnterDefaultState();
            // }
        }
        public void PlayAttackAnimation()
        {
            anim.SetTrigger("Attack");
        }

        private void UpdateAnimator(Vector3 move)
		{
			// update the animator parameters
			anim.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
			anim.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
			// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
			// which affects the movement speed because of the root motion.
			if (move.magnitude > 0)
			{
                anim.SetBool("Moving",true);
				anim.speed = animSpeedMultiplier;
			}
            else{
                anim.SetBool("Moving",false);
				anim.speed = animSpeedMultiplier;
            }
		}

    }
}

