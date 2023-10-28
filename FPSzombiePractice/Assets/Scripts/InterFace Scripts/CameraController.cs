using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    float MouseX, MouseY;
    [SerializeField] float MouseSensivty;
    Vector3 objRot;
    public Transform CharacterBodyRot;
    CharacterMovement charMov;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        charMov = GameObject.Find("Whiteclown N Hallin").GetComponent<CharacterMovement>();


    }
    void LateUpdate()
    {
        if (charMov.Aliveİs() == false)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 15);
            MouseX += Input.GetAxis("Mouse X") * MouseSensivty;
            MouseY += Input.GetAxis("Mouse Y") * -MouseSensivty;
            transform.eulerAngles = new Vector3(MouseY, MouseX, 0);
            target.eulerAngles = new Vector3(0, MouseX, 0);
            if (MouseY > 26)
            {
                MouseY = 26;
            }
            if (MouseY < -51)
            {
                MouseY = -51;
            }
            Vector3 temp = transform.eulerAngles;
            temp = transform.eulerAngles;
            temp.z = 0f;
            temp.y = transform.eulerAngles.y + 50;
            temp.x = transform.eulerAngles.x + 15;
            objRot = temp;
            CharacterBodyRot.transform.eulerAngles = objRot;

        }
    }



}
