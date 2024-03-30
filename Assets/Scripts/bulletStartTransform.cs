using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletStartTransform : MonoBehaviour
{
    private Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
        cameraTransform = Camera.main.transform;
}

    // Update is called once per frame
    void Update()
    {
        // Obtener la rotación de la cámara
        Quaternion rotacionCamara = Camera.main.transform.rotation;

        // Asignar la rotación al gameObject al que este script está adjunto
        transform.rotation = rotacionCamara;
    }
}
