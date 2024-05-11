using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    Transform playerPos;
    public GameObject zombieParent;
    List<GameObject> zombies = new List<GameObject>();
    bool zombieDefeat;
    public bool winGame = false;
    
    void GetZombies(List<GameObject> zombies){
        for (int i = 0; i < zombieParent.transform.childCount; i++){
            GameObject zombie = zombieParent.transform.GetChild(i).gameObject;
            zombies.Add(zombie);
        }
    }

    bool ZombiesAreDead(List<GameObject> zombies){
        int numZombiesDead = 0;
        foreach (GameObject zombie in zombies){
            zombieDefeat = zombie.GetComponent<UserDetector>().zombieDefeat;
            if(zombieDefeat){
                numZombiesDead++;
            }
        }
        return numZombiesDead == 4;
    }

    void Start()
    {
        playerPos = this.gameObject.transform;
        GetZombies(zombies);
    }

    // Update is called once per frame
    void Update()
    {
        //bool goalPos = playerPos.position.z > 18 && playerPos.position.x < -27;
        bool zombiesAreaDead = ZombiesAreDead(zombies);
        if(zombiesAreaDead){
            winGame = true;
        }
    }
}
