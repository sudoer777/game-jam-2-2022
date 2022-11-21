using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private int hor_input = 0;
    private int ver_input = 0;
    private float playerSpeed = 6.0f;
    private float playerSprintSpeed = 12.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            
            //transform.Translate(move*Time.deltaTime*playerSprintSpeed);
            rb.velocity = move*playerSprintSpeed;
            //GetComponent<Rigidbody2D>().MovePosition(transform.position + move * Time.deltaTime * playerSprintSpeed);
        } else {
            rb.velocity = move*playerSpeed;
            //transform.Translate(move*Time.deltaTime*playerSpeed);
            //GetComponent<Rigidbody2D>().MovePosition(transform.position + move * Time.deltaTime * playerSpeed);
        }
    }
}