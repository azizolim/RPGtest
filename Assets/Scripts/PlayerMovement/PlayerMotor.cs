using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    

    private Transform _target;
    private  void Update() 
    {
        if (_target != null)
        {
            FaceTarget();
        }
    }

    private void FaceTarget()
    {
       Vector3 direction =  (_target.position - transform.position).normalized;
       Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
       transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5);
    }
    
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.Radius;
        _target = newTarget.InteractionTransform;
        MoveToPoint(_target.position);
        agent.updateRotation = false;
    }

    public void StopFollowing()
    {
        agent.stoppingDistance = 0;
        _target = null;
        agent.updateRotation = true;
    }
}
