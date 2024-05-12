using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject canvasObject;
    public GameObject Wall;
    public GameObject oculusControl;
    public GameObject Gun;

    void OnTriggerEnter(Collider collider){
        bool winedGame = Player.GetComponent<WinGame>().winGame;
        GameObject winedGameUI = canvasObject.transform.GetChild(1).gameObject;
        Canvas canvas = canvasObject.GetComponent<Canvas>();
        if (winedGame){
            canvasObject.transform.GetComponent<StartGame>().gameStarted = false;
            canvas.enabled = true;
            winedGameUI.SetActive(true);
            Wall.SetActive(true);
            oculusControl.SetActive(true);
            Gun.SetActive(false);
        }
    }
}
