using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Interaction;

namespace RPGAnimations
{
    [RequireComponent(typeof(Animator))]
        public class CharacterAnimator : MonoBehaviour {
        public Animator anim;
        public float defaultSpeed = 4;
        public float combatSpeed = 2;
        NavMeshAgent agent;
        const float locomotionAnimSmoothTime = 0.1f;        
        float animSpeedMultiplier = 1f;
        
        void Start () {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }
        
        // Update is called once per frame
        void Update () {
            Move(agent.velocity);
        }

        public void Move(Vector3 velocity)
		{
            float speedPercent = velocity.magnitude/agent.speed;
            anim.SetFloat("speedPercent", speedPercent, locomotionAnimSmoothTime, Time.deltaTime);
			if (velocity.magnitude > 0)
			{
                anim.SetBool("Moving",true);
				anim.speed = animSpeedMultiplier;
			}
            else{
                anim.SetBool("Moving",false);
				anim.speed = animSpeedMultiplier;
            }
		}
        public void StateCheck(Interactable focus)
        {

        }
        public void PlayAttackAnimation()
        {
            anim.SetTrigger("Attack");
        }

        private void UpdateAnimator(Vector3 move)
		{

		}

    }
}

