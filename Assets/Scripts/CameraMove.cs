using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    /*
    private CharacterController userCharacter;
    public Vector3 userDirection;
    public float userSpeed;
    private Transform cameraTransform;*/

    

    // Start is called before the first frame update
    void Start()
    {
        //cameraTransform = Camera.main.tranform;
    }

    // Update is called once per frame
    void Update()
    {
       /* Vector2 userControl = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float cameraRotation = cameraTransform.eulerAngles.y;
        Vector3 camerarotation = Quaternion.Euler(new Vector3(0, 90, 0)) * cameraTransform.forward;
        userDirection = (camerarotation * Input.GetAxis("Horizontal") + cameraTransform.forward * Input.GetAxis("Vertical")).normalized;
        userCharacter.Move(userDirection * Time.deltaTime * userSpeed);*/
    }
}
