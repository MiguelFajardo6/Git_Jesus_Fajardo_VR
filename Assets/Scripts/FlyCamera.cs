using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float flyingSpeed = 5.0f;
    public float rotationRate = 10.0f;
    public Vector2 sensitivity = new Vector2(360f, 360f);

    

    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical"); //Entrada del eje vertical (W, S, arriba, abajo)
        transform.Translate(Vector3.forward * verticalInput * flyingSpeed * Time.deltaTime); //Transformacion vector de vista*boton* velocidad * tiempo

        float horizontalInput = Input.GetAxisRaw("Horizontal"); //Entrada del eje vertical (A, D, Izquierda, Derecha)
        transform.Translate(Vector3.right * horizontalInput * flyingSpeed * Time.deltaTime); //Transformacion vector de entrada*rotacion* velocidad

        
    }
}