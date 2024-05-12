using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool gameStarted = false;
    public GameObject Gun;
    public GameObject oculusControl;
    public GameObject Wall;
    GameObject player;
    //GameObject oculusController;
    Canvas canvas;
    GameObject startUI;

    void Start()
    {
        player = this.transform.parent.gameObject;
        //oculusController = player.transform.GetChild(3).gameObject;
        canvas = this.transform.GetComponent<Canvas>();
        startUI = this.transform.GetChild(0).gameObject;
    }

    public void startGame(){
        Debug.Log("Juego Iniciado");
        oculusControl.SetActive(false);
        Gun.SetActive(true);
        startUI.SetActive(false);
        Wall.SetActive(false);
        canvas.enabled = false;
        gameStarted = true;
    }
}
