using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private int hor_input = 0;
    private int ver_input = 0;
    private float playerSpeed = 6.0f;
    private float playerSprintSpeed = 12.0f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        hor_input = 0;
        ver_input = 0;
        if (Input.GetKey("a")) {
            hor_input--;
        } 
        if (Input.GetKey("d")) {
            hor_input++;
        }
        if (Input.GetKey("w")) {
            ver_input++;
        } 
        if (Input.GetKey("s")) {
            ver_input--;
        }
        Vector3 move = new Vector3(hor_input, ver_input, 0);
        if (Input.GetKey("space")) {
            controller.Move(move * Time.deltaTime * playerSprintSpeed);
        } else {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
    }
}