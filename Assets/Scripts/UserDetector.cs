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
    public bool zombieDefeat = false;
    bool userDefeat;
    bool gameStarted;

    void OnTriggerEnter(Collider collider){
        userDetected = true;
    }

    // Update is called once per frame
    void Update()
    {
        zombieDefeat = !(enemyAnimator.GetInteger("defeat") == 0);
        userDefeat = User.parent.GetComponent<ZombieCollision>().userDefeat;
        gameStarted = User.parent.GetChild(4).GetComponent<StartGame>().gameStarted;
        if(userDetected  && !zombieDefeat && !userDefeat && gameStarted){
            enemyAnimator.SetInteger("action", 1);
            enemyAgent.destination = User.position;
        } else {
            enemyAnimator.SetInteger("action", 0);
        }
    }
}
