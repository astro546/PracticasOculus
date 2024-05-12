using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public int bulletHit;
    public bool zombieAttack;
    private Animator enemyAnimator;

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Bulet")){
            bulletHit++;
            if (bulletHit == 100){
                enemyAnimator.SetInteger("defeat", 1);
                enemyAnimator.SetInteger("action",0);
                enemyAnimator.SetInteger("attack",0);
            }
        } else {
            zombieAttack = true;
            Debug.Log("Golpe");
        }
    }

    void OnCollisionExit(Collision collision){
        zombieAttack = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(zombieAttack){
            enemyAnimator.SetInteger("attack", 1);
        } else {
            enemyAnimator.SetInteger("attack", 0);
        }
    }
}
