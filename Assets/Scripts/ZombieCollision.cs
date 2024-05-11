using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollision : MonoBehaviour
{
    int zombieHits;
    int zombieHitsMax = 40;
    public bool userDefeat = false;
    Canvas canvas;
    public GameObject defeatUI;


    void OnCollisionEnter(Collision collision){
        bool zombieCollision = collision.gameObject.CompareTag("Zombie");
        if (zombieCollision){
            bool zombieDead = collision.transform.parent.transform.GetComponent<UserDetector>().zombieDefeat;
            if (!zombieDead){
                zombieHits++;
            }
            Debug.Log("Numero de golpes que has recibido: "+zombieHits);
            if (zombieHits == zombieHitsMax){
                userDefeat = true;
                Debug.Log("Has perdido la partida");
            }
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = this.transform.GetChild(4).GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (userDefeat){
            canvas.enabled = true;
            defeatUI.SetActive(true);
        }
    }
}
