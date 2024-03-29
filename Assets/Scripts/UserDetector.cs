using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UserDetector : MonoBehaviour
{
    public Transform User;
    public NavMeshAgent enemyAgent;
    public Animator enemyAnimator;
    public bool userDetected;

    void OnTriggerEnter(Collider collider){
        userDetected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(userDetected  && enemyAnimator.GetInteger("defeat") == 0){
            enemyAnimator.SetInteger("action", 1);
            enemyAgent.destination = User.position;
        }
    }
}
