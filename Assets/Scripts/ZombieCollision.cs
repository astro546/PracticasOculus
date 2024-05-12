using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieCollision : MonoBehaviour
{
    public int zombieHits;
    int zombieHitsMax = 40;
    public bool userDefeat = false;
    Canvas canvas;
    public GameObject defeatUI;
    public GameObject oculusControl;
    public GameObject Gun;


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
            this.transform.position = new Vector3(-0.15f,-0.33f,-8.0f);
            this.transform.GetChild(4).GetComponent<StartGame>().gameStarted = false;
            canvas.enabled = true;
            defeatUI.SetActive(true);
            oculusControl.SetActive(true);
            Gun.SetActive(false);
        }
    }
}
