using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class playerInput : MonoBehaviour
{

    actorController aCon;
    cameraController camCon;

    void Start()
    {
        aCon = GetComponent<actorController>();
        camCon = Camera.main.transform.GetComponent<cameraController>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        float mouseHorizontal = Input.GetAxis("Mouse X");
        float mouseVertical = Input.GetAxis("Mouse Y");

        aCon.isRunning = Input.GetButton("Sprint");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        camCon.rotInput = mouseVertical;
        aCon.rotInput = mouseHorizontal;
        aCon.velocity = movement;
    }



}
