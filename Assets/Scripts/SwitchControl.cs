using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using static CheckXRDisplay;

public class SwitchControl : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerMov;
    PlayerCam playerCam;
    GameObject oculusController;
    CheckXRDisplay check;
    Canvas canvas;
    public GameObject oculusControl;
    public GameObject Gun;
    public GameObject VRHand;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        playerMov = GetComponent<PlayerMovement>();
        playerCam = player.transform.GetChild(2).GetComponent<PlayerCam>();
        oculusController = player.transform.GetChild(3).gameObject;
        check = new CheckXRDisplay();
        canvas = player.transform.GetChild(3).GetComponent<Canvas>();

        if (check.Awake()){
            playerMov.enabled = false;
            playerCam.enabled = false;
            oculusController.SetActive(true);
            canvas.transform.SetParent(oculusController.transform);
            Gun.transform.SetParent(VRHand.transform);
        } else {
            playerMov.enabled = true;
            playerCam.enabled = true;
            oculusController.SetActive(false);
            oculusControl.transform.SetParent(playerCam.transform);  
        }
        Gun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
