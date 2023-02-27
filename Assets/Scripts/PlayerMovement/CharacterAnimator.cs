using System;
using UnityEngine;
using UnityEngine.AI;


public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float locomotionAnimation = 0.1f;

        private void Update()
        {
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("speedPercent", speedPercent, locomotionAnimation, Time.deltaTime);
        }
    }