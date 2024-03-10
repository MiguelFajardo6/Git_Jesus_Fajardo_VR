using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPointerSkybox : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxPointerDistance = 4.5f;
    [SerializeField] private float defaultPointerDistance = 5f; // Distancia predeterminada del puntero cuando no está sobre un objeto

    private const string interactableTag = "Interactable";

    private GameObject _gazedAtObject = null;

    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {
        if (_gazedAtObject != null)
        {
            if (_gazedAtObject.CompareTag(interactableTag))
            {
                _gazedAtObject.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
            }
            else if (_gazedAtObject.GetComponent<Button>() != null)
            {
                _gazedAtObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxPointerDistance))
        {
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnterXR", null, SendMessageOptions.DontRequireReceiver);
                GazeManager.Instance.StartGazeSelection();
            }
        }
        else
        {
            _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }

        if (pointer != null)
        {
            if (_gazedAtObject != null)
            {
                // Posiciona el puntero en el punto de impacto del rayo
                pointer.transform.position = hit.point;
                // Ajusta la rotación del puntero para que mire hacia la cámara
                pointer.transform.LookAt(transform.position);
                pointer.SetActive(true);
            }
            else
            {
                // Si no está mirando un objeto interactuable, establece la posición predeterminada
                pointer.transform.position = transform.position + transform.forward * defaultPointerDistance;
                pointer.transform.rotation = transform.rotation;
                pointer.SetActive(true);
            }
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            GazeSelection();
        }

        // Check if the object is no longer being gazed at, and stop the gaze selection
        if (_gazedAtObject == null)
        {
            GazeManager.Instance.CancelGazeSelection();
        }
    }
}
