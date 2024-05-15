using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReleaseRay : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Transform origin = this.transform;
        Ray ray = new Ray(origin.position, origin.forward);
        RaycastHit hit;
        Button button;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "BtnCollider"){
            Debug.Log("Boton Seleccionado");
            button = hit.collider.gameObject.transform.parent.transform.GetComponent<Button>();
            button.Select();
        } else {
            EventSystem.current.SetSelectedGameObject(null); 
        }
    }

    

}
