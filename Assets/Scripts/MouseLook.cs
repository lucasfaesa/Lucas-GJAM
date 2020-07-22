using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //usado em FirstPersonPlayer > MainCamera
    //usado somente para olhar ao redor utilizado o mouse, caso tenha feito lerp, irá utilizar a rotação em X do objeto de referencia no primeiro frame, para evitar 'flicks' de camera 
    //ao movimentar a camera quando sair do lerp

    private float currentViewValueX;

    [Header("Manually Assigned")]

    [SerializeField]
    private float mouseSensitivity = 55f;

    float xRotation = 0f;
    float yRotation = 0f;
    float mouseX;
    float mouseY;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -70f, 70f);

            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, -40f, 50f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}