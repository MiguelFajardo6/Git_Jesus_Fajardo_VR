using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practica3 : MonoBehaviour
{
    public GameObject cilindro;
    public GameObject esfera;
    public Camera camara;
    public float tiempo = 10f; 
    

    private enum Estado {edoCilindro,edoEsfera, edoCubemapping};
    private Estado edoActual;

    void Start()
    {
        edoActual = Estado.edoCilindro;
        StartCoroutine(MaquinaEstados());
    }

    IEnumerator MaquinaEstados()
    {
        while (true)
        {
            switch (edoActual)
            {
                case Estado.edoCilindro:
                    cilindro.SetActive(true);
                    camara.clearFlags = CameraClearFlags.SolidColor;
                    edoActual = Estado.edoEsfera;
                    yield return new WaitForSeconds(tiempo);
                    break;
                case Estado.edoEsfera:
                    esfera.SetActive(true);
                    cilindro.SetActive(false);
                    edoActual = Estado.edoCubemapping;
                    yield return new WaitForSeconds(tiempo);
                    break;
                case Estado.edoCubemapping:
                    esfera.SetActive(false);
                    camara.clearFlags = CameraClearFlags.Skybox;
                    edoActual = Estado.edoCilindro;
                    yield return new WaitForSeconds(tiempo);
                    break;
            }
        }
    }
}
