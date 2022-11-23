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
    public Projectile PlayerProjectile;
    private void Awake()
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
            rb.velocity = move*playerSprintSpeed;
        } else {
            rb.velocity = move*playerSpeed;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 mouseRelPos = Camera.main.ScreenToWorldPoint(mousePos);
            float playerProjectileSpeed = 10f;
            float angle = Mathf.Atan2((mouseRelPos.y-transform.position.y),(mouseRelPos.x-transform.position.x));//*180/Mathf.PI;
            Debug.Log(mouseRelPos.y);
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            var projectile = Instantiate(PlayerProjectile, transform.position+direction*0.4f, transform.rotation);
            projectile.Fire(playerProjectileSpeed, direction);
            /*GameObject playerProjectile = Instantiate(PlayerProjectile, transform.position, transform.rotation);
            rb = playerProjectile.GetComponent<RigidBody2D>();
            //Vector3 mousePos = Input.mousePosition;
            //playerProjectile.direction = Mathf.Atan2((mousePos.y-transform.position.y),(mousePos.x-transform.position.x))*Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(Vector3(0, 0, angle));
            //playerProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 10, 0));*/
        }
    }
}