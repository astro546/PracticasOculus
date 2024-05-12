using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RestartGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject Gun;
    public GameObject oculusControl;
    public GameObject zombieParent;
    public GameObject Wall;
    Canvas canvas;
    List<GameObject> zombies = new List<GameObject>();
    

    void GetZombies(List<GameObject> zombies){
        for (int i = 0; i < zombieParent.transform.childCount; i++){
            GameObject zombie = zombieParent.transform.GetChild(i).gameObject;
            zombies.Add(zombie);
        }
    }

    void reviveZombies(List<GameObject> zombies){
        int index = 0;
        foreach(GameObject zombie in zombies){
            Debug.Log("Index Zombies: "+index);
            zombie.transform.GetComponent<UserDetector>().zombieDefeat = false;
            zombie.transform.GetComponent<UserDetector>().enemyAnimator.SetInteger("revive", 1);
            zombie.transform.GetChild(0).transform.GetComponent<Zombie>().bulletHit = 0;
            zombie.transform.GetChild(0).transform.GetComponent<NavMeshAgent>().enabled = false;
            zombie.transform.GetChild(0).transform.localPosition = new Vector3(
                0, 
                -1.2f, 
                0);
            zombie.transform.GetComponent<UserDetector>().userDetected = false;
            index = index == 3 ? 0 : index + 1;
        }
    }

    void deactivateDefeatAnimatorVar(List<GameObject> zombies){
        foreach(GameObject zombie in zombies){
            zombie.GetComponent<UserDetector>().enemyAnimator.SetInteger("defeat", 0);
        }
    }

    public void restartGame(){
        canvas = this.transform.GetComponent<Canvas>();
        GameObject victoryUI = this.transform.GetChild(1).transform.gameObject;
        GameObject defeatUI = this.transform.GetChild(2).transform.gameObject;
        Player.transform.position = new Vector3(-0.15f,-0.33f,-11.6f);
        Player.transform.GetComponent<ZombieCollision>().userDefeat = false;
        Player.transform.GetComponent<WinGame>().winGame = false;
        Player.transform.GetComponent<ZombieCollision>().zombieHits = 0;
        Debug.Log(Player.transform.GetComponent<ZombieCollision>().zombieHits);
        GetZombies(zombies);
        reviveZombies(zombies);
        Gun.SetActive(true);
        oculusControl.SetActive(false);
        Wall.SetActive(false);
        victoryUI.SetActive(false);
        defeatUI.SetActive(false);
        canvas.enabled = false;
        deactivateDefeatAnimatorVar(zombies);
        this.transform.GetComponent<StartGame>().gameStarted = true;
    }

}
