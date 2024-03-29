using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Obtenemos los valores de los ejes X e Y del joystick izquierdo
        float camJoyX = Input.GetAxisRaw("CamX") * Time.deltaTime * sensX;
        float camJoyY = Input.GetAxisRaw("CamY") * Time.deltaTime * sensY;

        //Modificamos la rotacion conforme los valores de los ejes del joystick
        yRotation += camJoyY;
        xRotation += camJoyX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Esta linea es para poder girar en 360 grados en el eje X

        //Asignamos la rotacion a la camara
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //Asignamos la oritentacion al usuario
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
