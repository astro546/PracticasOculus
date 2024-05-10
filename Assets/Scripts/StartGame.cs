using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    bool gameStarted = false;
    public GameObject Gun;
    public GameObject oculusControl;
    GameObject player;
    GameObject oculusController;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
        oculusController = player.transform.GetChild(3).gameObject;
        canvas = player.transform.GetChild(4).GetComponent<Canvas>();
    }

    public void startGame(){
        Debug.Log("Juego Iniciado");
        oculusControl.SetActive(false);
        Gun.SetActive(true);
        canvas.enabled = false;
        gameStarted = true;
    }
}
