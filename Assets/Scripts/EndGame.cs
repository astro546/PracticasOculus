using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject canvasObject;
    public GameObject Wall;

    void OnTriggerEnter(Collider collider){
        bool winedGame = Player.GetComponent<WinGame>().winGame;
        GameObject winedGameUI = canvasObject.transform.GetChild(1).gameObject;
        Canvas canvas = canvasObject.GetComponent<Canvas>();
        if (winedGame){
            canvas.enabled = true;
            winedGameUI.SetActive(true);
            Wall.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
